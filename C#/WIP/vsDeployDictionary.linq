<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\120\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
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

class Program
{
	public static string rollbackScript = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\RollbackSam\Rollbacks.sql";
	public static string home = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\";
	public static bool rollback = false;

	public static void Main()
	{

		#region     
		//DataTable dt = new DataTable();
		//string sql = "Select top 10 * from app_t_generic_SSIS_Configurations";
		//dt = GetSQLobj.getObj(sql, ConnString.GetConnectionString());


		#endregion
		try
		{
			#region
			//                Console.WriteLine("trying");
			//                Logging.CommenceLoggingn("Trying");
			//
			//                int origWidth, width;
			//                int origHeight, height;
			//                //string m1 = "The current window width is {0}, and the " +
			//                //            "current window height is {1}.";
			//                //string m2 = "The new window width is {0}, and the new " +
			//                //            "window height is {1}.";
			//                string m4 = "  (Resizing, press any key to continue...)";
			//                // 
			//                // Step 1: Get the current window dimensions. 
			//                //
			//                origWidth = Console.WindowWidth;
			//                origHeight = Console.WindowHeight;
			//            //    Console.WriteLine(m1, Console.WindowWidth,  Console.WindowHeight);
			//               Console.WriteLine(m4);
			//                Console.ReadKey(true);
			//                // 
			//                // Step 2: Cut the window to 1/4 its original size. 
			//                //
			//                width = origWidth * 2;
			//                height = origHeight * 2;
			//                Console.SetWindowSize(width, height);
			//               // Console.WriteLine(m2, Console.WindowWidth, Console.WindowHeight);
			//             
			// 
			#endregion
			string startFolder = home;
			List<string> _Production = new List<string>();
			List<string> _NewItems = new List<string>();
			//gather output
			DataSet DS_Out = new DataSet("Results");
			List<string> ContainsList=new List<string>();
            List<string> NotContainsList= new List<string>();

			if (Directory.Exists(startFolder))
			{
				{
					string[] myfolders = GetMyFolders.Mainx(startFolder);

					List<sortedFolders> _sortedFolders = new List<sortedFolders> { };

					for (int i = 0; i < myfolders.Count(); i++)
					{
						sortedFolders sf = new sortedFolders(myfolders.ElementAt(i).ToString(), "X");
						_sortedFolders.Add(sf);

					}

					//sort folders
					_sortedFolders.Sort((x, y) => string.Compare(x.FolderName, y.FolderName));


					List<sortedFolders> objListOrder = _sortedFolders.OrderBy(order => order.OrderId).ThenBy(order => order.OrderId).ToList();
					foreach (var element in objListOrder)
					{
						Console.WriteLine(element.FolderName);
						//  Logging.CommenceLoggingn(element.FolderName);
					}


					//Get Production Items
					DataSet DS = new DataSet();
					DS = GetSQL_Obj_DS.getObjc();
					
				
					


					var myTables = DS.Tables["Tables"].AsEnumerable().ToList().Select(r => new retObjts { Name = r.Field<string>("Tables"), Type = "Tables" });

					var myTableList = from s in myTables
									  select s;
					List<retObjts> TableList = myTableList.ToList();


					var myViews = DS.Tables["Views"].AsEnumerable().Select(r => new retObjts { Name = r.Field<string>("Views"), Type = "Views" });

					var myViewList = from s in myViews
									 select s;
					List<retObjts> ViewList = myViewList.ToList();



					var myProcs = DS.Tables["StoredProcs"].AsEnumerable().Select(r => new retObjts { Name = r.Field<string>("StoredProcs"), Type="StoredProcs" });

					var myProcList = from s in myProcs
									 select s;
					List<retObjts> ProcList = myProcList.ToList();


					var myUDFs = DS.Tables["Functions"].AsEnumerable().Select(r => new retObjts { Name = r.Field<string>("Functions"), Type="Functions"});

					var myFNList = from s in myUDFs
								   select s;
					List<retObjts> FunctionList = myFNList.ToList();
					
				 
					

					List<retObjts> consolidatedList = TableList.Concat(FunctionList).Concat(ViewList).Concat(myProcList).ToList();
					Console.WriteLine(consolidatedList.Count());






					//Loop items in sorted folders
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
							let fileText = FileText.GetFileText(file.FullName)
							where fileText.Contains(searchTerm)
							orderby file.DirectoryName, file.FullName
							select file.FullName;
						//
						List<myFiles> myFirstList = new List<myFiles>();//////////////////////////remove this for dictionary
						//SortedDictionary<string, myFiles> myDict = new SortedDictionary<string, myFiles>();
						Dictionary<string, myFiles> myDict = new  Dictionary<string, myFiles>();


						// Execute the query.
						Console.WriteLine("The term \"{0}\" was found in:", searchTerm);

						for (int c = 0; c < fileList.Count(); c++)
						{
						 // ScriptExecutor se = new ScriptExecutor();
							//se.RunScript(fileList.ElementAt(c).FullName);

							string r = fileList.ElementAt(c).Name.ToString();
							r = r.Remove(r.Length - 4);

							myFiles mf = new myFiles
							{
								Filename = fileList.ElementAt(c).Name.ToString(),
								FullName = fileList.ElementAt(c).FullName.ToString(),
								Path = fileList.ElementAt(c).DirectoryName.ToString(),
								ModDate = fileList.ElementAt(c).LastWriteTime.Date.Date.ToShortTimeString(),
								CreateDate = fileList.ElementAt(c).CreationTime.Date.ToShortDateString(),
								ObjName = r,
								ObjType = fileList.ElementAt(c).Directory.Parent.ToString()
							};
							myFirstList.Add(mf);
							myDict.Add(mf.ObjName, mf);
							//	Console.WriteLine(mf.FullName);

						}

							 

						///	myFirstList.Sort(); //sorted dictionary used
						Console.WriteLine("All Sorted now...............");
						Console.Write(element.FolderType);

//						//gather output
//						DataSet DS_Out = new DataSet();
//						List<string> ContainsList
//                    List<string> NotContainsList



						var foldersearched = element.FolderType;
						for (int i = 0; i < myDict.Count(); i++)
						{
						//	Console.WriteLine(myDict.Count());
						//	Console.WriteLine(i);
							myFiles ret;
							if (consolidatedList.Select(l => l.ToString()).Contains(myDict.Keys.ElementAt(i).ToString()))
							{
								//ScriptExecutor se = new ScriptExecutor();
								//se.RunScript(myDict.Values.ElementAt(i).FullName.ToString());

								///	Console.WriteLine(myDict.Values.ElementAt(i).FullName.ToString());
								ContainsList.Add(myDict.Values.ElementAt(i).FullName.ToString());

							}
							
						
 			
							else
							{
								Console.WriteLine(myDict.ElementAt(i).Value + " NOT FOUND");
								//ScriptExecutor se = new ScriptExecutor();
								//se.RunScript(myDict.Values.ElementAt(i).FullName.ToString());
								NotContainsList.Add(myDict.Values.ElementAt(i).FullName.ToString());
							}
						}



					}

				}

			}
				
		 
				
				
			else
			{
				Console.WriteLine("Please check you've entered the correct directory: " + startFolder);
			//  Logging.CommenceLoggingn("Please check you've entered the correct directory: " + startFolder);
				throw new System.ArgumentException("Error thrown", startFolder);
			}
			
			DataTable dt1= ConvertListToDataTable(ContainsList);
			DataTable dt2= ConvertListToDataTable(NotContainsList);
			DS_Out.Tables.Add(dt1);
			DS_Out.Tables.Add(dt2);
			
			
			

		 
		}

	
		
