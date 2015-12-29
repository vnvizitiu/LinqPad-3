<Query Kind="Program" />

//http://csharp.2000things.com/2014/09/02/1173-lambda-expression-can-be-just-an-expression/ 
static void SomeMethod(int i, string s)
{	
	Console.WriteLine(i);
	Console.WriteLine(s);
	// do something with int and string
}

static void Main(string[] args)
{
	// Single statement
	Action<int, string> thing1 = (i, s) => SomeMethod(i, s);

	// Block of statements, no return value
	Action<int, string> thing2 = (i, s) =>
	{
		for (int i2 = i; i2 <= i + 10; i2++)
			SomeMethod(i2, s);
	};

	thing1.Invoke(8, "SAM");
	thing2.Invoke(11, "TRAN");





	// Block of statements with return value
	Func<int, int> thing3 = (i) =>
	 {
		 SomeMethod(i, "x");
		 return i + 1;
	 };
	thing3.Invoke(8);
	int myIntReturn = thing3(8);
	Console.WriteLine("......................");
	Console.WriteLine(myIntReturn);
}

// Define other methods and classes here
