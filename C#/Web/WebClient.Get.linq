<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

public static class Test //The following code example takes the URI of a resource, retrieves it, and displays the response.
{ //http://stackoverflow.com/questions/16642196/get-html-code-from-a-website-c-sharp
	public static void MainTake(string[] args)
	{
		if (args == null || args.Length == 0)
		{
			throw new ApplicationException("Specify the URI of the resource to retrieve.");
		}
		WebClient client = new WebClient();

		// Add a user agent header in case the 
		// requested URI contains a query.

		client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

		Stream data = client.OpenRead(args[0]);
		StreamReader reader = new StreamReader(data);
		string s = reader.ReadToEnd();
		Console.WriteLine(s);
		data.Close();
		reader.Close();
	}
}
void Main()
{	
	var arrayA = new[] { "http://localhost:2273/HtmlPage.html"};
	var arrayB = new[] { "http://stackoverflow.com/questions/16642196/get-html-code-from-a-website-c-sharp","http://localhost/"};
	 Test.MainTake(arrayA);
}
