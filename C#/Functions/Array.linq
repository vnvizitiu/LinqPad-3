<Query Kind="Program" />

void Main()
{
	//pass to
	String[] foos = new String[] { "Foo1", "Foo2", "Foo3" };
	ProgramMath.MainEntryMethod(foos);
	
	//get from
	String[] myRetValues=myPublicFunc();//public function outside of class
	Console.WriteLine("Printing myReturn values from function:..");
	for (int i = 0; i < myRetValues.Count(); i++)
	{
		Console.WriteLine(myRetValues.ElementAt(i));
	}
	 
	 myReturnClass mrc=new myReturnClass(); // public class
	String[] myStringOfArraysFromClass = mrc.MyPublicClassReturn();  // public function within class
	for (int i = 0; i < myStringOfArraysFromClass.Count(); i++)
	{
		Console.WriteLine(myStringOfArraysFromClass.ElementAt(i));
	}
	
	 myReturnClass mrc2=new myReturnClass();//public class
	mrc2.FirstName="Sam";
	mrc2.LastName="Tran";
	Console.WriteLine(mrc2.boos.ElementAt(2)); //getting public property in class
	
	String[] fromClass=mrc2.boos;
	for (int i = 0; i < fromClass.Count( ); i++)
	{
		Console.WriteLine(fromClass.ElementAt(i));
	}
	mrc2.GetMyPrivateClassReturn();
	mrc2.Printme();
	

}
class ProgramMath
{
	public static void MainEntryMethod(string[] args)
	{
		Console.WriteLine("***** Fun with Const *****\n");
		Console.WriteLine("The value of PI is: {0}", MyMathClass.PI);
		// Error! Can't change a constant!
		// MyMathClass.PI = 3.1444;

		for (int i = 0; i < args.Count(); i++)
		{
			Console.WriteLine(args.ElementAt(i));
		}
	}
	// Define other methods and classes here
}

string[] myPublicFunc()
{
	String[] foos = new String[] { "Foo1", "Foo2", "Foo3" };
	return foos;
}

class MyMathClass
{
	// public const double PI = 3.14;
	public static readonly double PI;

	static MyMathClass()
	{ PI = 3.14; }
}
class myReturnClass
{ 
	public String FirstName { get; set; }
	public String LastName { get; set; }
	public String[] boos = new String[] { "PublicBoo1", "PublicBoo2", "PublicBoo3" };
	
	
public string[] MyPublicClassReturn()
{
	String[] foos = new String[] { "PublicBoo1", "PublicBoo2", "PublicBoo3" };
	return foos;
}

 static string[]   MyPrivateClassReturn()
{
	String[] foos = new String[] { "PrviateBoo1", "PrivateBoo2", "PrivateBoo3" };
		return foos;//Non-invocable member 'UserQuery.myReturnClass.boos' cannot be used like a method.
	}
	
	
	public string[] GetMyPrivateClassReturn()
	{
		//String[] foos = new String[] { "PublicBoo1", "PublicBoo2", "PublicBoo3" };
		return boos;
	}
	public  void Printme()
	{	
		String[] doo=MyPrivateClassReturn();
		for (int i = 0; i < doo.Count(); i++)
		{
			Console.WriteLine(doo.ElementAt(i));
		}
	}


}