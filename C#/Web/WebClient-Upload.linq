<Query Kind="Program">
  <Namespace>System.Linq.Expressions</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

//http://chiragvidani.blogspot.com.au/2011/10/how-to-uploaddownload-file-tofrom.html
static void Main()
{//http://stackoverflow.com/questions/16642196/get-html-code-from-a-website-c-sharp

//Do();
	Console.Write("\nPlease enter the URI to post data to : ");
//String uriString = Console.ReadLine();
String uriString = "http://localhost/HTML_samtran/";
// Create a new WebClient instance.
WebClient myWebClient = new WebClient();
myWebClient.Credentials = new System.Net.NetworkCredential("samtran", "Fate1972", "DESKTOP-E80R7DQ");
//DESKTOP-E80R7DQ\samtran 

//	Console.WriteLine("\nPlease enter the fully qualified path of the file to be uploaded to the URI");
	//string fileName = Console.ReadLine();
 string fileName = @"C:\Users\samtran\Downloads\Delete\TestDelete\New folder";
	Console.WriteLine("Uploading {0} to {1} ...", fileName, uriString);

	// Upload the file to the URI.
	// The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method.
	byte[] responseArray = myWebClient.UploadFile(uriString, fileName);

	// Decode and display the response.
	Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
		System.Text.Encoding.ASCII.GetString(responseArray));
}

// Define other methods and classes here

static void Do()
{
	System.Net.WebClient webClient = new System.Net.WebClient();
	string sourceFilePath = @"C:\Users\samtran\Downloads\Delete\Test.txt";
	string webAddress = "http://localhost/HTML_samtran/";
	string destinationFilePath = webAddress + "Test.txt";
	webClient.Credentials = new System.Net.NetworkCredential("username", "password", "domain");
	webClient.UploadFile(destinationFilePath, "PUT", sourceFilePath);
	webClient.Dispose();



}

static void DoMore()
{
	System.Net.WebClient webClient = new System.Net.WebClient();
	string webAddress = "http://www.YourDomainName.com/ClientFiles/";
	string sourceFilePath = webAddress + "DataFile.xml";
	string destinationFilePath = @"D:\MyDocuments\DataFile.xml";
	webClient.Credentials = new System.Net.NetworkCredential("username", "password", "domain");
	webClient.DownloadFile(sourceFilePath, destinationFilePath);
	webClient.Dispose();

}