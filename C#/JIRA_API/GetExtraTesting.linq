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
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main() //assignee = currentUser() OR component = PAPA  and sprint in("All")
///project = BIDA and Sprint in(closedSprints(),futureSprints(),openSprints()) and timespent>0 or timespent is EMPTY and project = BIDA
//project = BIDA AND timespent>0  and Sprint in(closedSprints(),futureSprints(),openSprints()) or timespent is EMPTY and project = BIDA 
//project = BIDA AND timespent>0  and Sprint in(closedSprints(),futureSprints(),openSprints()) or timespent is EMPTY and project = BIDA and issuekey in(issueHistory()) and component in("Continuous Improvement")
{
	var myProgram= new Program();
	//project = BIDA AND resolution = Unresolved AND status in (Open, Reopened, Resolved, Closed) AND assignee in (membersOf(jira-users)) ORDER BY updatedDate DESC
	
	String[] foos = new String[] {@"project = BIDA AND timespent>0  and Sprint in(closedSprints(),futureSprints(),openSprints()) or timespent is EMPTY and project = BIDA and issuekey in(issueHistory()) "}; 
	//String[] foos = new String[] { "Foo1", "Foo2", "Foo3" };
	
	myProgram.MainPro(foos);
}
public class Program
{
	public  void MainPro(string[] args)
	{
		Console.WriteLine("Hello and welcome to a Jira Example application! This is the JQL we'll be running:"+ args[0]);
		#region Create manager-Private
		//   Console.Write("Username: ");
		string username = "samtran";

		//   Console.Write("Password: ");
		string password = "Sydney123";// Console.ReadLine();

		JiraManager manager = new JiraManager(username, password);
		#endregion
		List<ProjectDescription> projects = manager.GetProjects();
		Console.WriteLine("Select a project: ");
		for (int i = 0; i < projects.Count; i++)
		{
			Console.WriteLine("{0}: {1}", i, projects[i].Name);
		}
		Console.WriteLine("===============================");
		Console.WriteLine("Project to open:BIDA ");
		string projectStringIndex ="223";//"216";// Console.ReadLine(); this could change and throw exception
		//string projectStringIndex ="231";// Console.ReadLine();
		int projectIndex = 0;
		if (!int.TryParse(projectStringIndex, out projectIndex))
		{
			Console.WriteLine("You failed to select a project...");
			Environment.Exit(0);
		}

		ProjectDescription selectedProject = projects[projectIndex];
		string projectKey = selectedProject.Key;

		//string jql = "project = " + projectKey; //original 
		string jql=args[0];
		List<Issue> issueDescriptions = manager.GetIssues(jql);
		foreach (Issue description in issueDescriptions)
		{
			Console.WriteLine("{0}: {1}", description.Key, description.Fields.Summary);
     	}

	}
}
public class JiraManager
{
	private const string m_BaseUrl = "https://jira.odp.cba/rest/api/latest/";
	private string m_Username;
	private string m_Password;

	public JiraManager(string username, string password)
	{
		m_Username = username;
		m_Password = password;
	}

	/// <summary>
	/// Runs a query towards the JIRA REST api
	/// </summary>
	/// <param name="resource">The kind of resource to ask for</param>
	/// <param name="argument">Any argument that needs to be passed, such as a project key</param>
	/// <param name="data">More advanced data sent in POST requests</param>
	/// <param name="method">Either GET or POST</param>
	/// <returns></returns>
	protected string RunQuery(
		JiraResource resource,
		string argument = null,
		string data = null,
		string method = "GET")
	{
		string url = string.Format("{0}{1}/", m_BaseUrl, resource.ToString());

		if (argument != null)
		{
			url = string.Format("{0}{1}/", url, argument);
		}
		url=url+"?expand=enderedFields";
	 
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

		return result;
	}

	public List<ProjectDescription> GetProjects()
	{
		List<ProjectDescription> projects = new List<ProjectDescription>();
		string projectsString = RunQuery(JiraResource.project);

		return JsonConvert.DeserializeObject<List<ProjectDescription>>(projectsString);
	}

	public List<Issue> GetIssues(
		string jql,
		List<string> fields = null,
		int startAt = 0,
	//	string expand= @"issues",
		int maxResult = 1000)
	{
		fields = fields ?? new List<string> { "summary", "status", "assignee" };

		SearchRequest request = new SearchRequest();
		request.Fields = fields;
		request.JQL = jql;
		request.MaxResults = maxResult;
		request.StartAt = startAt;
		//request.expand=expand;
	 
	

		string data = JsonConvert.SerializeObject(request);
		string result = RunQuery(JiraResource.search, data: data, method: "POST");

		SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(result);

		return response.IssueDescriptions;
	}

	private string GetEncodedCredentials()
	{
		string mergedCredentials = string.Format("{0}:{1}", m_Username, m_Password);
		byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
		return Convert.ToBase64String(byteCredentials);
	}
}


/// <summary>
/// An enumeration representing the various resources that can
/// be used in a JIRA REST request
/// </summary>
public enum JiraResource
{
	project,
	search
}

/// <summary>
/// A class representing a JIRA REST search request
/// </summary>
public class SearchRequest
{
	[JsonProperty("jql")]
	public string JQL { get; set; }

	[JsonProperty("expand")]
	public string expand { get; set; }

	[JsonProperty("startAt")]
	public int StartAt { get; set; }

