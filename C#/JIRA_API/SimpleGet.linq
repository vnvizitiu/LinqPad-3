<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference Relative="..\..\Files\System.Net.Http.Formatting.dll">C:\Linqpad_Queries\Files\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 2\Assemblies\System.Web.Mvc.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ListBook(1026);
}
static void ListBook(int id)
//https://jira.odp.cba/rest/api/latest/issue/162351
        {
	HttpClient client = new HttpClient();
//	client.BaseAddress = new Uri("https://jira.odp.cba/rest/api/latest/");
//https://jira.odp.cba/rest/api/2/component/15142
	string postUrl = "https://jira.odp.cba/rest/api/latest/";
	client.BaseAddress = new System.Uri(postUrl);
	#region private
	byte[] cred = UTF8Encoding.UTF8.GetBytes("samtran:Hotdog88");
	#endregion

	client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

	//	HttpResponseMessage resp = client.GetAsync("api/requests/{10}").Result;
	//var resp = client.GetAsync(string.Format("api/Jobs/{0}", id)).Result;
	var resp = client.GetAsync("issue/162351").Result;
	// resp.Dump();
	Console.WriteLine(resp.Content);
	Console.WriteLine(resp.RequestMessage);

	resp.EnsureSuccessStatusCode();
	

	//System.Net.Http.HttpContent content = new System.Net.Http.ObjectContent<Issue>(jsonIssue, jsonFormatter);
	//System.Net.Http.HttpResponseMessage response = client.PostAsync("issue", content).Result;

//	if (response.IsSuccessStatusCode)
//	{
//		string result = response.Content.ReadAsStringAsync().Result;
//		Console.WriteLine(result);
//	}
//	else
//	{
//
//		Console.WriteLine(response.StatusCode.ToString());
//	}

	//  var book1 = resp.Content.ReadAsAsync<Book>().Result;  

	//   Console.WriteLine("ID {0}: {1}", id, book1.Name);

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