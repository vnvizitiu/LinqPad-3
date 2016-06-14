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
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

//http://maffelu.net/jira-basic-cjira-connection-using-rest/
public enum JiraResource
{
    project
}

public class JiraManager
{
	////https://jira.odp.cba/rest/api/2/component/15142
	private const string m_BaseUrl = "https://jira.odp.cba/rest/api/2/";//https://jira.odp.cba
	//private const string m_BaseUrl ="https://jira.odp.cba/rest/api/latest/search?jql=issuekey%20in%20issueHistory()%20ORDER%20BY%20lastViewed%20DESC";
	private string m_Username;
	private string m_Password;

	public JiraManager(string username, string password)
	{
		m_Username = username;
		m_Password = password;
	}

	public void RunQuery(
		JiraResource resource,
		string argument = null,
		string data = null,
		string method = "GET")
	{
	//	string url = string.Format("{0}{1}/", m_BaseUrl, resource.ToString());
		string url = string.Format("{0}{1}/", m_BaseUrl, "component/15142");

		if (argument != null)
		{
			url = string.Format("{0}{1}/", url, argument);
		}

		HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
		request.ContentType = "application/json";
		request.Method = method;

		if (data != null)
		{
			using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
			{
				writer.Write(data);
			}
		}

		string base64Credentials = GetEncodedCredentials();
		request.Headers.Add("Authorization", "Basic " + base64Credentials);

		HttpWebResponse response = request.GetResponse() as HttpWebResponse;

       string result = string.Empty;
	    
		 
		using (StreamReader reader = new StreamReader(response.GetResponseStream()))
		{
			result = reader.ReadToEnd();
		}

		// Console.WriteLine(result);
		 Console.WriteLine(result.GetType());
		//	 Rootobject myClasses=new JavaScriptSerializer().Deserialize<Rootobject>(result);
		//   Rootobject myclasses = JsonConvert.DeserializeObject<Rootobject>(result);

		//var myList =JsonConvert.DeserializeObject<List<Component>>(result);
		
		var myObj=JsonConvert.DeserializeObject<Component>(result);
		//http://stackoverflow.com/questions/22557559/cannot-deserialize-the-json-array-e-g-1-2-3-into-type-because-type-requ
		 
	 
		myObj.Dump();
		 
	}

	private string GetEncodedCredentials()
	{
		string mergedCredentials = string.Format("{0}:{1}", m_Username, m_Password);
		byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
		return Convert.ToBase64String(byteCredentials);
	}
}


class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to JIRA in BIDA!");

		 
		string username ="samtran";

	 
		string password = "Hotdog88";

		JiraManager manager = new JiraManager(username, password);
		manager.RunQuery(JiraResource.project);

		 
	}
}
public class Component
{
	public string self { get; set; }
	public string id { get; set; }
	public string name { get; set; }
	public string description { get; set; }
	public string assigneeType { get; set; }
	public string realAssigneeType { get; set; }
	public bool isAssigneeTypeValid { get; set; }
}

