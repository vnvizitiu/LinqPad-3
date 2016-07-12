<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>



    class Listing_04 {

	static void Main(string[] args)
	{


		string[] messages = { "First task", "Second task",
									"Third task", "Fourth task" };

		foreach (string msg in messages)
		{
			Task myTask = new Task(obj => printMessage((string)obj), msg);
			myTask.Start();
		}

		// wait for input before exiting
		Console.WriteLine("Main method complete. Press enter to finish.");
	 
	}

	static void printMessage(string message)
	{
		Console.WriteLine("Message: {0}", message);
	}
}
