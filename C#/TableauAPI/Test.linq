<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

//https://community.tableau.com/thread/151260
static void Main()  
        {  
            System.Console.WriteLine("Getting started...");  
            System.Console.WriteLine();  
  
  
            //Create XML payload for the api call.  
            using (XmlWriter loginxml = XmlWriter.Create("login.xml"))  
            {  
                loginxml.WriteStartDocument();  
                loginxml.WriteStartElement("tsRequest");  
                loginxml.WriteStartElement("credentials");  
                loginxml.WriteAttributeString("name", "samtran");  
                loginxml.WriteAttributeString("password", "Raymond123");  
                loginxml.WriteStartElement("site");  
//                loginxml.WriteAttributeString("contentUrl", "t/smg-poc");  
				loginxml.WriteAttributeString("contentUrl", "WMFinCentre");  
                loginxml.WriteEndElement();  
                loginxml.WriteEndElement();  
                loginxml.WriteEndElement();  
                loginxml.WriteEndDocument();  
            }  
            XElement myxml = XElement.Load("login.xml");  
  
  
            //Convert the XML payload to a string and display so we can check that it's well-formed  
            string myxmlstring = myxml.ToString();  
            System.Console.WriteLine(myxmlstring);  
            System.Console.WriteLine();  
  
  
            //send payload to routine to make the web request  
            var response = LoginToTableau(myxmlstring);  
 
			//response.Dump();
  			GetUers(response);
  
            //display the response from the web request  
            System.Console.WriteLine(response);  
		 
  
  
             
        }  
        static string LoginToTableau(string xml)  
        {  
            //Is this the correct url we should be sending the web request to?  
            string urltl = "https://tableau.cba/api/2.2/auth/signin";
	//string urltl="https://tableau.cba/#/site/WMFinCentre/views/CIExpenseTableauReportDec2015/ReportingbyLineItem?:iid=1";
  
  
            //Send the above url, the POST method, and the XML Payload string to create the web request  
            var infotl = SendWebRequest(urltl, "POST", xml);  
  
  
            return infotl;  
        }  
        static string SendWebRequest(string Url, string Method, string payload)  
        {  
  
  
            string response;  
  
  
            //encode the XML payload  
            byte[] buf = Encoding.UTF8.GetBytes(payload);  
  
  
            //set the system to ignore certificate errors because Tableau server has an invalid cert.  
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);  
  
  
            //Create the web request and add the XML payload  
            HttpWebRequest wc = WebRequest.Create(Url) as HttpWebRequest;  
            wc.Method = Method;  
            wc.ContentType = "text/xml";  
            wc.ContentLength = buf.Length;  
            wc.GetRequestStream().Write(buf, 0, buf.Length);


	try
	{
		//Send the web request and parse the response into a string  
		HttpWebResponse wr = wc.GetResponse() as HttpWebResponse;
		Stream receiveStream = wr.GetResponseStream();
		StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
		response = readStream.ReadToEnd();


		receiveStream.Close();
		readStream.Close();
		wr.Close();


		readStream.Dispose();
		receiveStream.Dispose();
	}
	catch (WebException we)
	{
		//Catch failed request and return the response code  
		response = ((HttpWebResponse)we.Response).StatusCode.ToString();
		we.Dump();
	}
	return response;


}


static void GetUers(string response)
{
	response.Dump();
    
	HttpClient client = new HttpClient();    

	//Call HttpClient.GetAsync to send a GET request to the appropriate URI   
	client.BaseAddress = new Uri("https://tableau.cba/");

	HttpResponseMessage resp = client.GetAsync("api/2.2/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/users/").Result;

	//This method throws an exception if the HTTP response status is an error code.  

	resp.EnsureSuccessStatusCode();


//	var books = resp.Content.ReadAsAsync<IEnumerable<Book>>().Result;
//	books.Dump();
//	// var books = resp.Content.ReadAsAsync<IEnumerable<SelfHost1.book>>().Result;  
//
//	foreach (var p in books)
//
//	{
//
//		Console.WriteLine("{0} {1} {2} )", p.Name, p.Category, p.Price);
//
//
//	}
}
