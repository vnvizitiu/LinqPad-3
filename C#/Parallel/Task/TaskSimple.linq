<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class Program
{
	static void Main(string[] args)
	{
		Task t = new Task(Speak);
		t.Start();
		Console.WriteLine("Waiting for completion");
		t.Wait();
		Console.WriteLine("All Done");
	}

	private static void Speak()
	{
		Console.WriteLine("Hello World");
	}
}