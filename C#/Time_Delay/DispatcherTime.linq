<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

class Program
{
    static void Main(string[] args)
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 1, 0); // sets it to 5 minutes
        timer.Tick += new EventHandler(timer_Tick);
        timer.Start();
    }

    static void timer_Tick(object sender, EventArgs e)
    {
		// whatever you want to happen every 5 minutes
		Console.WriteLine("hello");
		Console.WriteLine(e.ToString());
	}

}
http://stackoverflow.com/questions/17428880/how-to-continuously-run-a-c-sharp-console-application-in-background