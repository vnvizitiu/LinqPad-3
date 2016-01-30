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

class Program
{
	public static string rollbackScript = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\RollbackSam\Rollbacks.sql";
	public static string home = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\";
	public static bool rollback = true;//false;
	public static string ExeResult="Failed" ;
	 
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
		 
			//gather output
			DataSet DS_Out = new DataSet("Results");
			List<myFiles> ContainsList=new List<myFiles>();
            List<myFiles> NotContainsList= new List<myFiles>();

		
					//Get Production Items
					DataSet DS = new DataSet();
					DS = GetSQL_Obj_DS.getObjc();
								
					var myTables = DS.Tables["Tables"].AsEnumerable().ToList().Select(r => new retObjts { Name = r.Field<string>("Tables"), Type = "Tables" });
			
					var myTableList = from s in myTables
									  select s;
	//HERE				
					IQueryable<retObjts>myI=myTableList.AsQueryable();	//<<<<<<<<<<<<<<<<<<<<<myQueryable			  
					var list = myI.Select(s=>new { s.Type, s.Name }).ToList();					  
		 			
				
					
		//HERE										  
									  
									  
									  
					
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
					let fileText = FileText.GetFileText(file.FullName)
					where fileText.Contains(searchTerm)
					select file.FullName;

					//	Dictionary<string, myFiles> myDict = new Dictionary<string, myFiles>();
					List<mySortedFiles> mySortedList = new List<mySortedFiles>();
					// Execute the query.
					Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
					for (int c = 0; c < fileList.Count(); c++)
					{
						//Console.WriteLine(fileList.ElementAt(c).FullName);
						string r = fileList.ElementAt(c).Name.ToString();
						r = r.Remove(r.Length - 4);

						mySortedFiles msf = new mySortedFiles(fileList.ElementAt(c).Directory.Parent.ToString(), 99, new myFiles(
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

					//find duplicates and abort if found											  
					var dups = mySortedList.GroupBy(x => x.myfiles.ObjName).Where(x => x.Count() > 1).Select(x => x.Key);

					if (dups.Count() > 0)
					{
						string e_out = string.Empty;
						foreach (var dup in dups)
						{
							e_out += dup.ToString() + " ";
						}
						throw new System.ArgumentException("Error thrown due to duplicates found!", "Please remove duplicates: " + e_out);

					}
					
					//foreach (var element in mySortedList.OrderBy(sl => sl.FolderOrder).ThenBy(sl => sl.FolderName).Where(sl => sl.FolderOrder!=5))
					foreach (var element in mySortedList.OrderBy(sl => sl.FolderOrder).ThenBy(sl => sl.FolderName))
					{
						//Console.WriteLine(element);
						if (consolidatedList.Select(l => l.ToString()).Contains(element.myfiles.ObjName.ToString()))
						{
							ScriptExecutor se = new ScriptExecutor();
							ExeResult = se.RunScript(element.myfiles.FullName);
							element.myfiles.ExecutionResults=ExeResult;
							ContainsList.Add(element.myfiles);
						}
						else
						{	
							ScriptExecutor se = new ScriptExecutor();
							ExeResult=se.RunScript(element.myfiles.FullName);
							element.myfiles.ExecutionResults=ExeResult;
							NotContainsList.Add(element.myfiles);
						}

					}




			//	string rollbackitem = rollbackitems.rObject("dbo.app_t_CCPCntlTotReconciliation","Table");
			//  Console.Write(rollbackitem);
			if (rollback == true)
			{
				//get rollback SQL
				rbi ret = new rbi();
				//rollbackitems rb = new rollbackitems();
				//ret=rb.rObjects(NotContainsList);
			//	ret = rb.RBI(NotContainsList);
				//var mytable = ret.retTable.AsEnumerable().ToList().Select(t => t.ItemArray);

				DataTable dt3 = ret.retTable;
				dt3.TableName = "Rollbacks";
				DS_Out.Tables.Add(dt3);

				string myrollbackscript = ret.ExeSQL.ToString();
				Console.WriteLine(myrollbackscript);

		//		ScriptExecutor se = new ScriptExecutor();
		//		se.ExecuteRollback(myrollbackscript);

			}

			DataTable dt1 = DTX.ToDataTable(ContainsList);
			dt1.TableName = "Contains";
			DataTable dt2 = DTX.ToDataTable(NotContainsList);
			dt2.TableName = "Not_Contains";
			DS_Out.Tables.Add(dt1);
			DS_Out.Tables.Add(dt2);

			string excelFilename = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\Sample.xlsx";
			//CreateExcelFile.CreateExcelDocument(DS_Out, excelFilename);
			CreateExcelFile.CreateExcelDocument(DS_Out, excelFilename);

			DS_Out.Dispose();

			ContainsList.Clear();
			NotContainsList.Clear();

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
}//class


public class mySortedFiles
{
	public string FolderName { get; set; }
	public int FolderOrder { get; set; }
	public myFiles myfiles { get; set; }

	public mySortedFiles() { }

	public mySortedFiles(string foldername, int folderorder, myFiles mf)
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
					FolderOrder = 5;
				}
				//Console.WriteLine("Default, undefined:" + mf.Path );
				// You cannot "fall through" any switch section, including
				// the last one. 
				//throw new Exception();
				break;
		}



	}//class

}

