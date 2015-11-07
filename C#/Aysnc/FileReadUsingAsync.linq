<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//C:\Users\samtran\OneDrive\Documents\TextBookCodes\C_ Multithreaded and Parallel Programming\8321EN_11_codes\FileReadUsingAsync
    class Program
    {

        static void Main()
        {
            Console.WriteLine("The of the Main method: {0}. \r\n",
                Thread.CurrentThread.ManagedThreadId);

		//Wait on the user to begin the reading of the file.
		//Slow down the process.--sam
		System.Threading.Thread.Sleep(1000);

		// Create task, start it, and wait for it to finish.
		Task task = new Task(ProcessFileAsync);
            task.Start();
            task.Wait();

		//Wait for a return before exiting.
		// Console.ReadLine();
		//Slow down the process.
		System.Threading.Thread.Sleep(10000);
		Console.WriteLine("Main completed");
	}

	static async void ProcessFileAsync()
	{
		// Write out the id of the thread of the task that will call the async method to read the file.
            Console.WriteLine("The thread id of the ProcessFileAsync method: {0}. \r\n",
               Thread.CurrentThread.ManagedThreadId);

            // Start the HandleFile method.
            Task<String> task = ReadFileAsync(@"C:\Users\samtran\Downloads\WordLookup.txt");

            // Perform some other work.
            Console.WriteLine("Do some other work. \r\n");

		Console.WriteLine("Proceed with waiting on the read to complete. \r\n");
		//Slow down the process.
		System.Threading.Thread.Sleep(10000);

		// Wait for the task to finish reading the file.
		String results = await task;
            Console.WriteLine("Number of characters read are: {0}. \r\n", results.Length);

            Console.WriteLine("The file contents are: {0}. \r\n", results);
        }

        static async Task<String> ReadFileAsync(string file)
        {
            // Write out the id of the thread that is performing the read.
            Console.WriteLine("The thread id of the ReadFileAsync method: {0}. \r\n",
               Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Begin Reading file asynchronously. \r\n");

		// Read the specified file.
		String DataRead = "";
		using (StreamReader reader = new StreamReader(file))
		{
			string character = await reader.ReadToEndAsync();

			//Build string of data read.
			DataRead = DataRead + character;

			//Slow down the process.
			System.Threading.Thread.Sleep(10000);

		}


		Console.WriteLine("Done Reading File asynchronously. \r\n");
		return DataRead;
	}

}
