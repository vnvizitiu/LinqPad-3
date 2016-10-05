<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb534804(v=vs.110).aspx
{

	string[] fruits = { "apple", "banana", "mango", "orange",
					  "passionfruit", "grape" };

	IEnumerable<string> query =
		fruits.TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);

	foreach (string fruit in query)
	{
		Console.WriteLine(fruit);
	}

	/*
	 This code produces the following output:

	 apple
	 banana
	 mango
	 
	*/
 
	Console.WriteLine("______________________________________________________________");
	string[] fruits2 = { "apple", "passionfruit", "banana", "mango",
					  "orange", "blueberry", "grape", "strawberry" };

	IEnumerable<string> query2 =
		fruits2.TakeWhile((fruit2, index) => fruit2.Length >= index);

	foreach (string fruit2 in query2)
	{
		Console.WriteLine(fruit2);
	}

	/*
	 This code produces the following output:

	 apple
	 passionfruit
	 banana
	 mango
	 orange
	 blueberry
	*/

}

// Define other methods and classes here