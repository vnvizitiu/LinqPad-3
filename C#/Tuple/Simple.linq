<Query Kind="Program" />


class Program
{
    static void Main()
    {
	// Create three-item tuple.
	Tuple<int, string, bool> tuple =
	    new Tuple<int, string, bool>(1, "cat", true);
	// Access tuple properties.
	if (tuple.Item1 == 1)
	{
	    Console.WriteLine(tuple.Item1);
	}
	if (tuple.Item2 == "dog")
	{
	    Console.WriteLine(tuple.Item2);
	}
	if (tuple.Item3)
		{
			Console.WriteLine(tuple.Item3);
		}
		
		Console.WriteLine("........................");

		// Use Tuple.Create static method.
		var tuplexx = Tuple.Create("cat", 2, true);

		// Test value of string.
		string value = tuplexx.Item1;
		if (value == "cat")
		{
			Console.WriteLine(true);
		}

		// Test Item2 and Item3.
		Console.WriteLine(tuplexx.Item2 == 10);
		Console.WriteLine(!tuplexx.Item3);

		// Write string representation.
		Console.WriteLine(tuple);

			Console.WriteLine("........................");		
			
		// Create four-item tuple.
		// ... Use var implicit type.
		var tuplex = new Tuple<string, string[], int, int[]>("perl",
			new string[] { "java", "c#" },
			1,
			new int[] { 2, 3 });
		// Pass tuple as argument.
		M(tuplex);

	}
	static void M(Tuple<string, string[], int, int[]> tuplex)
	{
		// Evaluate the tuple's items.
		Console.WriteLine(tuplex.Item1);
		foreach (string value in tuplex.Item2)
		{
			Console.WriteLine(value);
		}
		Console.WriteLine(tuplex.Item3);
		foreach (int value in tuplex.Item4)
		{
			Console.WriteLine(value);
		}
	}

}
