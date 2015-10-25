<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

//using System;
//using System.Text.RegularExpressions;
//https://msdn.microsoft.com/en-us/library/e47f3dkc(v=vs.110).aspx
public class Example
{
	public static void Main()
   {
      string input = "deceive relieve achieve belief fierce receive";
      string pattern = @"\w*(ie|ei)\w*";
      Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
      Console.WriteLine("Original string: " + input);

		string result = rgx.Replace(input, new MatchEvaluator(Example.ReverseLetter),
									input.Split(' ').Length / 2);
		Console.WriteLine("Returned string: " + result);
	}

	static string ReverseLetter(Match match)
	{
		return Regex.Replace(match.Value, "([ie])([ie])", "$2$1",
							 RegexOptions.IgnoreCase);
	}
}
// The example displays the following output: 
//    Original string: deceive relieve achieve belief fierce receive 
//    