<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

//http://maffelu.net/jira-basic-cjira-connection-using-rest/
public enum JiraResource
{
    project
}

public class JiraManager
{
	//private const string m_BaseUrl = "http://localhost.:8080/rest/api/latest/";
	private const string m_BaseUrl = "https://jira.odp.cba/rest/api/latest/";//https://jira.odp.cba
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
		string url = string.Format("{0}{1}/", m_BaseUrl, resource.ToString());

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

		//Console.WriteLine(result);
		
		foreach (var element in result)
		{
			Console.WriteLine(element);
		}
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

public class Rootobject
{
	public Class1[] Property1 { get; set; }
}

public class Class1
{
	public string self { get; set; }
	public string id { get; set; }
	public string key { get; set; }
	public string name { get; set; }
	public Avatarurls avatarUrls { get; set; }
	public Projectcategory projectCategory { get; set; }
}

public class Avatarurls
{
	public string _16x16 { get; set; }
	public string _24x24 { get; set; }
	public string _32x32 { get; set; }
	public string _48x48 { get; set; }
}

public class Projectcategory
{
	public string self { get; set; }
	public string id { get; set; }
	public string description { get; set; }
	public string name { get; set; }
}
