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
		//SqlParameter myParam= new SqlParameter();
				
//		myParam.ParameterName="@SystemNo";
//		myParam.DbType=DbType.Int16;;
//		myParam.Value=10;
		
        SqlCommand command = new SqlCommand();
			SqlDataAdapter Adpt = default(SqlDataAdapter); //new
			Adpt = new SqlDataAdapter(command); //new
		
		
		command.CommandText="GetResults"; //proc name
		command.CommandType=CommandType.StoredProcedure;
		//command.Parameters.Add(myParam);
		//command.Parameters.AddWithValue(8);
		command.Connection=connection;
		
		
		DataTable  dt = new DataTable();
        command.Connection.Open();
		
	 
		
		Adpt.Fill(dt);
		
			for (int i = 0; i <= dt.Columns.Count - 1; i++)
		{
 			Console.WriteLine(dt.Columns[i].ToString());
 	//	Console.WriteLine(dt.Columns[i]);
		}
		
	 
		List<DataRow> mylist = dt.AsEnumerable().ToList();
	 
		
		foreach (DataRow element  in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString());
		}
		
		
      //  command.ExecuteNonQuery();
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