<Query Kind="Program" />

public class Program
{
	public void MainEntryMethod(string[]args)
	{
		foreach (var element in args)
		{
			Console.WriteLine(element.ToString());
		}
		Console.WriteLine("+++++++++++++++");
		Console.WriteLine(args[0].ToString());
		Console.WriteLine(args[1].ToString());
	}
}

void Main()
{
	// Define other methods and classes here
	string[] foos = new string[] { "Foo1", "Foo2", "Foo3" };
	Program p = new Program();
	p.MainEntryMethod(foos);
}

