<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

//https://community.tableau.com/thread/151260
//http://stackoverflow.com/questions/3273205/read-text-from-response
//https://onlinehelp.tableau.com/current/api/rest_api/en-us/help.htm#REST/rest_api_concepts_auth.htm%3FTocPath%3DConcepts%7C_____3 
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
	string urltl = "https://tableau.cba/api/api-version/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/users/";
 
	//791f4c7a-6452-4422-9e5a-78fbde52c89f


	//encode the XML payload  
	byte[] buf = Encoding.UTF8.GetBytes(payload);



	//set the system to ignore certificate errors because Tableau server has an invalid cert.  
	System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);


	//Create the web request and add the XML payload  
	HttpWebRequest wc = WebRequest.Create(Url) as HttpWebRequest;
	wc.Method = "GET";
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