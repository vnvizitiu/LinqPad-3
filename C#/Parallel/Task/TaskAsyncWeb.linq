<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static void Main(string[] args) //pag 39 Pro Asynchronous Programming
{
 	Task<string> downloadTask = DownloadWebPageAsync("https://www.facebook.com/");
while (!downloadTask.IsCompleted)
	{
		Console.Write(".............SAM............................................");
		Thread.Sleep(750);
	}
	Console.WriteLine(downloadTask.Result);
	Console.WriteLine("SAM THIS IS BETTER");
	Console.WriteLine("SAM THIS IS BETTER");
		
	better();
}
private static string DownloadWebPage(string url)
{
	System.Net.WebRequest request = WebRequest.Create(url);
	WebResponse response = request.GetResponse();
	var reader = new StreamReader(response.GetResponseStream());
	{
		// this will return the content of the web page
		return reader.ReadToEnd();
	}
}
private static Task<string> DownloadWebPageAsync(string url)
{
	return Task.Factory.StartNew(() => DownloadWebPage(url));
}

//The IsCompleted property on the task allows you to determine if the asynchronous operation has completed.//While it is still completing, the task keeps the user happy by displaying dots; once it completes, you request the result
//of the task.Since you know the task has now completed, the result will immediately be displayed to the user.//This all looks good until you start to analyze the cost of achieving this asynchronous operation. In effect you now
//have two threads running for the duration of the download: the one running inside Main and the one attempting to get//the response from the web site.The thread responsible for getting the content is spending most of its time blocked on
//the line reader.ReadToEnd(); you have taken a thread from the thread pool, denying others the chance to use it, only//for it to spend most of the time idle.
//A far more efficient approach would be to create a thread to request the data from the web server, give the thread//back to the thread pool, and when the data arrives, obtain a thread from the pool to process the results.To achieve this
//prior to.NET 4.5, the I / O methods in the library use the APM idiom seen in Chapter 2://public virtual IAsyncResult BeginGetResponse(AsyncCallback callback, object state);
//public virtual WebResponse EndGetResponse(IAsyncResult asyncResult);//You could write your download code using this API, but you would actually like to continue to keep the
//DownloadAsync method returning a Task<string>—remember, the general goal of TPL is to represent every//asynchronous operation as a task. To enable this, there is yet another way to create a task called Task.Factory.
//FromAsync.This method takes an IAsyncResult to represent the lifetime of the task and a callback methd to call//when the asynchronous operation has completed. In the case where the task being created is a Task<T>, this method
//has the role of producing the result for the task, so it will return a value of type T.The code in Listing 3-16 is making//more efficient use of the thread pool by only consuming a thread when data arrives back from the web site.No threads
//are consumed from the pool while you are waiting for a response.
//\\
static void better()
{

	Task<string> downloadTaskbetter = BetterDownloadWebPageAsync("https://www.facebook.com/");
	while (!downloadTaskbetter.IsCompleted)
    {
		Console.Write(".............SAM............................................");
		Thread.Sleep(750);
	}
	Console.WriteLine(downloadTaskbetter.Result);
}
private static Task<string> BetterDownloadWebPageAsync(string url)
{
	WebRequest request = WebRequest.Create(url);
	IAsyncResult ar = request.BeginGetResponse(null, null);
	Task<string> downloadTask =
	Task.Factory
	.FromAsync<string>(ar, iar =>
	{
		using (WebResponse response = request.EndGetResponse(iar))
		{
			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	});
	return downloadTask;
}