		catch (Exception x)
		{
			Console.WriteLine(x.Message.ToString());
		}
		finally
		{
			Console.WriteLine("Execution completed");

			// Console.SetWindowSize(origWidth, origHeight);       
			//   Console.ReadLine();
		}
	}


//static DataTable ConvertListToDataTable(List<string[]> list)
	public static DataTable ConvertListToDataTable(List<string> list)
	{
		// New table.
		DataTable table = new DataTable();

		// Get max columns.
		int columns = 0;
		foreach (var array in list)
		{
			if (array.Length > columns)
			{
				columns = array.Length;
			}
		}

		// Add columns.
		for (int i = 0; i < columns; i++)
		{
			table.Columns.Add();
		}

		// Add rows.
		foreach (var array in list)
		{
			table.Rows.Add(array);
		}

		return table;
	}

}//class

public class retObjts
{
	public string Name { get; set; }
	public string Type { get; set; }
	public retObjts() { }

	public override string ToString()
	{
		return "dbo." + Name.ToString();
	}


}

//public class rObjComparer : IEqualityComparer<retObjts>
//{

//// Products are equal if their names and product numbers are equal. 
//public bool Equals(retObjts x, retObjts y)
// {
//     y.Name = y.Name.Remove(y.Name.Length - 4);
//    //Check whether the compared objects reference the same data. 
//    if (Object.ReferenceEquals(x, y)) return true;

