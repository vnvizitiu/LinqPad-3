<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.OracleClient.dll</Reference>
</Query>

class CancelSample
 {
private OracleCommand cmd;
	Thread t1, t2;
	// threads signal following events when assigned operations are completed
	private AutoResetEvent ExecuteEvent = new AutoResetEvent(false);
	private AutoResetEvent CancelEvent = new AutoResetEvent(false);
	private AutoResetEvent FinishedEvent = new AutoResetEvent(false);
	AutoResetEvent[] ExecuteAndCancel = new AutoResetEvent[2];
	// Default constructor
	CancelSample()
	{
		cmd = new OracleCommand("select * from all_objects",
		new OracleConnection("user id=scott;password=tiger;data source=oracle"));
		ExecuteAndCancel[0] = ExecuteEvent;
		ExecuteAndCancel[1] = CancelEvent;
	}
	// Constructor that takes a particular command and connection
	CancelSample(string command, OracleConnection con)
	{
		cmd = new OracleCommand(command, con);
		ExecuteAndCancel[0] = ExecuteEvent;
		ExecuteAndCancel[1] = CancelEvent;
	}
	// Execution of the command
	public void Execute()
	{
		OracleDataReader reader = null;
		try
		{
			Console.WriteLine("Execute.");
			reader = cmd.ExecuteReader();
			Console.WriteLine("Execute Done.");
			reader.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine("The command has been cancelled.", e.Message);
		}
		Console.WriteLine("ExecuteEvent.Set()");
		ExecuteEvent.Set();
	}
	// Canceling of the command
	public void Cancel()
	{
		try
		{
			// cancel query if it takes longer than 100 ms to finish execution
			System.Threading.Thread.Sleep(100);
			Console.WriteLine("Cancel.");
			cmd.Cancel();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
		Console.WriteLine("Cancel done.");
		Console.WriteLine("CancelEvent.Set()");
		CancelEvent.Set();
	}
	// Execution of the command with a potential of cancelling
	public void ExecuteWithinLimitedTime()
	{
		for (int i = 0; i < 5; i++)
		{
			Monitor.Enter(typeof(CancelSample));
			try
			{
				Console.WriteLine("Executing " + this.cmd.CommandText);
				ExecuteEvent.Reset();
				CancelEvent.Reset();
				t1 = new Thread(new ThreadStart(this.Execute));
				t2 = new Thread(new ThreadStart(this.Cancel));
				t1.Start();
				t2.Start();
			}
			finally
			{
				WaitHandle.WaitAll(ExecuteAndCancel);
				Monitor.Exit(typeof(CancelSample));
			}
		}
		FinishedEvent.Set();
	}
	[MTAThread]
	static void Main()
	{
		try
		{
			AutoResetEvent[] ExecutionCompleteEvents = new AutoResetEvent[3];
			// Create the connection that is to be used by three commands
			OracleConnection con = new OracleConnection("user id=scott;" +
			"password=tiger;data source=oracle");
			con.Open();
			// Create instances of CancelSample class
			CancelSample test1 = new CancelSample("select * from all_objects", con);
			CancelSample test2 = new CancelSample("select * from all_objects, emp",
		 con);
			CancelSample test3 = new CancelSample("select * from all_objects, dept",
		 con);
			// Create threads for each CancelSample object instance
			Thread t1 = new Thread(new ThreadStart(test1.ExecuteWithinLimitedTime));
			Thread t2 = new Thread(new ThreadStart(test2.ExecuteWithinLimitedTime));
			Thread t3 = new Thread(new ThreadStart(test3.ExecuteWithinLimitedTime));
			// Obtain a handle to an event from each object
			ExecutionCompleteEvents[0] = test1.FinishedEvent;
			ExecutionCompleteEvents[1] = test2.FinishedEvent;
			ExecutionCompleteEvents[2] = test3.FinishedEvent;
			// Start all threads to execute three commands using a single connection
			t1.Start();
			t2.Start();
			t3.Start();
			// Wait for all three commands to finish executing/canceling before
			//closing the connection
			WaitHandle.WaitAll(ExecutionCompleteEvents);
			con.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}
}
