<Query Kind="Program" />

void Main()//Select * from ##Created 
 //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.executenonquery(v=vs.110).aspx
{
	//string sql="Select * into ##Created from [AdventureWorks].[Production].[ProductCategory]"; string conn=GetConnectionString(); 
	string conn=GetConnectionString();
 Console.WriteLine(conn);
 CreateCommand(conn);

 }
 　
private static void CreateCommand(string connectionString)
 {
 using (SqlConnection connection = new SqlConnection(
 connectionString))
 { 
	SqlParameter myParam= new SqlParameter();

 myParam.ParameterName="@Country";
 //myParam.DbType=DbType.Int16;;
 myParam.SqlDbType=SqlDbType.NChar;
 myParam.Value="Mexico";

 SqlCommand command = new SqlCommand();
	SqlDataAdapter Adpt = default(SqlDataAdapter); //new
	Adpt = new SqlDataAdapter(command); //new
	

	command.CommandText="MultiResults"; //proc name
	command.CommandType=CommandType.StoredProcedure;
 command.Parameters.Add(myParam);
	//command.Parameters.AddWithValue(8);
	command.Connection=connection;


	//DataTable dt = new DataTable();
	DataSet ds= new DataSet();
 command.Connection.Open();



  Adpt.Fill(ds);
	
	Console.WriteLine("Finished..");
	ds.Tables[0].Dump();
	ds.Tables[1].Dump();
	ds.Tables[2].Dump();



 // command.ExecuteNonQuery();
 }

 }
 private static string GetConnectionString()
 {
	// To avoid storing the connection string in your code, 
	// you can retrieve it from a configuration file. 
 	// If you have not included "Asynchronous Processing=true" in the
	// connection string, the command is not able 
	// to execute asynchronously. 
	return @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Integrated Security=SSPI;" +
	"Initial Catalog=NorthWind; Asynchronous Processing=true";
}
