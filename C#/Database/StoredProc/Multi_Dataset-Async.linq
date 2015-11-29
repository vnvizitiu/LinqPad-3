<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/7szdt0kc(v=vs.110).aspx
//https://msdn.microsoft.com/en-us/library/7szdt0kc(v=vs.110).aspx
void Main()//Select * from ##Created 
		   //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.executenonquery(v=vs.110).aspx
		   //https://msdn.microsoft.com/en-us/library/y6wy5a0f(v=vs.110).aspx
{
	//string sql="Select * into ##Created from [AdventureWorks].[Production].[ProductCategory]"; string conn=GetConnectionString(); 

	string conn = GetConnectionString();
	Console.WriteLine(conn);
	CreateCommand(conn);
	Console.WriteLine("hello.");
	//not working yet........................

}
private delegate void FillGridDelegate(SqlDataReader reader);

private static void CreateCommand(string connectionString)
{
	// SqlConnection connection = new SqlConnection(connectionString);
	// 
	// SqlParameter myParam= new SqlParameter();
	// myParam.SqlDbType=SqlDbType.NVarChar;
	// myParam.Value="Mexico";
	// myParam.ParameterName="@Country";
	// 
	// SqlCommand command = new SqlCommand();
	// command.CommandText="MultiResults"; //proc name
	// command.CommandType=CommandType.StoredProcedure;
	// command.Parameters.Add(myParam);
	// command.Connection=connection;
	SqlConnection connection = new SqlConnection(connectionString);
	SqlParameter myParam = new SqlParameter();
	myParam.ParameterName = "@Country";
	//myParam.DbType=DbType.Int16;;
	myParam.SqlDbType = SqlDbType.NChar;
	myParam.Value = "Mexico";
	SqlCommand command = new SqlCommand();
	SqlDataAdapter Adpt = default(SqlDataAdapter); //new
	Adpt = new SqlDataAdapter(command); //new

	command.CommandText = "MultiResults"; //proc name
	command.CommandType = CommandType.StoredProcedure;
	command.Parameters.Add(myParam);
	//command.Parameters.AddWithValue(8);
	command.Connection = connection;
	//DataTable dt = new DataTable();
	DataSet ds = new DataSet();
	command.Connection.Open();

	AsyncCallback callback = new AsyncCallback(HandleCallback);
	command.BeginExecuteReader(callback, command,
	CommandBehavior.CloseConnection);

}
private static void HandleCallback(IAsyncResult result)
{
	if (result != null)
	{

	}
	try
	{
		SqlCommand command = (SqlCommand)result.AsyncState;
		SqlDataReader reader = command.EndExecuteReader(result);
		if (reader.HasRows == false)
		{
			reader.Close();
			command.Cancel();
			// throw new Exception("Dataset empty, aborting command-Please check date selected");
			// don't throw on this thread, isExecuting not accessable on this thread
		}
		FillGridDelegate del = new FillGridDelegate(FillGrid);
		Dispatcher.CurrentDispatcher.Invoke(del, reader);
	}
	catch (Exception ex)
	{
		Console.WriteLine("Error: " + ex.Message, "SQL Error");
	}
	finally
	{
		Console.WriteLine("xFinished");
	}
}

private static void FillGrid(SqlDataReader reader)
{
	try
	{
		if (reader.IsClosed)
		{
			throw new System.ArgumentException("Error thrown", "Something went wrong, empty dataset returned");
		}
		if (!reader.HasRows)
		{
			throw new System.ArgumentException("Error thrown", "Something went wrong, empty dataset returned");
		}



		DataSet ds = new DataSet();
		DataTable SummaryTable = new DataTable();
		DataTable DetailsTable = new DataTable();
		DataTable L4Table = new DataTable();
		SummaryTable.TableName = "tblSummary";
		DetailsTable.TableName = "tblCalDetails";
		L4Table.TableName = "tblL400Details";
		ds.Tables.Add(SummaryTable);
		ds.Tables.Add(DetailsTable);
		ds.Tables.Add(L4Table);
		ds.Load(reader, LoadOption.OverwriteChanges, SummaryTable, DetailsTable, L4Table);

		ds.Dispose();
		Console.WriteLine(ds.Tables.Count);
		ds.Tables[0].Dump();
		ds.Tables["tblCalDetails"].Dump();




	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
	}
	finally
	{
		// Closing the reader also closes the connection,
		// because this reader was created using the 

		if (reader != null)
		{
			reader.Close();
		}
	}
}
private static string GetConnectionString()
{
	// To avoid storing the connection string in your code, 
	// you can retrieve it from a configuration file. 
	// If you have not included "Asynchronous Processing=true" in the
	// connection string, the command is not able 
	// to execute asynchronously. 
	// return @"Data Source=L000139\SQL2014;Integrated Security=SSPI;" +
	// "Initial Catalog=NorthWind; Asynchronous Processing=true";
	return @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Integrated Security=true;" +
	"Initial Catalog=NorthWind; Asynchronous Processing=true";
}