public class rbi
{
	public DataTable retTable;
	public string ExeSQL;
}

public class rollbackitems
{
	public DataTable dt = new DataTable();
	public rbi RBI(List<myFiles> inputlist)
	{
		//	string sql;
		System.Text.StringBuilder sql = new System.Text.StringBuilder();

		dt.Columns.Add("Object", typeof(string));
		dt.Columns.Add("SQL", typeof(string));

		foreach (var element in inputlist)
		{
			Console.WriteLine(rObject(element.ToString(), element.ObjType));
			sql.Append("  ");
			sql.Append(rObject(element.ToString(), element.ObjType));
			dt.Rows.Add(element.ObjName, rObject(element.ToString(), element.ObjType));

		}
		rbi retTB = new rbi { retTable = dt, ExeSQL = sql.ToString() };
		return retTB;

		//return sql.ToString();
	}

	public static string rObject(string ObjName, string ObjType)
	{
		string output;
		switch (ObjType)
		{

			case "Tables":
				string t = "IF OBJECT_ID('dbo.app_t_tmp_GRM_Claims_MP_DTHTPD', N'U') IS NOT NULL DROP TABLE dbo.app_t_tmp_GRM_Claims_MP_DTHTPD";
				output = t.Replace("dbo.app_t_tmp_GRM_Claims_MP_DTHTPD", ObjName);
			    return output;
             
			
			case "Views":
				string v="IF OBJECT_ID('dbo.app_vw_REI_Policy_GRM', N'U') IS NOT NULL DROP VIEW dbo.app_vw_REI_Policy_GRM";
				output=v.Replace("dbo.app_vw_REI_Policy_GRM",ObjName);
			 	return output;
			 
				
			case "Stored_Procedures":
				string p = "IF OBJECT_ID('dbo.app_sp_generic_Email_Notification', N'P') IS NOT NULL DROP PROCEDURE dbo.app_sp_generic_Email_Notification";
				output = p.Replace("dbo.app_sp_generic_Email_Notification", ObjName);
				return output;

			case "Functions":
				string f = "IF object_id(N'function_name', N'FN') IS NOT NULL DROP FUNCTION function_name";
				output= f.Replace("function_name",ObjName);
				return output;
				
			case "Scripts":
				return " ";
				
			 default:

				return " ";
		
		}
		
	}

}
//////////////
public static class DTX
{
	public static   DataTable ToDataTable<T>(this IList<T> list)
	{
		PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
		DataTable table = new DataTable();
		for (int i = 0; i < props.Count; i++)
		{
			PropertyDescriptor prop = props[i];
			table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
		}
		object[] values = new object[props.Count];
		foreach (T item in list)
		{
			for (int i = 0; i < values.Length; i++)
				values[i] = props[i].GetValue(item) ?? DBNull.Value;
			table.Rows.Add(values);
		}
		return table;
	}
}

public static class CreateExcelFile
{
	public static bool CreateExcelDocument<T>(List<T> list, string xlsxFilePath)
	{
		DataSet ds = new DataSet();
		ds.Tables.Add(ListToDataTable(list));

		return CreateExcelDocument(ds, xlsxFilePath);
	}

