<Query Kind="Program" />

void Main()//Select * from ##Created  
//https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.executenonquery(v=vs.110).aspx
{
	string sql="Select * into ##Created from [AdventureWorks].[Production].[ProductCategory]"; string conn=GetConnectionString(); 
	CreateCommand(sql,conn);
	 
}


private static void CreateCommand(string queryString,
    string connectionString)
{
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
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
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    } 