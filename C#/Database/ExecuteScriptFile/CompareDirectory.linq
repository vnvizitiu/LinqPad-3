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
	public static string firstPath= @"C:\Users\Sam\Documents\Papa\GRM_Deployment\", secondpath=@"C:\Users\Sam\Documents\Papa\GRM_Deployment\";
	public static List<myFiles> myFirstList = new List<myFiles>();
 	public static List<myFiles> mySecondList = new List<myFiles>();

	public static void Main()
	{
		MainProcess(firstPath,1);
		MainProcess(firstPath,2);
	 
		 
		
		
	}
 
	public static void MainProcess(string mypath, int trip)
	{
		try
		{	
			 int rr=trip;
			 Console.WriteLine("trying location: " +mypath);
			string home=mypath;
			string startFolder =mypath;
			 				
			if (Directory.Exists(startFolder))
			{
				{
					string[] myfolders = GetMyFolders.Mainx(startFolder);
					
					List<sortedFolders> _sortedFolders = new List<sortedFolders> { };
					
					for (int i = 0; i < myfolders.Count(); i++)
					{
						sortedFolders sf = new sortedFolders(myfolders.ElementAt(i).ToString(),"X");
						_sortedFolders.Add(sf);
					}
			 
					
			      _sortedFolders.Sort((x,y)=>string.Compare(x.FolderName,y.FolderName));
			 
					List<sortedFolders> objListOrder = _sortedFolders.OrderBy(order => order.OrderId).ThenBy(order => order.OrderId).ToList();
					foreach (var element in objListOrder)
					{	
						Console.WriteLine(element.FolderName);
					}
					
 					foreach (sortedFolders element in objListOrder)
					{
						Console.WriteLine(element.FolderName);
						//System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(myfolders.ElementAt(i).ToString());
						System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(element.FolderName);
						IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

						string searchTerm = @"dbo";

						var queryMatchingFiles =
							from file in fileList
							where file.Extension == ".sql"
							let fileText = GetFileText(file.FullName)
							where fileText.Contains(searchTerm)
							select file.FullName;

						

						// Execute the query.
						Console.WriteLine("The term \"{0}\" was found in:", searchTerm);

						for (int c = 0; c < fileList.Count(); c++)
						{
//							//	Console.WriteLine(fileList.ElementAt(c).FullName);
//							ScriptExecutor se = new ScriptExecutor();
//							se.RunScript(fileList.ElementAt(c).FullName);

							myFiles mf = new myFiles
							{
								Filename = fileList.ElementAt(c).Name.ToString(),
								FullName = fileList.ElementAt(c).FullName.ToString(),
								Path = fileList.ElementAt(c).DirectoryName.ToString(),
								ModDate = fileList.ElementAt(c).LastWriteTime.Date.Date.ToShortDateString(),
								CreateDate = fileList.ElementAt(c).CreationTime.Date.ToShortDateString()
							};
							
							if (rr==1)
							{
								myFirstList.Add(mf);
							}
							else
							{
								mySecondList.Add(mf);
							}
							
							 
							Console.WriteLine(mf.FullName);
						}
					}

				}
			}

			else
			{
				Console.WriteLine("Please check you've entered the correct directory: " + startFolder);
				throw new System.ArgumentException("Error thrown", startFolder);
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

// Custom comparer for the myFiles class. 
class myFilesComparer : IEqualityComparer<myFiles>
{
	// myFiless are equal if their names and myFiles numbers are equal. 
	public bool Equals(myFiles x, myFiles y)
	{

		// Check whether the compared objects reference the same data. 
		if (Object.ReferenceEquals(x, y)) return true;

		// Check whether any of the compared objects is null. 
		if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
			return false;

		// Check whether the myFiless' properties are equal. 
		return x.Filename == y.Filename;// && x.fName == y.Name;
	}

	// If Equals() returns true for a pair of objects, 
	// GetHashCode must return the same value for these objects. 

	public int GetHashCode(myFiles myFiles)
	{
		// Check whether the object is null. 
		if (Object.ReferenceEquals(myFiles, null)) return 0;

		// Get the hash code for the Name field if it is not null. 
	//	int hashmyFilesName = myFiles.Name == null ? 0 : myFiles.Name.GetHashCode();

		// Get the hash code for the Code field. 
		int hashmyFilesCode = myFiles.Filename.GetHashCode();

		// Calculate the hash code for the myFiles. 
		return hashmyFile ^ hashmyFilesCode;
	}

}






class GetMyFolders
{
	public static string[] Mainx(string Dir)
	{
		string[] selectedDir = new string[] { "Functions", "Scripts", "Stored_Procedures", "Tables", "Views" };
		string[] retDir = new string[5];
		// Only get subdirectories that begin with the letter "p." 
		string[] dirs = Directory.GetDirectories(Dir, "*");	//string[] dirs = Directory.GetDirectories(@"c:\", "p*");

		//	Console.WriteLine("The sub directories starting in this folder is {0}.", dirs.Length);
		foreach (string dir in dirs)
		{
			for (int i = 0; i < selectedDir.Count(); i++)
			{
				if (dir.Contains(selectedDir.ElementAt(i).ToString()))
				{
					//	Console.WriteLine(dir);
					retDir[i] = dir.ToString();

				}
				else
				{
					continue;
				}
			}

		}
		Array.Sort(retDir);
		return retDir;


	}
}
public class sortedFolders
{
	//	public string foldername;
	//	public int orderid; 

	public string FolderName;
	public string OrderId;
	//public sortedFolders(){}

	public sortedFolders(string folder, string id)
	{
		if (folder.Contains("Function"))
		{
			OrderId = "B";
		}
		if (folder.Contains("Scripts"))
		{
			OrderId = "E";
		}
		if (folder.Contains("Stored_Procedures"))
		{
			OrderId = "D";
		}
		if (folder.Contains("Tables"))
		{
			OrderId = "A";
		}
		if (folder.Contains("Views"))
		{
			OrderId = "C";
		}

		FolderName = folder;

	}
}
class Logging
{
	public static void Main(string log)
	{
		string path = QueryContents.firstPath.ToString();

		try
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			Console.WriteLine("Logging commenced..");
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine(log);
			}

		}
		catch (Exception e)
		{
			Console.WriteLine("The process failed: {0}", e.ToString());
		}
	}

}