<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

//http://www.tutorialspoint.com/csharp/csharp_regular_expressions.htm
   class Program
{
	private static void showMatch(string text, string expr)
	{
		Console.WriteLine("The Expression: " + expr);
		MatchCollection mc = Regex.Matches(text, expr);
		foreach (Match m in mc)
		{
			Console.WriteLine(m.ToString());
		}
	}
	static void Main(string[] args)
	{
		string str = "make maze and manage to measure it";

		Console.WriteLine("Matching words start with 'm' and ends with 'e':");
		showMatch(str, @"\bm\S*e\b");
 
	}
}
