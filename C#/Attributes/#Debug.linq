<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Diagnostics</Namespace>
</Query>


#define DEBUG 
//http://www.tutorialspoint.com/csharp/csharp_attributes.htm


public class Myclass
{
	[Conditional("DEBUG")]
	public static void Message(string msg)
	{
		Console.WriteLine(msg);
	}
}

class Test
{
	static void function1()
	{
		Myclass.Message("In Function 1.");
		function2();
	}
	static void function2()
	{
		Myclass.Message("In Function 2.");
	}

	public static void Main()
	{
		Myclass.Message("In Main function.");
		function1();
	 
	}
}