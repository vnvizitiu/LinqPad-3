<Query Kind="Program" />

public class Foo
{
	static void Main(string[] args)
	{//http://stackoverflow.com/questions/2652460/how-to-get-the-name-of-the-current-method-from-code
		string method = string.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
		Console.WriteLine(method);
		Console.WriteLine(MethodBase.GetCurrentMethod().ToString());
		Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ToString());
		Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod());
		Console.WriteLine("........................................................");
		Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString());

		string method2 = string.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
		Console.WriteLine(method2);
		
		////the best
		Console.WriteLine( string.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
	}
}

// Define other methods and classes here
