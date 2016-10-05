<Query Kind="Program" />

void Main()
{ //https://msdn.microsoft.com/en-us/library/bb534869(v=vs.110).aspx
	IEnumerable<int> squares =
	Enumerable.Range(1, 10).Select(x => x * x);

	foreach (int num in squares)
	{
		Console.WriteLine(num);
	}
	string[] fruits = { "apple", "banana", "mango", "orange",
					  "passionfruit", "grape" };

	var query =
		fruits.Select((fruit, index) =>
						  new { index, str = fruit.Substring(0, index) });

	foreach (var obj in query)
	{
		Console.WriteLine("{0}", obj);
	}

}

// Define other methods and classes here
