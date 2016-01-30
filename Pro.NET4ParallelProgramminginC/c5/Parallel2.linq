<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>



    class Listing_03 {

	static void Main(string[] args)
	{

		Parallel.For(0, 10, index =>
		{
			Console.WriteLine("Task ID {0} processing index: {1}",
				Task.CurrentId, index);
		});

		// wait for input before exiting
		Console.WriteLine("Press enter to finish");
		
	}
}