	//  This function is adapated from: http://www.codeguru.com/forum/showthread.php?t=450171
	//  My thanks to Carl Quirion, for making it "nullable-friendly".
	public static DataTable ListToDataTable<T>(List<T> list)
	{
		DataTable dt = new DataTable();

		foreach (PropertyInfo info in typeof(T).GetProperties())
		{
			dt.Columns.Add(new DataColumn(info.Name, GetNullableType(info.PropertyType)));
		}
		foreach (T t in list)
		{
			DataRow row = dt.NewRow();
			foreach (PropertyInfo info in typeof(T).GetProperties())
			{
				if (!IsNullableType(info.PropertyType))
					row[info.Name] = info.GetValue(t, null);
				else
					row[info.Name] = (info.GetValue(t, null) ?? DBNull.Value);
			}
			dt.Rows.Add(row);
		}
		return dt;
	}
	private static Type GetNullableType(Type t)
	{
		Type returnType = t;
		if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
		{
			returnType = Nullable.GetUnderlyingType(t);
		}
		return returnType;
	}
	private static bool IsNullableType(Type type)
	{
		return (type == typeof(string) ||
				type.IsArray ||
				(type.IsGenericType &&
				 type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
	}

	public static bool CreateExcelDocument(DataTable dt, string xlsxFilePath)
	{
		DataSet ds = new DataSet();
		ds.Tables.Add(dt);

		return CreateExcelDocument(ds, xlsxFilePath);
	}

	public static bool CreateExcelDocument(DataSet ds, string excelFilename)
	{
		try
		{
			using (SpreadsheetDocument document = SpreadsheetDocument.Create(excelFilename, SpreadsheetDocumentType.Workbook))
			{
				document.AddWorkbookPart();
				document.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

				//  My thanks to James Miera for the following line of code (which prevents crashes in Excel 2010)
				document.WorkbookPart.Workbook.Append(new BookViews(new WorkbookView()));

				//  If we don't add a "WorkbookStylesPart", OLEDB will refuse to connect to this .xlsx file !
				WorkbookStylesPart workbookStylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>("rIdStyles");
				Stylesheet stylesheet = new Stylesheet();
				workbookStylesPart.Stylesheet = stylesheet;

				CreateParts(ds, document);
			}
			Trace.WriteLine("Successfully created: " + excelFilename);
			return true;
		}
		catch (Exception ex)
		{
			Trace.WriteLine("Failed, exception thrown: " + ex.Message);
			return false;
		}
	}

	private static void CreateParts(DataSet ds, SpreadsheetDocument spreadsheet)
	{
		//  Loop through each of the DataTables in our DataSet, and create a new Excel Worksheet for each.
		uint worksheetNumber = 1;
		foreach (DataTable dt in ds.Tables)
		{
			//  For each worksheet you want to create
			string workSheetID = "rId" + worksheetNumber.ToString();
			string worksheetName = dt.TableName;

			WorksheetPart newWorksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
			newWorksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet();

			// create sheet data
			newWorksheetPart.Worksheet.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.SheetData());

			// save worksheet
			WriteDataTableToExcelWorksheet(dt, newWorksheetPart);
			newWorksheetPart.Worksheet.Save();

			// create the worksheet to workbook relation
			if (worksheetNumber == 1)
				spreadsheet.WorkbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());

			spreadsheet.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheet()
			{
				Id = spreadsheet.WorkbookPart.GetIdOfPart(newWorksheetPart),
				SheetId = (uint)worksheetNumber,
				Name = dt.TableName
			});

			worksheetNumber++;
		}

