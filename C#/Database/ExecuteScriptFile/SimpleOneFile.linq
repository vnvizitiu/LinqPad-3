<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.SmoExtended.dll</Reference>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Agent</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

//http://www.codeproject.com/Articles/20417/SQL-Script-Executer-or-Reader-Executes-Microsoft-S

void Main()
{
	scriptReader sr=new scriptReader();
	sr.ReadScript(GetConnectionString());
}

// Define other methods and classes here
public class scriptReader
{
	public scriptReader()
	{
		//SQL script reader default constructor
	}
	// the below method requires only connection string 
	// this is understood that script has no error and has same column 
	// name and data type
	public void ReadScript(string ConnectionString)
	{
		string sqlConnectionString = ConnectionString;
		//Directory where the script reside

		FileInfo file = new FileInfo(@"C:\Users\Sam\Documents\Papa\GRM_Deployment\Stored_Procedures\001\dbo.app_sp_CheckFileExists.sql");
		// this string opens and reads the script from start to end
		// if your script is too long then use any collection or any other thing 
		//which u want and use method of .Tostring()
		string script = file.OpenText().ReadToEnd();
		//below code reside in following name spaces be default Microsoft just 
		//include them

		/* using Microsoft.SqlServer.Management.Smo;
	    using Microsoft.SqlServer.Management.Nmo;
	    using Microsoft.SqlServer.Management.Smo.Agent;
	    */
		Server server = new Server();
		server.ConnectionContext.ConnectionString = sqlConnectionString;

		server.ConnectionContext.ExecuteNonQuery(script);
		// 
		// if your script has key word like \n and 
		// you want to not add in your data base 
		// then use ExecutionTypes.QuotedIdentifierOn
		// otherwise off

		/*server.ConnectionContext.ExecuteNonQuery
               (script,Microsoft.SqlServer.Management.Common.ExecutionTypes.
               QuotedIdentifierOn); 
             */
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
