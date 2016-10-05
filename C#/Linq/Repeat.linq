<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb348899(v=vs.110).aspx
{
	IEnumerable<string> strings =
	Enumerable.Repeat("I like programming.", 15);

	foreach (String str in strings)
	{
		Console.WriteLine(str);
	}

	/*
	 This code produces the following output:

	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	 I like programming.
	*/

}

// Define other methods and classes here
