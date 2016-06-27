<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

//http://www.tutorialspoint.com/csharp/csharp_regular_expressions.htm
   class Program
{
	static void Main(string[] args)
	{
		string input = "Hello                         World   ";
		string pattern = "\\s+";
		string replacement = " ";
		Regex rgx = new Regex(pattern);
		string result = rgx.Replace(input, replacement);

		Console.WriteLine("Original String: {0}", input);
		Console.WriteLine("Replacement String: {0}", result);
	 
	}
}
