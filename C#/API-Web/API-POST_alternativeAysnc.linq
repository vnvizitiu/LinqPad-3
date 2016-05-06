<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>CommonSerializer.Newtonsoft.Json</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
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
	var request = HttpWebRequest.Create("http://localhost:56851/api/user/AddUser") as HttpWebRequest;
	request.Method = "POST";
	request.ContentType = "text/json";
	request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
}

private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
{
	HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
	// End the stream request operation

	Stream postStream = request.EndGetRequestStream(asynchronousResult);


	// Create the post data

	string postData = new JavaScriptSerializer().Serialize(new
	{
		ID = 500,
		FirstName = "Aysnc",
		LastName = "Call",
		Company = "Commonwealth Bankk",
		PhoneNo = "8888"

	});



//	string postData = JsonConvert.SerializeObject(json).ToString();
//	postData.Dump();

	byte[] byteArray = Encoding.UTF8.GetBytes(postData);


	postStream.Write(byteArray, 0, byteArray.Length);
	postStream.Close();

	//Start the web request
	request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);
}

void GetResponceStreamCallback(IAsyncResult callbackResult)
{
	try
	{
		HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
		HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
		using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
		{
			string result = httpWebStreamReader.ReadToEnd();
			///stat.Text = result;
			response.Dump();
			Console.WriteLine(response);
		}
	}
	catch (Exception ex)
	{
		
		 Console.WriteLine(ex.ToString());
	}

}
 

string json = new JavaScriptSerializer().Serialize(new
{
	ID = 500,
	FirstName = "Alternative",
	LastName = "Call",
	Company = "Commonwealth Bankk",
	PhoneNo = "8888"

});