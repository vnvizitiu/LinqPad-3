<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

//http://www.tutorialspoint.com/csharp/csharp_attributes.htm
public class MyClass
{
	[Obsolete("Don't use OldMethod, use NewMethod instead", true)] //switch true/false
	static void OldMethod()
	{
		Console.WriteLine("It is the old method");
	}
	static void NewMethod()
	{
		Console.WriteLine("It is the new method");
	}
	public static void Main()
	{
		OldMethod();
	}
}