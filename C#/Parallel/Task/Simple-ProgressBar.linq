<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public static class Program
{
//https://msdn.microsoft.com/en-us/library/dd235635(v=vs.110).aspx
//http://stackoverflow.com/questions/1584062/how-to-wait-for-thread-to-finish-with-net

	public static void Main()
	{
		Task task1 = Task.Factory.StartNew(() => doStuff("1: Progress Bar stars"));
		Task task2 = Task.Factory.StartNew(() => doStuff("2: Run SQL"));
		Task task3 = Task.Factory.StartNew(() => doStuff("3: OtherTask "));
		Task.WaitAll(task1, task2, task3);
		Thread.Sleep(5000);
		Console.WriteLine("All threads complete---Progressbar Ends");
		Task task4 = Task.Factory.StartNew(() => doStuff("Complete"));
	}

	static void doStuff(string xx)
	{
   		MessageBox.Show("Doing"+xx);
	}
}