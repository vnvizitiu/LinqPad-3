<Query Kind="Program" />

class Program
{//http://stackoverflow.com/questions/17428880/how-to-continuously-run-a-c-sharp-console-application-in-background
    static void Main(string[] args)
	{
		while (true)
		{
			Console.Write("hellow world");
			System.Threading.Thread.Sleep(1000 * 60 * 1); // Sleep for 5 minutes
		}

	}
}