<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

void Main() //http://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp
{//// in LINQPad, also add a reference to System.Net.Http.dll
//https://msdn.microsoft.com/en-us/library/system.net.webclient.aspx

	//WebRequest req = HttpWebRequest.Create("http://google.com");
	WebRequest req = HttpWebRequest.Create("http://localhost:2273/HtmlPage.html");
	req.Method = "GET";

	string source;
	using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
	{
		source = reader.ReadToEnd();
	}

	Console.WriteLine(source);
}

// Define other methods and classes here