	[JsonProperty("maxResults")]
	public int MaxResults { get; set; }

	[JsonProperty("fields")]
	public List<string> Fields { get; set; }

	public SearchRequest()
	{
		Fields = new List<string>();
	}
}
/// <summary>
/// A class representing a JIRA REST search response
/// </summary>
public class SearchResponse
{
	[JsonProperty("startAt")]
	public int StartAt { get; set; }

	[JsonProperty("maxResults")]
	public int MaxResults { get; set; }

	[JsonProperty("total")]
	public int Total { get; set; }

	[JsonProperty("issues")]
	public List<Issue> IssueDescriptions { get; set; }
}
/// <summary>
/// A class representing a project descriptin in JIRA
/// </summary>
public class ProjectDescription : BaseEntity
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("key")]
	public string Key { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("avatarUrls")]
	public AvatarUrls AvatarUrls { get; set; }
}
/// <summary>
/// A class representing a JIRA issue
/// </summary>
public class Issue : BaseEntity
{
	private string m_KeyString;
	[JsonProperty("expand")]
	public string Expand { get; set; }
	[JsonProperty("id")]
   public int Id { get; set; }
	#region Special key solution
	[JsonProperty("key")]
	public string ProxyKey
	{
		get
		{
			return Key.ToString();
		}
		set
		{
			m_KeyString = value;
		}
	}

	[JsonIgnore]
	public IssueKey Key
	{
		get
		{
			return IssueKey.Parse(m_KeyString);
		}
	}
	#endregion Special key solution
	[JsonProperty("fields")]
	public Fields Fields { get; set; }
}

public class BaseEntity
{
	[JsonProperty("self")]
	public string Self { get; set; }
}
/// <summary>
/// A class representing a JIRA issue key [PROJECT KEY]-[ISSUE ID]
/// </summary>
public class IssueKey
{
	public string ProjectKey { get; set; }
	public int IssueId { get; set; }
	public IssueKey() { }
	public IssueKey(string projectKey, int issueId)
	{
		ProjectKey = projectKey;
		IssueId = issueId;
	}

	public static IssueKey Parse(string issueKeyString)
	{
		if (issueKeyString == null)
		{
			throw new ArgumentNullException("IssueKeyString is null!");
		}

		string[] split = issueKeyString.Split('-');

		if (split.Length != 2)
		{
			throw new ArgumentException("The string entered is not a JIRA key!");
		}

		int issueId = 0;
		if (!int.TryParse(split[1], out issueId))
		{
			throw new ArgumentException("The string entered could not be parsed, issue id is non-integer!");
		}

		return new IssueKey(split[0], issueId);
	}

	public override string ToString()
	{
		return string.Format("{0}-{1}", ProjectKey, IssueId);
	}
}
/// <summary>
/// Represents a Fields JSON object
/// </summary>
/// <remarks>
/// "fields" : {
///	    "summary" : "Some summary",
///	    "status" : {
///	    	...
///	    },
///	    "assignee" : {
///	    	...
///	    }
/// }    
/// </remarks>
public class Fields
{
	[JsonProperty("summary")]
	public string Summary { get; set; }

	[JsonProperty("status")]
	public Status Status { get; set; }

	[JsonProperty("assignee")]
	public Assignee Assignee { get; set; }
}
 /// <summary>
	/// Represents a Status JSON object
	/// </summary>
	/// <remarks>
	/// "status" : {
	///     "self" : "http://localhost.:8080/rest/api/2/status/5",
	///     "description" : "A resolution has been taken, and it is awaiting verification by reporter. From here issues are either reopened, or are closed.",
	///     "iconUrl" : "http://localhost.:8080/images/icons/status_resolved.gif",
	///     "name" : "Resolved",
	///     "id" : "5"
	/// }
	/// </remarks>
	public class Status : BaseEntity
	{
		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("iconUrl")]
		public string IconUrl { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }
	}
/// <summary>
/// Represents an assignee JSON object
/// </summary>
/// <remarks>
/// "assignee" : {
///	    "self" : "http://localhost.:8080/rest/api/2/user?username=adm",
///	    "name" : "adm",
///	    "emailAddress" : "foo@bar.com",
///	    "avatarUrls" : {
///	    	"16x16" : "http://localhost.:8080/secure/useravatar?size=small&avatarId=10122",
///	    	"48x48" : "http://localhost.:8080/secure/useravatar?avatarId=10122"
/// }    
/// </remarks>
public class Assignee : BaseEntity
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("emailAddress")]
	public string EmailAddress { get; set; }

	[JsonProperty("avatarUrls")]
	public AvatarUrls AvatarUrls { get; set; }

	[JsonProperty("displayName")]
	public string DisplayName { get; set; }

	[JsonProperty("active")]
	public bool Active { get; set; }
}
/// <summary>
/// Represents an avatarUrl JSON object
/// </summary>
/// <remarks>
/// "avatarUrls": {
///     "16x16": "http://www.example.com/jira/secure/useravatar?size=small&ownerId=fred",
///     "48x48": "http://www.example.com/jira/secure/useravatar?size=large&ownerId=fred"
/// }
/// </remarks>
public class AvatarUrls
{
	[JsonProperty("16x16")]
	public string Size16 { get; set; }

	[JsonProperty("48x48")]
	public string Size48 { get; set; }
}