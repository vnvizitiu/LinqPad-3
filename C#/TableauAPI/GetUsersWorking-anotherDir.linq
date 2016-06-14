<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

//http://lakenine.com/reading-xml-with-namespaces-using-linq/
//https://community.tableau.com/thread/151260
//http://stackoverflow.com/questions/3273205/read-text-from-response
//https://onlinehelp.tableau.com/current/api/rest_api/en-us/help.htm#REST/rest_api_concepts_auth.htm%3FTocPath%3DConcepts%7C_____3 
static void Main()  
        {  
            System.Console.WriteLine("Getting started...");  
            System.Console.WriteLine();  
  
#region  
           //Create XML payload for the api call.  
            using (XmlWriter loginxml = XmlWriter.Create(@"C:\LinqPad_Queries\C#\TableauAPI\login.xml"))  
            {  
                loginxml.WriteStartDocument();  
                loginxml.WriteStartElement("tsRequest");  
                loginxml.WriteStartElement("credentials");  
                loginxml.WriteAttributeString("name", "samtran");  
                loginxml.WriteAttributeString("password", "Hotdog88");  
                loginxml.WriteStartElement("site");  
//                loginxml.WriteAttributeString("contentUrl", "t/smg-poc");  
				loginxml.WriteAttributeString("contentUrl", "WMFinCentre");  
                loginxml.WriteEndElement();  
                loginxml.WriteEndElement();  
                loginxml.WriteEndElement();  
                loginxml.WriteEndDocument();  
            }  
            XElement myxml = XElement.Load(@"C:\LinqPad_Queries\C#\TableauAPI\login.xml");  
			Console.WriteLine(myxml.GetType());
  
#endregion  
            //Convert the XML payload to a string and display so we can check that it's well-formed  
            string myxmlstring = myxml.ToString();  
            System.Console.WriteLine(myxmlstring);  
            System.Console.WriteLine();  
  
  
            //send payload to routine to make the web request  
            var response = LoginToTableau(myxmlstring);  
			//response.Dump();
  			GetUers(response);
  
            //display the response from the web request  
         //   System.Console.WriteLine(response);  
		 
  
  
             
        }  
        static System.Xml.Linq.XDocument LoginToTableau(string xml)  
        {  
            //Is this the correct url we should be sending the web request to?  
            string urltl = "https://tableau.cba/api/2.2/auth/signin";
	//string urltl="https://tableau.cba/#/site/WMFinCentre/views/CIExpenseTableauReportDec2015/ReportingbyLineItem?:iid=1";
  
  
            //Send the above url, the POST method, and the XML Payload string to create the web request  
            var infotl = SendWebRequest(urltl, "POST", xml);  
  
  
            return infotl;  
        }  
        static System.Xml.Linq.XDocument SendWebRequest(string Url, string Method, string payload)  
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

	XDocument doc;
	try
	{
		//Send the web request and parse the response into a string  
		HttpWebResponse wr = wc.GetResponse() as HttpWebResponse;
		Stream receiveStream = wr.GetResponseStream();
		StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);


		
		doc = XDocument.Load(receiveStream);
		
 
		// Now do whatever you want with doc here
		Console.WriteLine(doc);
	
		response = readStream.ReadToEnd();

		receiveStream.Close();
		readStream.Close();
		wr.Close();

		readStream.Dispose();
		receiveStream.Dispose();
		return doc;
		
	}
	catch (WebException we)
	{
		//Catch failed request and return the response code  
		response = ((HttpWebResponse)we.Response).StatusCode.ToString();
		we.Dump();
		return null;
	}
	//return response;
	 
	


}


