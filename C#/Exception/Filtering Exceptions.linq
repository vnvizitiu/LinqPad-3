<Query Kind="Program" />

void Main()
{//http://csharp.2000things.com/2014/11/05/1219-c-6-0-filtering-exceptions/
	int denom;
	try
	{
		denom = 0;
		int x = 5 / denom;
	}
	// Catch /0 on all days but Saturday
	catch (DivideByZeroException xx) when   (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
	{
		Console.WriteLine("Sam's Custom" + xx);
	}

}

// Define other methods and classes here
