<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Numerics</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
</Query>

//https://community.tableau.com/docs/DOC-5251
 
/// <summary>
/// Tableau REST service implementation
/// </summary>
public class TableauRestService : IDisposable
{
	private string _site;
	private string _tableauServerUri;
	private string _username;
	private string _password;
	private HttpClient _client;
	private bool isLoggedIn = false;


	public TableauRestService(string tableauServerUri, string username, string password, string site = "")
	{
		_tableauServerUri = tableauServerUri;
		_username = username;
		_password = password;
		_site = site;
	}


	/// <summary>
	/// Get xml resource file. 
	/// </summary>
	/// <param name="xmlResource">Xml resource path. For example users.xml</param>
	/// <param name="retryLogin">Retry login if result is unauthorized. Default is true</param>
	/// <returns>XML Linq element for further queries</returns>
	public async Task<XElement> GetResource(string xmlResource, bool retryLogin = true)
	{
		if (!isLoggedIn)
		{
			await Login();
		}
		var resourceTask = await _client.GetAsync(xmlResource);
		if (resourceTask.StatusCode == System.Net.HttpStatusCode.OK)
		{
			var streamContentTask = await resourceTask.Content.ReadAsStreamAsync();
			using (var stream = streamContentTask)
			{
				return XElement.Load(stream);
			}
		}
		else if (resourceTask.StatusCode == System.Net.HttpStatusCode.Unauthorized && retryLogin)
		{
			isLoggedIn = false;
			return await GetResource(xmlResource, false);
		}
		else
		{
			throw new ApplicationException(string.Format("Error reading resource {0}. Staus code ", xmlResource, resourceTask.StatusCode));
		}
	}


	/// <summary>
	/// Login task. Logs in http client and sets session cookie.
	/// </summary>
	/// <returns></returns>
	public async Task Login()
	{
		_client = new HttpClient();
		_client.BaseAddress = new Uri(_tableauServerUri);
		var contentTask = await _client.GetAsync("auth.xml");
	//	var contentTask = await _client.GetAsync("views.xml");
		var streamResult = await contentTask.Content.ReadAsStreamAsync();
		string encryptedPassword = "";
		string authenticityToken = "";
		using (var stream = streamResult)
		{
			var xElement = XElement.Load(stream);
			var modulus = xElement.Elements("modulus").First().Value;
			var exponent = xElement.Elements("exponent").First().Value;
			authenticityToken = xElement.Elements("authenticity_token").First().Value;
			encryptedPassword = EncryptPassword(modulus, exponent, _password);
		}
		var loginTask = await PostLogin(encryptedPassword, authenticityToken);
		isLoggedIn = true;
	}


	/// <summary>
	/// Post login information
	/// </summary>
	/// <param name="encryptedPassword"></param>
	/// <param name="authenticityToken"></param>
	/// <returns></returns>
	private async Task<HttpResponseMessage> PostLogin(string encryptedPassword, string authenticityToken)
	{
		using (var multipartFormDataContent = new MultipartFormDataContent())
		{
			var values = new[]
							{
								new KeyValuePair<string, string>("username", _username),
								new KeyValuePair<string, string>("format", "xml"),
								new KeyValuePair<string, string>("crypted", encryptedPassword),
								new KeyValuePair<string, string>("target_site", _site),
  new KeyValuePair<string, string>("authenticity_token", authenticityToken),
							};
			foreach (var keyValuePair in values)
			{
				multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
					String.Format("\"{0}\"", keyValuePair.Key));
			}


			var loginTask = _client.PostAsync("manual/auth/login", multipartFormDataContent).ContinueWith(x => x.Result.EnsureSuccessStatusCode());
//			var lTask= _client.GetAsync("api/2.0/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/workbooks/1df2bf4c-df65-43df-a2c1-bd404a218dc6/connections"));
			await loginTask;
			return loginTask.Result;
		}
	}


	/// <summary>
	/// Encrypts password using RSA algorithm with public key (modulus and exponent)
	/// </summary>
	/// <param name="modulus"></param>
	/// <param name="exponent"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	private string EncryptPassword(string modulus, string exponent, string password)
	{
		var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
		var parameters = new RSAParameters();
		parameters.Modulus = ToByteArrayBE(BigInteger.Parse(modulus, System.Globalization.NumberStyles.HexNumber));
		parameters.Exponent = ToByteArrayBE(BigInteger.Parse(exponent, System.Globalization.NumberStyles.HexNumber));
		rsaCryptoServiceProvider.ImportParameters(parameters);
		var encryptedByteArray = rsaCryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(password), false);
		return BitConverter.ToString(encryptedByteArray).Replace("-", "").ToLower();
	}


	/// <summary>
	/// Dispose http client
	/// </summary>
	public void Dispose()
	{
		if (_client != null)
		{
			_client.Dispose();
		}
	}


	/// <summary>
	/// Converts BigInteger to Big-endian byte array
	/// </summary>
	/// <param name="b"></param>
	/// <returns></returns>
	public static byte[] ToByteArrayBE(BigInteger b)
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
}

async Task Main()
{
	string url = "https://tableau.cba/";
	string user = @"au\samtran";
	string password = "Raymond123";
//	using (var rs = new TableauRestService("url", "user", "pwd"))
//	{
//		var r1 = await rs.GetResource("users.xml"); //Just to make sure we can do auth correctly for GETs.
//		System.Console.WriteLine(r1.ToString());
//
//		FileInfo fi = new FileInfo(@"path_to_twbfile.twb");
//		string fileName = fi.Name;
//		byte[] fileContents = File.ReadAllBytes(fi.FullName);
//
//	 
//	}


//	string url = "https://tableau.cba/";
//	string user = @"au\samtran";
//	string password = "Raymond123";
	using (var rs = new TableauRestService(url, user, password))
	{
		var r1 = await rs.GetResource("api/2.0/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/workbooks/1df2bf4c-df65-43df-a2c1-bd404a218dc6/connections");
		r1.Dump();
		var r2 = await rs.GetResource("views.xml");
		r2.Dump();
	}

}

// Define other methods and classes here