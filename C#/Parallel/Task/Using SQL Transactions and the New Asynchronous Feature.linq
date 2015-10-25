<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data.Common</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class Program { //\https://msdn.microsoft.com/en-us/library/hh211418(v=vs.110).aspx
	static void Main()
	{
		string connectionString =
			@"Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=DESKTOP-E80R7DQ\SQL_MAIN";
		Task task = ExecuteSqlTransaction(connectionString);
		task.Wait();
		
		
		A.Main2();
		
	}

	static async Task ExecuteSqlTransaction(string connectionString)
	{
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			await connection.OpenAsync();

			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = null;

			// Start a local transaction.
			transaction = await Task.Run<SqlTransaction>(
				() => connection.BeginTransaction("SampleTransaction")
				);

			// Must assign both transaction object and connection
			// to Command object for a pending local transaction
			command.Connection = connection;
			command.Transaction = transaction;

			try
			{
				command.CommandText =
					"Insert into Region (RegionID, RegionDescription) VALUES (555, 'Description')";
				await command.ExecuteNonQueryAsync();

				command.CommandText =
					"Insert into Region (RegionID, RegionDescription) VALUES (556, 'Description')";
				await command.ExecuteNonQueryAsync();

				// Attempt to commit the transaction.
				await Task.Run(() => transaction.Commit());
				Console.WriteLine("Both records are written to database.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
				Console.WriteLine("  Message: {0}", ex.Message);

				// Attempt to roll back the transaction.
				try
				{
					transaction.Rollback();
				}
				catch (Exception ex2)
				{
					// This catch block will handle any errors that may have occurred
					// on the server that would cause the rollback to fail, such as
					// a closed connection.
					Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
					Console.WriteLine("  Message: {0}", ex2.Message);
				}
			}
		}
	}
}

class A
{
	static async Task PerformDBOperationsUsingProviderModel(string connectionString, string providerName)
	{
		DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
		using (DbConnection connection = factory.CreateConnection())
		{
			connection.ConnectionString = connectionString;
			await connection.OpenAsync();

			DbCommand command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM AUTHORS";

			using (DbDataReader reader = await command.ExecuteReaderAsync())
			{
				while (await reader.ReadAsync())
				{
					for (int i = 0; i < reader.FieldCount; i++)
					{
						// Process each column as appropriate
						object obj = await reader.GetFieldValueAsync<object>(i);
						Console.WriteLine(obj);
					}
				}
			}
		}
	}

	public static void Main2()
	{
		SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
		// replace these with your own values
		builder.DataSource = @"DESKTOP-E80R7DQ\SQL_MAIN";
		builder.InitialCatalog = "pubs";
		builder.IntegratedSecurity = true;
		string provider = "System.Data.SqlClient";

		Task task = PerformDBOperationsUsingProviderModel(builder.ConnectionString, provider);
		task.Wait();
	}
}
