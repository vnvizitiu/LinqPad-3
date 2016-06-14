<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>C:\Download_Codes\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

///https://msdn.microsoft.com/en-us/library/office/dn567668.aspx
//http://stackoverflow.com/questions/11243911/ews-body-plain-text
//https://msdn.microsoft.com/en-us/library/office/dn535506(v=exchg.150).aspx

  class Program
  {
	static void Main(string[] args)
	{
		ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
#region private
		service.Credentials = new WebCredentials("samtran@cbainet.com", "Hotdog88");
#endregion 
		service.TraceEnabled = true;
		service.TraceFlags = TraceFlags.All;

		service.AutodiscoverUrl("samtran@colonialfirststate.com.au", RedirectionUrlValidationCallback);
	 
		// Bind the Inbox folder to the service object.
		Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);

		// The search filter to get unread email.
		SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
		ItemView view = new ItemView(1);


		PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
		itempropertyset.RequestedBodyType = BodyType.Text;
		ItemView itemview = new ItemView(1000);
		itemview.PropertySet = itempropertyset;

		FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
		Item item = findResults.FirstOrDefault();
		item.Load(itempropertyset);
	 
		Console.WriteLine(item.Body);
		Console.WriteLine(item.Subject);
		Console.WriteLine("Has Attachments: "+ item.HasAttachments);
		Console.WriteLine(item);
		RaiseJira(item.Subject,item.Body);
		
		

	}

	private static bool RedirectionUrlValidationCallback(string redirectionUrl)
	{
		// The default for the validation callback is to reject the URL.
		bool result = false;

		Uri redirectionUri = new Uri(redirectionUrl);

		// Validate the contents of the redirection URL. In this simple validation
		// callback, the redirection URL is considered valid if it is using HTTPS
		// to encrypt the authentication credentials. 
		if (redirectionUri.Scheme == "https")
		{
			result = true;
		}
		return result;
	}
}


public static void RaiseJira(string subject, string body) //http://stackoverflow.com/questions/13974208/creating-jira-issue-via-rest-c-sharp-httpclient
{ //https://answers.atlassian.com/questions/79902/using-httpclient-c-to-create-a-jira-issue-via-rest-generates-bad-request-response
  // string data = @"{""fields"":{""project"":{""key"": ""TEST""},""summary"": ""REST EXAMPLE"",""description"": ""Creating an issue via REST API"",""issuetype"": {""name"": ""Bug""}}}";
  //	string path = @"C:\Download_Codes\JiraExample_Console\JiraExample\JSON_Results\RaiseIssue.json";
	Console.WriteLine("subject: "+ subject + "     body: " +body);

	//string jData = File.ReadAllText(path);

	string jData = @"{""fields"":{""project"":{""key"": ""BIDA""},""summary"": ""Jira raised via REST API-alternative"",
                               ""description"": ""To test if raising JI?A via REST API is possible"",""issuetype"": {""name"": ""Improvement""}}}";
	JavaScriptSerializer json_serializer = new JavaScriptSerializer();
	Issue jsonIssue = json_serializer.Deserialize<Issue>(jData);
	//   (Issue)json_serializer.DeserializeObject(jData);
	//var jsonIssue= JsonConvert.DeserializeObject<T>(json);
	jsonIssue.fields.summary=subject;
	jsonIssue.fields.description=body;
	Console.WriteLine(jsonIssue.fields.summary);
	jsonIssue.Dump();

	// List<test> myDeserializedObjList = (List<test>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request["jsonString"], typeof(List<test>));
	//Issue myDeserializedObj = (Issue)JavaScriptConvert.DeserializeObject(Request["jsonString"], typeof(Test));


	string postUrl = "https://jira.odp.cba/rest/api/latest/";

	System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

	client.BaseAddress = new System.Uri(postUrl);
	#region private
	byte[] cred = UTF8Encoding.UTF8.GetBytes("samtran:Hotdog88");
	#endregion

	client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

	System.Net.Http.Formatting.MediaTypeFormatter jsonFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();

	//System.Net.Http.HttpContent content = new System.Net.Http.ObjectContent<string>(data, jsonFormatter);
	System.Net.Http.HttpContent content = new System.Net.Http.ObjectContent<Issue>(jsonIssue, jsonFormatter);
	// HttpContent content = new ObjectContent<string>(jData, jsonFormatter);
	jData.Dump();
	//HttpContent content = new ObjectContent<string>(data, jsonFormatter);
	System.Net.Http.HttpResponseMessage response = client.PostAsync("issue", content).Result;
	if (response.IsSuccessStatusCode)
	{
		string result = response.Content.ReadAsStringAsync().Result;
		Console.WriteLine(result);
	}
	else
	{

		Console.WriteLine(response.StatusCode.ToString());
	}
}
public class Issue
{
	public Fields fields { get; set; }
}

public class Fields
{
	public Project project { get; set; }
	public string summary { get; set; }
	public string description { get; set; }
	public Issuetype issuetype { get; set; }
}

public class Project
{
	public string key { get; set; }
}

public class Issuetype
{
	public string name { get; set; }
}