<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
</Query>

//C:\Users\samtran\OneDrive\Documents\TextBookCodes\C_ Multithreaded and Parallel Programming\8321EN_11_codes\FileReadUsingAsync
    class Program
{
	private static byte[] FileData = new byte[1000];

	public static void Main()
	{

		FileStream FS = new FileStream(@"C: \Users\samtran\Downloads\WordLookup.txt", FileMode.Open, FileAccess.Read,
		FileShare.Read, 1024, FileOptions.Asynchronous);

		Console.WriteLine("To start async read press return.");
		Console.ReadLine();

		IAsyncResult result = FS.BeginRead(FileData, 0, FileData.Length, ReadComplete, FS);


		// Work being done while we wait on the async read.
		Console.WriteLine("\r\n");
		Console.WriteLine("Doing Some other work here. \r\n");
		Console.WriteLine("\r\n");


		Console.ReadLine();
		Console.WriteLine("sam was here");
		Console.ReadLine();
	}

	private static void ReadComplete(IAsyncResult AResult)
	{
		// Write out the id of the thread that is performing the read.
		Console.WriteLine("The read operation is being done on thread id: {0}.",
		   Thread.CurrentThread.ManagedThreadId);

		// Get the FileStream out of the IAsyncResult object.
		FileStream FS = (FileStream)AResult.AsyncState;

		// Get the results from the read operation.
		int num = FS.EndRead(AResult);

		// Make sure to close the FileStream.
		FS.Close();

		//Now, write out the results.
		Console.WriteLine("Read {0}  bytes from the file. \r\n", num);
		Console.WriteLine("Is the async read completed - {0}. \r\n", AResult.IsCompleted.ToString());
		Console.WriteLine(BitConverter.ToString(FileData));
	}

}
