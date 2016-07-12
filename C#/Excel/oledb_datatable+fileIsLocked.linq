<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

public void Main()
{
	OleDbConnection ExcelCon = new OleDbConnection();
	OleDbDataAdapter ExcelAdp = default(OleDbDataAdapter);
	OleDbCommand ExcelComm = default(OleDbCommand);
	//DataColumn Col1 = null;
	string strFilePath = @"t:\SI.csv";
	try
	{
		ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source= " + strFilePath + ";Extended Properties=\"Excel 8.0;\"";
		//ExcelCon.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
		ExcelCon.Open();

		dynamic StrSql = "Select * From [si$]";
		ExcelComm = new OleDbCommand(StrSql, ExcelCon);
		ExcelAdp = new OleDbDataAdapter(ExcelComm);
		DataTable  objdt = new DataTable();
		ExcelAdp.Fill(objdt);
		ExcelCon.Close();
		
		Console.WriteLine(objdt.Columns.Count);

		for (int i = 0; i <= objdt.Columns.Count - 1; i++)
		{
			Console.WriteLine(objdt.Columns[i].ToString());
			Console.WriteLine(objdt.Columns[i]);
		}
	
			List<DataRow> mylist = objdt.AsEnumerable().ToList();
	 
		
		foreach (DataRow element  in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString()+ " "+element.ItemArray[1].ToString()+ " "+element.ItemArray[2].ToString());
		}
		
 
	//  ExcelCon.Close()
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
	} 
	finally 
	{
		Helper.CanReadFile(@"t:\SI.csv");
		ExcelCon = null;
		ExcelAdp = null;
		ExcelComm = null;
	}
}
internal static class Helper
{
	const int ERROR_SHARING_VIOLATION = 32;
	const int ERROR_LOCK_VIOLATION = 33;

	public static bool IsFileLocked(Exception exception)
	{
		int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
		return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
	}

	public static bool CanReadFile(string filePath)
	{
		//Try-Catch so we dont crash the program and can check the exception
		try
		{
			//The "using" is important because FileStream implements IDisposable and
			//"using" will avoid a heap exhaustion situation when too many handles  
			//are left undisposed.
			using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
				if (fileStream != null) fileStream.Close();  //This line is me being overly cautious, fileStream will never be null unless an exception occurs... and I know the "using" does it but its helpful to be explicit - especially when we encounter errors - at least for me anyway!
			}
		}
		catch (IOException ex)
		{
			//THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
			if (IsFileLocked(ex))
			{
				// do something, eg File.Copy or present the user with a MsgBox - I do not recommend Killing the process that is locking the file
				Console.WriteLine(ex.ToString());

				return false;
			}
		}
		finally
		{ }
		return true;
	}
}
 

// Def