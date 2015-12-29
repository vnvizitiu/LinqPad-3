<Query Kind="Program" />

void Main()
{
//http://csharp.2000things.com/2014/09/01/1172-lambda-expressions-often-used-with-func-and-action/
	// Function: no parameters, returns int
	Func<int> dayOfYear = () => DateTime.Now.DayOfYear;
	int doy = dayOfYear();

	// Function: 2 parameters, returns string
	Func<int, double, string> intDoubleAdder =
		(int i, double d) =>
		{
			double result = i + d;
			return string.Format("Result is {0}", result);
		};
	string answer = intDoubleAdder(5, 4.2);

	// Action: no parameters
	Action todayReporter = () =>
		Console.WriteLine(string.Format("Today is {0}", DateTime.Today.ToLongDateString()));
	todayReporter();

	// Action: 3 parameters
	Action<string, int, double> goofyDel =
		(s, i, d) => Console.WriteLine(string.Format(s, i, d));
	goofyDel("Int is {0}, Double is {1}", 5, 12.2);
}

// Define other methods and classes here
