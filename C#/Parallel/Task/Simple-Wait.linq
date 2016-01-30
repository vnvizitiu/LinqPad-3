<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public class Example//https://msdn.microsoft.com/en-us/library/dd235635(v=vs.110).aspx
{
	public static void Main2()
	{
		Task t = Task.Run(() =>
		{
			Random rnd = new Random();
			long sum = 0;
			int n = 1000000;
			for (int ctr = 1; ctr <= n; ctr++)
			{
				int number = rnd.Next(0, 101);
				sum += number;
			}
			Console.WriteLine("Total:   {0:N0}", sum);
			Console.WriteLine("Mean:    {0:N2}", sum / n);
			Console.WriteLine("N:       {0:N0}", n);
			Console.WriteLine("Sleep");
			Thread.Sleep(5000);
		});
		t.Wait();
		Console.WriteLine("Finished properly");
		//     Program.Main();
	}
}
public static class Program
{
	public static void Main()
	{
		Task task1 = Task.Factory.StartNew(() => doStuff());
		Task task2 = Task.Factory.StartNew(() => doStuff());
		Task task3 = Task.Factory.StartNew(() => doStuff());
		Task.WaitAll(task1, task2, task3);
		Thread.Sleep(5000);
		Console.WriteLine("All threads complete");
	}
	static void doStuff()
	{
		//do stuff here
		Console.WriteLine("Doing Stuff");
	}

}
