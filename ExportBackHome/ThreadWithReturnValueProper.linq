<Query Kind="Program" />

class Program
{
    static void Main(string[] args)
	{

	   int returnValue = 0;
		new Thread(
		   () =>
		   {
			   returnValue = test();
			   Console.WriteLine(returnValue);
		   }).Start();
		//   Thread.Sleep(5000);//if not sleep, then Console.Writeline will run before something return fom test

			Console.WriteLine(returnValue);

	}

	public static int test()
	{
		return 1;
	}
}