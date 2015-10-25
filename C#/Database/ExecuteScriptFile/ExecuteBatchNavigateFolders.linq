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
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

/* using Microsoft.SqlServer.Management.Smo;
	    using Microsoft.SqlServer.Management.Nmo;
	    using Microsoft.SqlServer.Management.Smo.Agent;
	    */
class QueryContents
{	
	public static string rollbackScript=@"C:\Users\Sam\Documents\Papa\GRM_Deployment\RollbackSam\Rollbacks.sql";
	public static bool rollback=false;
 
	public static void Main()
	{
		try
		{
			Console.WriteLine("trying");
			string startFolder = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\";


			if (Directory.Exists(startFolder))
			{
				{
					string[] myfolders = GetMyFolders.Mainx(startFolder);
					for (int i = 0; i < myfolders.Count(); i++)
					{
					Console.WriteLine(myfolders.ElementAt(i).ToString());
					
					
					
					}
				}
			}

			else
			{
				Console.WriteLine("Please check you've entered the correct directory: "+startFolder);
				 throw new System.ArgumentException("Error thrown", startFolder); 
			}


			 

			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

			// This method assumes that the application has discovery permissions  for all folders under the specified path.
			IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

			string searchTerm = @"dbo";

			var queryMatchingFiles =
				from file in fileList
				where file.Extension == ".sql"
				let fileText = GetFileText(file.FullName)
				where fileText.Contains(searchTerm)
				select file.FullName;

			List<myFiles> myFirstList = new List<myFiles>();

			// Execute the query.
			Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
			 
			for (int i = 0; i < fileList.Count(); i++)
			{
				Console.WriteLine(fileList.ElementAt(i).FullName);
				ScriptExecutor se = new ScriptExecutor();
				se.RunScript(fileList.ElementAt(i).FullName);
						
				myFiles mf = new myFiles
				{
					Filename = fileList.ElementAt(i).FullName.ToString(),
						FullName = fileList.ElementAt(i).DirectoryName.ToString(),
								Path = fileList.ElementAt(i).DirectoryName.ToString(),
									ModDate = fileList.ElementAt(i).LastWriteTime.Date.Date.ToShortTimeString(),
										CreateDate = fileList.ElementAt(i).CreationTime.Date.ToShortDateString()
				};
				myFirstList.Add(mf);
			}
		}
		catch (Exception x)
		{
			Console.WriteLine(x.Message.ToString());
		}
		finally
		{
			Console.WriteLine("Execution completed");
		}
	}
	// Read the contents of the file. 
	static string GetFileText(string name)
	{
		string fileContents = String.Empty;
		// If the file has been deleted since we took the snapshot, ignore it and return the empty string. 
		if (System.IO.File.Exists(name))
		{
			fileContents = System.IO.File.ReadAllText(name);
		}
		return fileContents;
	}
}
public class myFiles
{	

	public string Filename { get; set; }
	public string FullName { get; set; }
	public string Path { get; set; }
	public string ModDate { get; set; }
	public string CreateDate { get; set; }

}


public class ScriptExecutor
{
	public ScriptExecutor()
	{
		//SQL script reader default constructor
	}

	public void RunScript(string sqlFile)
	{
		bool Thrown = false;
	Begin:
		string sqlConnectionString = GetConnectionString();
		FileInfo file = new FileInfo(sqlFile);
		string exesScript = file.OpenText().ReadToEnd();

		try
		{
			Server server = new Server();
			server.ConnectionContext.ConnectionString = sqlConnectionString;
			server.ConnectionContext.ExecuteNonQuery(exesScript);
			if (Thrown) { throw new System.ArgumentException("Error thrown on rollback", "Rollback Selected"); }
		}
		catch (Exception ex)
		{
			if (Thrown) { Console.WriteLine(); throw; }
			Console.WriteLine();
			Console.WriteLine("Error caught on file: " + sqlFile);
			Console.WriteLine("Error was caught: " + ex.Message + "Inner Message: " + ex.InnerException);

			if (QueryContents.rollback)
			{
				Console.Write("Roll back selected, rolling back as instructed");
				sqlFile = QueryContents.rollbackScript.ToString();
				Thrown = true;
				goto Begin;
			}
			// if your script has key word like \n and  you want to not add in your data base  then use ExecutionTypes.QuotedIdentifierOn  otherwise off
			/*server.ConnectionContext.ExecuteNonQuery
				   (script,Microsoft.SqlServer.Management.Common.ExecutionTypes.
				   QuotedIdentifierOn); 
				 */
		}

	}
}

class GetMyFolders
{
	public static string[] Mainx(string Dir)
	{
		string[] selectedDir = new string[] { "Functions", "Scripts", "Stored_Procedures", "Tables", "Views"};
		string[] retDir=new string[5];
		 // Only get subdirectories that begin with the letter "p." 
			string[] dirs = Directory.GetDirectories(Dir, "*"); //string[] dirs = Directory.GetDirectories(@"c:\", "p*");
		
			Console.WriteLine("The sub directories starting in this folder is {0}.", dirs.Length);
			foreach (string dir in dirs)
			{
				for (int i = 0; i < selectedDir.Count(); i++)
				{
					if (dir.Contains(selectedDir.ElementAt(i).ToString()))
					{
					Console.WriteLine(dir);
					retDir[i]=dir.ToString();
					
					}
					else
					{
						continue;		 
					}
			}

		}
		return retDir;


	}
}

private static string GetConnectionString()
{
	return "Data Source=SAMMYPRO;Integrated Security=SSPI;" +
		"Initial Catalog=Papa_GRM; Asynchronous Processing=true";
}