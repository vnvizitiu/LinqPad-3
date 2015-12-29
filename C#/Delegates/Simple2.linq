<Query Kind="Program" />

//http://www.tutorialspoint.com/csharp/csharp_generics.htm
//something wrong with Linqpad...num not refreshing on each execution-tested ok in console app. 

delegate T NumberChanger<T>(T n);
class TestDelegate
{
	static int num = 10;
	public static int AddNum(int p)
	{
		num += p;
		Console.WriteLine(num);
		return num;
	}

	public static int MultNum(int q)
	{
		num *= q;
		Console.WriteLine(num);
		return num;
	}
	public static int getNum()
	{
		Console.WriteLine(num);
		return num;
	}
	
	static void Main()
	{
		Console.WriteLine(num);
		
	
		//create delegate instances
		NumberChanger<int> nc1 = new NumberChanger<int>(AddNum);
		NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);

		//calling the methods using the delegate objects
		nc1(25);
		Console.WriteLine("Value of Num: {0}", getNum());
		nc2(5);
		Console.WriteLine("Value of Num: {0}", getNum());

	}
}
