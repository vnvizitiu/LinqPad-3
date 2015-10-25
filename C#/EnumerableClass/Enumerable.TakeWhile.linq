<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/vstudio/bb534804(v=vs.100).aspx?cs-save-lang=1&cs-lang=csharp
{
//The following code example demonstrates how to use TakeWhile<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)
//to return elements from the start of a sequence as long as a condition is true.
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

}

// Define other methods and classes here