static void GetUers(System.Xml.Linq.XDocument response)
{
	//Is this the correct url we should be sending the web request to?  
	//string urltl = "https://tableau.cba/api/2.2/auth/signin";
	string PostURL="https://tableau.cba/api/2.2/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/users/ ";
	//string urltl="https://tableau.cba/#/site/WMFinCentre/views/CIExpenseTableauReportDec2015/ReportingbyLineItem?:iid=1";

	//	string ResponseString = response.ToString();
	//Send the above url, the POST method, and the XML Payload string to create the web request  

 	string testcredential="xxxx";

	var userNode = response.Descendants().FirstOrDefault();

	Console.WriteLine(userNode.GetType());

	Console.WriteLine(response.GetType());
	//	XDocument xdoc=response.Document;
	Console.WriteLine("BEGIN.....................");
	
 

	foreach (XNode node in response.DescendantNodes())
	{
		if (node is XElement)
		{
			XElement elementx = (XElement)node;
			if (elementx.Name.LocalName.Equals("tsResponse"))
			{

				XDocument xDoc = XDocument.Load(elementx.CreateReader());
				Console.WriteLine(xDoc.GetType());

				var lv1s = xDoc.Root.Descendants();

				var lvs = lv1s.Select(l =>
				new string []{ l.Attribute("token").Value});
				 
				 Console.WriteLine(lvs.FirstOrDefault());
				 
				 var credentials=lvs.First();
				 Console.WriteLine(credentials);
				 
		         testcredential=credentials[0].ToString();
				 Console.WriteLine(testcredential.ToString());
				 break;
				


			
			}
		}
	}





 Console.WriteLine(testcredential.ToString());


 


	//set the system to ignore certificate errors because Tableau server has an invalid cert.  
		System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);


	//Create the web request and add the XML payload  
	HttpWebRequest wc = WebRequest.Create(PostURL) as HttpWebRequest;
	wc.Headers.Add("X-Tableau-Auth", testcredential);

	wc.Method = "GET";
	wc.ContentType = "text/xml";
	//	wc.ContentLength = buf.Length;
	//	wc.GetRequestStream().Write(buf, 0, buf.Length);

	XDocument doc;
	try
	{
		//Send the web request and parse the response into a string  
		HttpWebResponse wr = wc.GetResponse() as HttpWebResponse;
		Stream receiveStream = wr.GetResponseStream();
		StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);



		//doc = XDocument.Load(receiveStream);
		XElement xxElement =XElement.Load(receiveStream);

		// Now do whatever you want with doc here
		Console.WriteLine(xxElement);

		xxElement.Dump();
		var h = xxElement.Descendants().Where(e => e.Name.LocalName == "user"); //http://stackoverflow.com/questions/7227193/xelement-descendants-doesnt-work-with-namespace
		h.Dump();
		
		var _users=new List<tsResponseUser>();
		
		foreach (var element in h)
		{
			Console.WriteLine(element.Attribute("id").Value + "__" + element.Attribute("name").Value);
			tsResponseUser user = new tsResponseUser
			{
				id = element.Attribute("id").Value,
				name = element.Attribute("name").Value,
				siteRole = element.Attribute("siteRole").Value
				
				 //lastLogin=element.Attribute("lastLogin").Value
				 };
				_users.Add(user);	
			
		}

		_users.Dump();





		//		response = readStream.ReadToEnd();


		receiveStream.Close();
		readStream.Close();
		wr.Close();


		readStream.Dispose();
		receiveStream.Dispose();


	}
	catch (WebException ex)
	{
		ex.Dump();
	}
}
static DataTable ParseXML(string xmlString)
{
	DataSet ds = new DataSet();
	byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
	Stream memory = new MemoryStream(xmlBytes);
	ds.ReadXml(memory);
	return ds.Tables[0];
}
 
public partial class tsResponseUser
{

	private string idField;

	private string nameField;

	private string siteRoleField;

	private string  lastLoginField;

	private bool lastLoginFieldSpecified;

	private string externalAuthUserIdField;

	/// <remarks/>
	//	[XmlElement("id", Namespace = "http://tableau.com/api")]

	//[XmlAttribute("id")]
	public string id
	{
		get
		{
			return this.idField;
		}
		set
		{
			this.idField = value;
		}
	}

	/// <remarks/>
 
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string name
	{
		get
		{
			return this.nameField;
		}
		set
		{
			this.nameField = value;
		}
	}

	/// <remarks/>
 
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string siteRole
	{
		get
		{
			return this.siteRoleField;
		}
		set
		{
			this.siteRoleField = value;
		}
	}

	/// <remarks/>
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
 
	public string  lastLogin
	{
		get
		{
			return this.lastLoginField;
		}
		set
		{
			this.lastLoginField = value;
		}
	}

 
	public bool lastLoginSpecified
	{
		get
		{
			return this.lastLoginFieldSpecified;
		}
		set
		{
			this.lastLoginFieldSpecified = value;
		}
	}

	/// <remarks/>
	//[System.Xml.Serialization.XmlAttributeAttribute()]
 
	public string externalAuthUserId
	{
		get
		{
			return this.externalAuthUserIdField;
		}
		set
		{
			this.externalAuthUserIdField = value;
		}
	}
}