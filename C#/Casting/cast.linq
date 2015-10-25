<Query Kind="Program" />

class Test
{
    static void Main()
	{	
		//explicity conversion
		double x = 1234.7;
		int a;
		// Cast double to int.
		a = (int)x;
		System.Console.WriteLine(a);


		//implicit conversion
		int num = 2147483647;
		long bigNum = num;
		Console.WriteLine(bigNum);
		UnSafeCast.Main();
	}
}
// Output: 1234

class Animal
{
	public void Eat() { Console.WriteLine("Eating."); }
	public override string ToString()
	{
		return "I am an animal.";
	}
}
class Reptile : Animal { }
class Mammal : Animal { }

static class UnSafeCast
{
	public static void Main()
	{
		Test(new Mammal());

		// Keep the console window open in debug mode.
		System.Console.WriteLine("Press any key to exit.");
		System.Console.ReadKey();
	}

	static void Test(Animal a)
	{
		// Cause InvalidCastException at run time  
		// because Mammal is not convertible to Reptile.
		Reptile r = (Reptile)a;
	}

}