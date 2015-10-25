<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\DTS\ForEachEnumerators\Microsoft.SqlServer.ForEachSMOEnumerator.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Namespace>Microsoft.SqlServer</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Common</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
  <CopyLocal>true</CopyLocal>
</Query>

//DOES NOT WORK WITH SQL WITH GO

//https://smehrozalam.wordpress.com/2009/05/12/c-executing-batch-t-sql-scripts-with-go-statements/
//https://smehrozalam.wordpress.com/2009/05/12/c-executing-batch-t-sql-scripts-with-go-statements/
//using System;
//using System.IO;
//https://msdn.microsoft.com/en-us/library/system.io.streamreader.readtoend(v=vs.110).aspx
void Main()
{
	string myfile= @"C:\Users\Sam\Documents\Papa\GRM_Deployment\Stored_Procedures\001\dbo.app_sp_CheckFileExists.sql";
	Test.Main( myfile);
}
class Test
{

	public static void Main(string myfile)
	{
		try
		{
			string mySQL;
			using (StreamReader sr = new StreamReader(myfile))
			{
				//This allows you to do one Read operation.
				//	Console.WriteLine(sr.ReadToEnd());
				mySQL = sr.ReadToEnd();
				string conn = GetConnectionString();
				Console.WriteLine(mySQL);
				CreateCommand(mySQL, conn);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The process failed: {0}", e.ToString());
		}
	}
}


//void Main()//Select * from ##Created  
//		   //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.executenonquery(v=vs.110).aspx
//{
//	string sql = "Select * into ##Created from [AdventureWorks].[Production].[ProductCategory]"; string conn = GetConnectionString();
//	CreateCommand(sql, conn);
//
//}


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
	return "Data Source=SAMMYPRO;Integrated Security=SSPI;" +
		"Initial Catalog=Papa_GRM; Asynchronous Processing=true";
}