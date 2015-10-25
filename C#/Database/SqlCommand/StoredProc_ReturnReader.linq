<Query Kind="Program" />

void Main()//Select * from ##Created  
//https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.executenonquery(v=vs.110).aspx
//https://msdn.microsoft.com/en-us/library/y6wy5a0f(v=vs.110).aspx
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
//		myParam.DbType=DbType.Int32;
//		myParam.Value=2;
//		myParam.ParameterName="@deduct";
		
        SqlCommand command = new SqlCommand();
		command.CommandText="GetResults"; //proc name
		command.CommandType=CommandType.StoredProcedure;
	//	command.Parameters.Add(myParam);
		command.Connection=connection;
		
		
		
        command.Connection.Open();
        //command.ExecuteNonQuery();
		SqlDataReader reader =
            command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0}", reader[0]));
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
        return "Data Source=WIN-90API3QKTDS;Integrated Security=SSPI;" +
            "Initial Catalog=NorthWind; Asynchronous Processing=true";
    }