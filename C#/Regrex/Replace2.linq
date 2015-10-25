<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

//using System;
//using System.Text.RegularExpressions;
//https://msdn.microsoft.com/en-us/library/haekbhys(v=vs.110).aspx
void Main()
{
	Example.Main();
	RegExSample.Main();
}

// Define other methods and classes here
public class Example
{
	public static void Main()
	{
		string str = "aabccdeefgghiijkklmm";
		string pattern = "(\\w)\\1";
		string replacement = "$1";
		Regex rgx = new Regex(pattern);

		string result = rgx.Replace(str, replacement, 5);
		Console.WriteLine("Original String:    '{0}'", str);
		Console.WriteLine("Replacement String: '{0}'", result);
	}
}
// The example displays the following output: 
//       Original String:    'aabccdeefgghiijkklmm' 
//  
class RegExSample
{
	public static string CapText(Match m)
	{
		// Get the matched string. 
		string x = m.ToString();
		// If the first char is lower case... 
		if (char.IsLower(x[0]))
		{
			// Capitalize it. 
			return char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);
		}
		return x;
	}

	public static void Main()
	{
		string text = "four score and seven years ago";

		System.Console.WriteLine("text=[" + text + "]");

		Regex rx = new Regex(@"\w+");

		string result = rx.Replace(text, new MatchEvaluator(RegExSample.CapText));

		System.Console.WriteLine("result=[" + result + "]");
	}
}
// The example displays the following output: 
//       text=[four score and seven years ago] 
//   