<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	//...
	using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
	{	
		string mysource="http://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp";
		string mydest=@"C:\Users\samtran\OneDrive\Documents\LinqPad_Queries\InputOutput_Files\downloaded.html";
		client.DownloadFile(mysource,mydest);
		File.Open(mydest,FileMode.Open);

		// Or you can get the file content without saving it:
		//string htmlCode = client.DownloadString("http://yoursite.com/page.html");
		//...
	}
}

// Define other methods and classes here
