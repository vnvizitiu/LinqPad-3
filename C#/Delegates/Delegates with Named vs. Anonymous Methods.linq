<Query Kind="Program" />

//https://msdn.microsoft.com/en-us/library/vstudio/98dc08ac(v=vs.100).aspx
// Declare a delegate
delegate void Del(int i, double j);

class MathClass
{
	static void Main()
	{
		MathClass m = new MathClass();

		// Delegate instantiation using "MultiplyNumbers"
		Del d = m.MultiplyNumbers;

		// Invoke the delegate object.
		System.Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
		for (int i = 1; i <= 5; i++)
		{
			d(i, 2);
		}

		// Keep the console window open in debug mode.
		System.Console.WriteLine("Now, second example.....................");
		TestSampleClass.Main();
		
		
		
		
	 
	}

	// Declare the associated method.
	void MultiplyNumbers(int m, double n)
	{
		System.Console.Write(m * n + " ");
	}
}
/* Output:
    Invoking the delegate using 'MultiplyNumbers':
    2 4 6 8 10
*/

//////////////////////////////////////////////////////////////////////////////////

// Declare a delegate
delegate void Del2();

class SampleClass
{
	public void InstanceMethod()
	{
		System.Console.WriteLine("A message from the instance method.");
	}

	static public void StaticMethod()
	{
		System.Console.WriteLine("A message from the static method.");
	}
}

class TestSampleClass
{
	public	static void Main()
	{
		SampleClass sc = new SampleClass();

		// Map the delegate to the instance method:
		Del2 d = sc.InstanceMethod;
		d();

		// Map to the static method:
		d = SampleClass.StaticMethod;
		d();
	}
}
/* Output:
    A message from the instance method.
    A message from the static method.
*/
