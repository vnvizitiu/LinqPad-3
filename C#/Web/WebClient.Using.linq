<Query Kind="Program">
  <Namespace>System.Linq.Expressions</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{//http://stackoverflow.com/questions/16642196/get-html-code-from-a-website-c-sharp
//http://stackoverflow.com/questions/16642196/get-html-code-from-a-website-c-sharp
	using (WebClient client = new WebClient())
	{
		    string htmlCode = client.DownloadString("http://localhost:2273/TestPage.aspx");
			Console.WriteLine(htmlCode);
			
	}
}

// Define other methods and classes here