		spreadsheet.WorkbookPart.Workbook.Save();
	}


	private static void WriteDataTableToExcelWorksheet(DataTable dt, WorksheetPart worksheetPart)
	{
		var worksheet = worksheetPart.Worksheet;
		var sheetData = worksheet.GetFirstChild<SheetData>();

		string cellValue = "";

		//  Create a Header Row in our Excel file, containing one header for each Column of data in our DataTable.
		//
		//  We'll also create an array, showing which type each column of data is (Text or Numeric), so when we come to write the actual
		//  cells of data, we'll know if to write Text values or Numeric cell values.
		int numberOfColumns = dt.Columns.Count;
		bool[] IsNumericColumn = new bool[numberOfColumns];

		string[] excelColumnNames = new string[numberOfColumns];
		for (int n = 0; n < numberOfColumns; n++)
			excelColumnNames[n] = GetExcelColumnName(n);

		//
		//  Create the Header row in our Excel Worksheet
		//
		uint rowIndex = 1;

		var headerRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
		sheetData.Append(headerRow);

		for (int colInx = 0; colInx < numberOfColumns; colInx++)
		{
			DataColumn col = dt.Columns[colInx];
			AppendTextCell(excelColumnNames[colInx] + "1", col.ColumnName, headerRow);
			IsNumericColumn[colInx] = (col.DataType.FullName == "System.Decimal") || (col.DataType.FullName == "System.Int32");
		}

		//
		//  Now, step through each row of data in our DataTable...
		//
		double cellNumericValue = 0;
		foreach (DataRow dr in dt.Rows)
		{
			// ...create a new row, and append a set of this row's data to it.
			++rowIndex;
			var newExcelRow = new Row { RowIndex = rowIndex };  // add a row at the top of spreadsheet
			sheetData.Append(newExcelRow);

			for (int colInx = 0; colInx < numberOfColumns; colInx++)
			{
				cellValue = dr.ItemArray[colInx].ToString();

				// Create cell with data
				if (IsNumericColumn[colInx])
				{
					//  For numeric cells, make sure our input data IS a number, then write it out to the Excel file.
					//  If this numeric value is NULL, then don't write anything to the Excel file.
					cellNumericValue = 0;
					if (double.TryParse(cellValue, out cellNumericValue))
					{
						cellValue = cellNumericValue.ToString();
						AppendNumericCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
					}
				}
				else
				{
					//  For text cells, just write the input data straight out to the Excel file.
					AppendTextCell(excelColumnNames[colInx] + rowIndex.ToString(), cellValue, newExcelRow);
				}
			}
		}
	}

	private static void AppendTextCell(string cellReference, string cellStringValue, Row excelRow)
	{
		//  Add a new Excel Cell to our Row 
		Cell cell = new Cell() { CellReference = cellReference, DataType = CellValues.String };
		CellValue cellValue = new CellValue();
		cellValue.Text = cellStringValue;
		cell.Append(cellValue);
		excelRow.Append(cell);
	}

	private static void AppendNumericCell(string cellReference, string cellStringValue, Row excelRow)
	{
		//  Add a new Excel Cell to our Row 
		Cell cell = new Cell() { CellReference = cellReference };
		CellValue cellValue = new CellValue();
		cellValue.Text = cellStringValue;
		cell.Append(cellValue);
		excelRow.Append(cell);
	}

	private static string GetExcelColumnName(int columnIndex)
	{
		//  Convert a zero-based column index into an Excel column reference  (A, B, C.. Y, Y, AA, AB, AC... AY, AZ, B1, B2..)
		//
		//  eg  GetExcelColumnName(0) should return "A"
		//      GetExcelColumnName(1) should return "B"
		//      GetExcelColumnName(25) should return "Z"
		//      GetExcelColumnName(26) should return "AA"
		//      GetExcelColumnName(27) should return "AB"
		//      ..etc..
		//
		if (columnIndex < 26)
			return ((char)('A' + columnIndex)).ToString();

		char firstChar = (char)('A' + (columnIndex / 26) - 1);
		char secondChar = (char)('A' + (columnIndex % 26));

		return string.Format("{0}{1}", firstChar, secondChar);
	}
}
////////
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
			string conStr = getCompared(); //this will be Production

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
			
			return DS;

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			throw;
		}


	}

	public static string getCompared() //this will be production
	{
		return @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Integrated Security=SSPI;" +
	   "Initial Catalog=NorthWind; Asynchronous Processing=true";
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
	public static string GetConnectionString() //this will be where deployee to
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

	public string RunScript(string sqlFile)
	{
		bool Thrown = false;
//	Begin:

		string sqlConnectionString = ConnString.GetConnectionString();


		FileInfo file = new FileInfo(sqlFile);
		string exesScript = file.OpenText().ReadToEnd();

		try
		{
			Server server = new Server();
			server.ConnectionContext.ConnectionString = sqlConnectionString;
			server.ConnectionContext.ExecuteNonQuery(exesScript);
			
			if (Thrown) { throw new System.ArgumentException("Error thrown on rollback", "Rollback Selected"); }
			return "Success";
			
			
			
			
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
			
			return ex.InnerException.ToString();
			
 
		}

	}

	public void ExecuteRollback(string rollbacksql)
	{
		string sqlConnectionString = ConnString.GetConnectionString();
		try
		{
			Server server = new Server();
			server.ConnectionContext.ConnectionString = sqlConnectionString;
			server.ConnectionContext.ExecuteNonQuery(rollbacksql);
		}
		catch (Exception ex)
		{
		    Console.WriteLine("Error was caught: " + ex.Message + "Inner Message: " + ex.InnerException);
			throw;			
		}
	}
}//class
public class sortedFolders
{
	public string FolderName;
	public string OrderId;
	public string FolderType;

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
}



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

}