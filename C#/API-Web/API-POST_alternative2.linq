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
	var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56851/api/user/AddUser");
	httpWebRequest.ContentType = "application/json";
	httpWebRequest.Method = "POST";

	using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
	{
		string json = new JavaScriptSerializer().Serialize(new
		{
			ID = 500,
			FirstName = "yyy",
			LastName = "Call",
			Company = "Commonwealth Bankk",
			PhoneNo = "8888"

		});


		streamWriter.Write(json);
		streamWriter.Flush();
		streamWriter.Close();
	}

	var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
	using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
	{
		var result = streamReader.ReadToEnd();
		result.Dump();
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