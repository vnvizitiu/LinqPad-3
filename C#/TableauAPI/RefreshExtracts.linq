<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Numerics</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
</Query>

//https://community.tableau.com/docs/DOC-8924
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = Properties.Settings.Default.TableauServerBaseURL;
            var site = Properties.Settings.Default.Site; // Empty for default site
            var username = Properties.Settings.Default.Username;
            var password = Properties.Settings.Default.Password;
            var datasourceIds = Properties.Settings.Default.DataSourceIDs.Split(',');


            var cookies = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookies };


            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(baseAddress);


                Login(cookies, client, username, password, site);
                RunExtractRefresh(client, datasourceIds);
            }
        }


        private static void Login(CookieContainer cookies, HttpClient client, string username, string password, string site)
        {
            var response = client.GetAsync("auth.xml").Result;
            var authString = response.Content.ReadAsStringAsync().Result;


            var authDoc = XElement.Parse(authString);
            var modulus = authDoc.Elements("modulus").First().Value;
            var exponent = authDoc.Elements("exponent").First().Value;
            var authenticityToken = authDoc.Elements("authenticity_token").First().Value;


            var encryptedPassword = EncryptPassword(modulus, exponent, password);


            using (var content = new MultipartFormDataContent())
            {
                var values = new[]  
                {  
                    new KeyValuePair<string, string>("username", username),  
                    new KeyValuePair<string, string>("format", "xml"),  
                    new KeyValuePair<string, string>("crypted", encryptedPassword),  
                    new KeyValuePair<string, string>("target_site", site),
                    new KeyValuePair<string, string>("authenticity_token", authenticityToken),  
                };


                foreach (var keyValuePair in values)
                {
                    content.Add(new StringContent(keyValuePair.Value), String.Format("\"{0}\"", keyValuePair.Key));
                }


                var result = client.PostAsync("manual/auth/login.xml", content).ContinueWith(x => x.Result.EnsureSuccessStatusCode()).Result;


                var responseCookies = cookies.GetCookies(client.BaseAddress).Cast<Cookie>();
                var token = responseCookies.Where(c => c.Name == "XSRF-TOKEN").Select(c => c.Value).First();
                client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", token);
            }
        }


        private static string EncryptPassword(string modulus, string exponent, string password)
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            var parameters = new RSAParameters();


            parameters.Modulus = ToByteArray(BigInteger.Parse(modulus, System.Globalization.NumberStyles.HexNumber));
            parameters.Exponent = ToByteArray(BigInteger.Parse(exponent, System.Globalization.NumberStyles.HexNumber));


            rsaCryptoServiceProvider.ImportParameters(parameters);
            var encryptedByteArray = rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(password), false);


            return BitConverter.ToString(encryptedByteArray).Replace("-", "").ToLower();
        }


        public static byte[] ToByteArray(BigInteger b)
        {
            var x = b.ToByteArray(); // x is little-endian  
            Array.Reverse(x);        // now it is big-endian  
            if (x[0] == 0)
            {
                var newarray = new byte[x.Length - 1];
                Array.Copy(x, 1, newarray, 0, newarray.Length);
                return newarray;
            }
            else
            {
                return x;
            }
        }


        public static void RunExtractRefresh(HttpClient client, string[] datasourceIds)
        {
            var url = "/vizportal/api/web/v1/runExtractRefreshesOnDatasources";


            var request = new
            {
                method = "runExtractRefreshesOnDatasources",
                @params = new
                {
                    ids = datasourceIds,
                    type = "RefreshExtract"
                }
            };


            var content = new JavaScriptSerializer().Serialize(request);


            var response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"))
                .ContinueWith(x => x.Result.EnsureSuccessStatusCode())
                .Result;


            var responseString = response.Content.ReadAsStringAsync().Result;


            if (responseString.Contains("errors"))
            {
                throw new Exception("Run extract refreshes on datasources unsucessful: " + responseString);
            }
            else
            {
                Console.WriteLine("Data sources have sucessfully been triggered to extract: " + String.Join(",", datasourceIds.Select(p => p.ToString()).ToArray()));
            }
        }
    }
