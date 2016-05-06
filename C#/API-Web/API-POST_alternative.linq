<Query Kind="Program">
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
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main()
{
	PostForm();	//http://stackoverflow.com/questions/9145667/how-to-post-json-to-the-server
	//Need to have solution WebAPIDemo site running
	//C:\Download_Codes\API_ExampleWithNeeded_DLL
	//C:\Download_Codes\API_ExampleWithNeeded_DLL\WebAPIDemo
	
}

private void PostForm()
{
	// create a request
	HttpWebRequest request = (HttpWebRequest)
//	WebRequest.Create(url); request.KeepAlive = false;   //http://localhost:56851/api/user/AddUser
	WebRequest.Create("http://localhost:56851/api/user/AddUser"); request.KeepAlive = false; 
	request.ProtocolVersion = HttpVersion.Version10;
	request.Method = "POST";

	//string json="";

	string json = new JavaScriptSerializer().Serialize(new
	{
		ID = 500,
		FirstName = "Alternative",
		LastName = "Call",
		Company = "Commonwealth Bankk",
		PhoneNo = "8888"

	});
	
	json.Dump();

	// turn our request string into a byte stream
	byte[] postBytes = Encoding.UTF8.GetBytes(json);

	// this is important - make sure you specify type this way
	request.ContentType = "application/json; charset=UTF-8";
	request.Accept = "application/json";
	request.ContentLength = postBytes.Length;
//	request.CookieContainer = Cookies;
//	request.UserAgent = currentUserAgent;
	Stream requestStream = request.GetRequestStream();

	// now send it
	requestStream.Write(postBytes, 0, postBytes.Length);
	requestStream.Close();

	// grab te response and print it out to the console along with the status code
	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
	string result;
	using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
	{
		result = rdr.ReadToEnd();
	}
	
	result.Dump();
	//return result;
}