//    //Check whether any of the compared objects is null. 
//    if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
//        return false;

//    //Check whether the products' properties are equal. 
//    return x.Name == y.Name && x.Name == y.Name;
//}
//public int GetHashCode(retObjts retobj)
//{
//    //Check whether the object is null 
//    if (Object.ReferenceEquals(retobj, null)) return 0;

//    //Get hash code for the Name field if it is not null. 
//    int hashProductName = retobj.Name == null ? 0 : retobj.Name.GetHashCode();

//    //Get hash code for the Code field. 
//    int hashProductCode = retobj.Name.GetHashCode();

//    //Calculate the hash code for the product. 
//    return hashProductName ^ hashProductCode;
//}


//}































class GetMyFolders
{
	public static string[] Mainx(string Dir)
	{
		string[] selectedDir = new string[] { "Functions", "Scripts", "Stored_Procedures", "Tables", "Views" };
		string[] retDir = new string[5];
		// Only get subdirectories that begin with the letter "p." 
		string[] dirs = Directory.GetDirectories(Dir, "*"); //string[] dirs = Directory.GetDirectories(@"c:\", "p*");

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


public class FileText
{
	public static string GetFileText(string name)
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

public class GetSQL_Obj_DS
{
	public static DataSet getObjc()
	{

		try
		{
			//var arrSQL = new[] {"SELECT TABLE_NAME,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
			//                       ,"SELECT TABLE_NAME as View,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'"
			//                       ," SELECT name AS Function ,SCHEMA_NAME(schema_id) AS schema_name ,type_desc FROM sys.objects WHERE type_desc LIKE '%FUNCTION%';"
			//                       ,"select ROUTINE_NAME as Proc from Papa.information_schema.routines where routine_type = 'PROCEDURE'"};

			// string conStr = @"server=SAMMYPRO;database=Northwind;Integrated Security=SSPI";
			string conStr = getCompared();

			SqlConnection conn = new SqlConnection(conStr);

			SqlDataAdapter tableAdapter = new SqlDataAdapter(
			  "SELECT TABLE_NAME as Tables FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", conn);
			SqlDataAdapter viewAdapter = new SqlDataAdapter(
			  "SELECT TABLE_NAME as Views FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'", conn);
			SqlDataAdapter functionAdapter = new SqlDataAdapter(
			  "SELECT name as Functions FROM sys.objects WHERE type_desc LIKE '%FUNCTION%'", conn);
			SqlDataAdapter procAdapter = new SqlDataAdapter(
			  "select ROUTINE_NAME as StoredProcs from Information_schema.routines where routine_type = 'PROCEDURE'", conn);

			DataSet DS = new DataSet();

			tableAdapter.Fill(DS, "Tables");
			viewAdapter.Fill(DS, "Views");
			functionAdapter.Fill(DS, "Functions");
			procAdapter.Fill(DS, "StoredProcs");


			//foreach (DataTable table in DS.Tables)
			//{
			//    foreach (DataRow row in table.Rows)
			//    {
			//        foreach (object item in row.ItemArray)
			//        {
			//            Console.WriteLine(item.ToString());
			//        }
			//    }
			//}


			//foreach (DataRow pRow in DS.Tables["Tables"].Rows)
			//{
			//    Console.WriteLine(pRow["Tables"]);
			//}



			return DS;

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			throw;
		}









	}

	public static string getCompared()
	{
		return @"Data Source=SAMMYPRO;Integrated Security=SSPI;" +
	   "Initial Catalog=Papa_GRM2; Asynchronous Processing=true";
		//return "aaunswh11\sqluat_papa"
	}



}

public class GetSQLobj
{
	public static string[] getSQL()
	{

		var arrSQL = new[] {"SELECT TABLE_NAME,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
									   ,"SELECT TABLE_NAME as View,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'"
									   ," SELECT name AS Function ,SCHEMA_NAME(schema_id) AS schema_name ,type_desc FROM sys.objects WHERE type_desc LIKE '%FUNCTION%';"
									   ,"select ROUTINE_NAME as Proc from Information_schema.routines where routine_type = 'PROCEDURE'"};
		return arrSQL;

	}



	public static DataTable getObjc(string conStr)
	{

		String[] foo = getSQL();
		for (int i = 0; i < foo.Count(); i++)
		{
			Console.WriteLine(foo.ElementAt(i));


		}


		try
		{
			string sql = "connstring";
			SqlConnection conn = new SqlConnection(conStr);
			using (SqlCommand command = new SqlCommand(sql, conn))
			{
				conn.Open();
				using (SqlDataReader dr = command.ExecuteReader())
				{
					DataTable rdt = new DataTable();
					rdt.Load(dr);
					return rdt;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			throw;
		}

	}



}

public class myFiles : IEquatable<myFiles>, IComparable<myFiles>
{

	public string Filename { get; set; }
	public string FullName { get; set; }
	public string Path { get; set; }
	public string ModDate { get; set; }
	public string CreateDate { get; set; }
	public string ObjName { get; set; }
	public string ObjType { get; set; }

	public myFiles() { }


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
	//    public override string GetHashCode()
	//    {
	//        return Path;
	//    }
	public bool Equals(myFiles other)
	{
		if (other == null) return false;
		return (this.Path.Equals(other.Path));
	}
	// Should also override == and != operators.


}
}





class Logging
{

	public static void CommenceLoggingn(string log)
	{
		string path;  //=Program.home.ToString();
		path = @"X:\Actuary\systems\JIRA\CIAB_BAU\2015\2015_CIAB-420_GRM_UAT_Deployment\GIT\Log.txt";

		try
		{
			Console.WriteLine("");
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine(log);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The process failed: {0}", e.ToString());
			throw;
		}
	}

	class FileExists
	{
		public static void CheckFileExists(string file)
		{
			try
			{
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}
	}

}

public class ConnString
{
	public static string GetConnectionString()
	{
		return @"Data Source=SAMMYPRO;Integrated Security=SSPI;" +
		"Initial Catalog=Papa_GRM2; Asynchronous Processing=true";
	}

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

		string sqlConnectionString = ConnString.GetConnectionString();


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
			//  Logging.CommenceLoggingn("___");
			Console.WriteLine("Error caught on file: " + sqlFile);
			//Logging.CommenceLoggingn("Error caught on file: " + sqlFile);
			Console.WriteLine("Error was caught: " + ex.Message + "Inner Message: " + ex.InnerException);
			//Logging.CommenceLoggingn("Error was caught: " + ex.Message + "Inner Message: " + ex.InnerException);




			//            if ( Program.rollback)
			//            {
			//                Console.Write("Roll back selected, rolling back as instructed");
			//                sqlFile =  Program.rollbackScript.ToString();
			//                //   sqlFile = QueryContents.rollbackScript.ToString();
			//                Thrown = true;
			//                goto Begin;
			//            }




			// if your script has key word like \n and  you want to not add in your data base  then use ExecutionTypes.QuotedIdentifierOn  otherwise off
			/*server.ConnectionContext.ExecuteNonQuery
				   (script,Microsoft.SqlServer.Management.Common.ExecutionTypes.
				   QuotedIdentifierOn); 
				 */
		}

	}
}


public class sortedFolders
{
	//	public string foldername;
	//	public int orderid; 
	public string FolderName;
	public string OrderId;
	public string FolderType;
	//public sortedFolders(){}

	public sortedFolders(string folder, string id)
	{
		if (folder.Contains("Function"))
		{
			OrderId = "B";
			FolderType = "Functions";
		}
		if (folder.Contains("Scripts"))
		{
			OrderId = "E";
			FolderType = "Scripts";
		}
		if (folder.Contains("Stored_Procedures"))
		{
			OrderId = "D";
			FolderType = "StoredProcs";
		}
		if (folder.Contains("Tables"))
		{
			OrderId = "A";
			FolderType = "Tables";

		}
		if (folder.Contains("Views"))
		{
			OrderId = "C";
			FolderType = "Views";
		}

		FolderName = folder;

	}


	
