<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/hh211418%28v=vs.110%29.aspx
class CancellationSample
{
	public static void Main(string[] args)
	{
		CancellationTokenSource source = new CancellationTokenSource();
		source.CancelAfter(2000); // give up after 2 seconds
		try
		{
			Task result = CancellingAsynchronousOperations(source.Token);
			result.Wait();
		}
		catch (AggregateException exception)
		{
			if (exception.InnerException is SqlException)
			{
				Console.WriteLine("Operation canceled");
			}
			else
			{
				throw;
			}
		}
	}

	static async Task CancellingAsynchronousOperations(CancellationToken cancellationToken)
	{
		using (SqlConnection connection = new SqlConnection("Server=(local);Integrated Security=true"))
		{
			await connection.OpenAsync(cancellationToken);

			SqlCommand command = new SqlCommand("WAITFOR DELAY '00:10:00'", connection);
			await command.ExecuteNonQueryAsync(cancellationToken);
		}
	}
}
