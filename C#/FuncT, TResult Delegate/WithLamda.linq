<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/bb549151(v=vs.110).aspx
static class Func
{
   static void Main(string[] args)
	{
		// Declare a Func variable and assign a lambda expression to the  
		// variable. The method takes a string and converts it to uppercase.
		Func<string, string> selector = str => str.ToUpper();

		// Create an array of strings.
		string[] words = { "orange", "apple", "Article", "elephant" };
		// Query the array and select strings according to the selector method.
		IEnumerable<String> aWords = words.Select(selector);
		aWords.Dump();

		// Output the results to the console.
		foreach (String word in aWords)
			Console.WriteLine(word);
		Console.WriteLine(".....................................");

	}
}

