<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Open XML SDK\V2.5\lib\DocumentFormat.OpenXml.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.XDocument.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>DocumentFormat.OpenXml</Namespace>
  <Namespace>DocumentFormat.OpenXml.Packaging</Namespace>
  <Namespace>DocumentFormat.OpenXml.Spreadsheet</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Agent</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

class QueryContents
{
	public static void Main()
	{
		// Modify this path as necessary. 
		//string startFolder = @"C:\Users\Administrator\SkyDrive\Documents\LinqPad_Queries\";

		try
		{
			Console.WriteLine("trying");
			string startFolder = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\";
			// Take a snapshot of the file system.
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
			// This method assumes that the application has discovery permissions 
			// for all folders under the specified path.
			// IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
			IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.sql*", System.IO.SearchOption.AllDirectories).OrderBy(d => d.DirectoryName).ThenBy(d => d.FullName);
			string searchTerm = @"dbo";
			// Search the contents of each file. 
			// A regular expression created with the RegEx class 
			// could be used instead of the Contains method. 
			// queryMatchingFiles is an IEnumerable<string>. 
			var queryMatchingFiles =
			from file in fileList
			where file.Extension == ".sql"
			let fileText = GetFileText(file.FullName)
			where fileText.Contains(searchTerm)
			select file.FullName;

		//	Dictionary<string, myFiles> myDict = new Dictionary<string, myFiles>();
			List<mySortedFiles> mySortedList =new List<mySortedFiles>();
			// Execute the query.
			Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
			for (int c = 0; c < fileList.Count(); c++)
			{
				//Console.WriteLine(fileList.ElementAt(c).FullName);
				string r = fileList.ElementAt(c).Name.ToString();
				r = r.Remove(r.Length - 4);
				
				mySortedFiles msf =new mySortedFiles(fileList.ElementAt(c).Directory.Parent.ToString(),99, new myFiles(
					fileList.ElementAt(c).Name.ToString(),
					 fileList.ElementAt(c).FullName.ToString(),
					 fileList.ElementAt(c).DirectoryName.ToString(),
					 fileList.ElementAt(c).LastWriteTime.Date.ToString(),
					 fileList.ElementAt(c).CreationTime.Date.ToString(),
					 r,
				 fileList.ElementAt(c).Directory.Parent.ToString(),
				  ""));
				 mySortedList.Add(msf);
			}
			 
			 //foreach (var element in mySortedList.OrderBy(sl => sl.FolderOrder).ThenBy(sl => sl.FolderName).Where(sl => sl.FolderOrder!=5))
			 foreach (var element in mySortedList.OrderBy(sl => sl.FolderOrder).ThenBy(sl => sl.FolderName))
			{
				Console.WriteLine(element);
			}

 
		}
		catch (Exception x)
		{
			//WriteLine (x.Message.ToString);
			Console.WriteLine("Error was caught: " + x.Message);

		}
		finally
		{
			Console.WriteLine("this will run regardless");

		}



	}//end 
	 /////////////////////////////////////////////////////////////
	 // Read the contents of the file. 
	static string GetFileText(string name)
	{
		string fileContents = String.Empty;
		// If the file has been deleted since we took 
		// the snapshot, ignore it and return the empty string. 
		if (System.IO.File.Exists(name))
		{
			fileContents = System.IO.File.ReadAllText(name);
		}
		return fileContents;
	}
}

public class mySortedFiles
{
	public string FolderName { get; set; }
	public int FolderOrder { get; set; }
	public myFiles myfiles { get; set; }

	public mySortedFiles() { }

	public mySortedFiles(string foldername, int folderorder,myFiles mf)
	{
		myfiles = mf;
		FolderName = foldername;

		switch (FolderName)
		{
			case "Tables":
				FolderOrder = 1;
				break;

			case "Functions":
				FolderOrder = 2;
				break;

			case "Views":
				FolderOrder = 3;
				break;

			case "Stored_Procedures":
				FolderOrder = 4;
				break;

			case "Scripts":
				FolderOrder = 5;
				break;
				
			default:
				if (mf.Path.Contains("Scripts"))
				{
					FolderOrder=5;
				}
				//Console.WriteLine("Default, undefined:" + mf.Path );
				// You cannot "fall through" any switch section, including
				// the last one. 
				//throw new Exception();
				break;
		}



	}//class

}


	public class myFiles : IEquatable<myFiles>, IComparable<myFiles>
	{
		public string FileName { get; set; }
		public string FullName { get; set; }
		public string Path { get; set; }
		public string ModDate { get; set; }
		public string CreateDate { get; set; }
		public string ObjName { get; set; }
		public string ObjType { get; set; }
		public string ExecutionResults { get; set; }
		//public int FolderOrder { get; set; }//


		public myFiles() { }

		public myFiles(string filename, string fullname, string path, string moddate, string createdate,
					string objname, string objtype, string results)
		{
			FileName = filename;
			FullName = fullname;
			Path = path;
			ModDate = moddate;
			CreateDate = createdate;
			ObjName = objname;
			ObjType = objtype;
			ExecutionResults = results;
		
		}

		public override string ToString()
		{
			return ObjName.ToString();
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			myFiles objAsPart = obj as myFiles;
			if (objAsPart == null) return false;
			else return Equals(objAsPart);
		}
		public int SortByNameAscending(string name1, string name2)
		{
			return name1.CompareTo(name2);
		}
		// Default comparer for Part type. 
		public int CompareTo(myFiles comparePart)
		{
			// A null value means that this object is greater. 
			if (comparePart == null)
				return 1;
			else
				return this.Path.CompareTo(comparePart.Path);
		}
		public override int GetHashCode()
		{
			return Path.GetHashCode();
		}
		public bool Equals(myFiles other)
		{
			if (other == null) return false;
			return (this.Path.Equals(other.Path));
		}
		// Should also override == and != operators.

	}//