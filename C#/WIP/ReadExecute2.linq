<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfoExtended.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.SmoExtended.dll</Reference>
  <Namespace>Microsoft.SqlServer.ConnectionInfo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Common</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Sdk.Sfc</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Smo</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

//http://stackoverflow.com/questions/25563876/executing-sql-batch-containing-go-statements-in-c-sharp
void Main()
{
	string myfile = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\Stored_Procedures\001\dbo.app_sp_CheckFileExists.sql";
	Test.Main(myfile);
}

void Mainx()
{

	using (SqlConnection connection = new SqlConnection(GetConnectionString()))
	{
		ServerConnection svrConnection = new ServerConnection(connection);
		Server server = new Server(svrConnection);
		server.ConnectionContext.ExecuteNonQuery(script);
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
// Define other methods and classes here
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
				Mainx(mySQL, conn);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The process failed: {0}", e.ToString());
		}
	}
}