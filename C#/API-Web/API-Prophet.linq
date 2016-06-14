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
	//var request = (HttpWebRequest)WebRequest.Create("http://n03fwt0w6250.s4.chp.cba/idr");
    var request = (HttpWebRequest)WebRequest.Create("http://n03fwt0w6250.s4.chp.cba/idr/api/Jobs?JobName=CBAjobs&PRDPrefix=CBAjobs&JobCollectionName=PL&ReportingCycleName=Q1 - 2015");

	request.ContentType = "application/json";
	request.Method = "POST";

	using (var streamWriter = new StreamWriter(request.GetRequestStream()))
	{

		string json = "/api/Jobs?JobName=CBAjobs&PRDPrefix=CBAjobs&JobCollectionName=PL&ReportingCycleName = Q1 - 2015";

		streamWriter.Write(json);
	}

	var response = (HttpWebResponse)request.GetResponse();
	response.Dump();
	using (var streamReader = new StreamReader(response.GetResponseStream()))
	{
		var result = streamReader.ReadToEnd();
		result.Dump();
	}
}