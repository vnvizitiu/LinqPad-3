<Query Kind="Program" />

void Main()
{
	string me = Environment.GetEnvironmentVariable("PROPHET_RESULTS_DIR");
	string you = System.Environment.GetEnvironmentVariable("PROPHET_RESULTS_DIR");
	Console.WriteLine(me);
	Console.WriteLine(you);
}

// Define other methods and classes here
