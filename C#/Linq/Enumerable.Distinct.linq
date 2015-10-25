<Query Kind="Program" />

void Main()
{
	List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

	IEnumerable<int> distinctAges = ages.Distinct();

	Console.WriteLine("Distinct ages:");

	foreach (int age in distinctAges)
	{
		Console.WriteLine(age);
	}

	/*
	 This code produces the following output:

	 Distinct ages:
	 21
	 46
	 55
	 17
	*/
}

// Define other methods and classes here
