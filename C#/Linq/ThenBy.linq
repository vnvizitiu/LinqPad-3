<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb534743(v=vs.110).aspx
{
	string[] fruits = { "grape", "passionfruit", "banana", "mango",
					  "orange", "raspberry", "apple", "blueberry" };

	// Sort the strings first by their length and then 
	//alphabetically by passing the identity selector function.
	IEnumerable<string> query =
		fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

	foreach (string fruit in query)
	{
		Console.WriteLine(fruit);
	}

	/*
		This code produces the following output:

		apple
		grape
		mango
		banana
		orange
		blueberry
		raspberry
		passionfruit
	*/

}

// Define other methods and classes here
