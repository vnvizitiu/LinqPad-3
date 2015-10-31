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
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

void Main()
{	//http://stackoverflow.com/questions/7246413/reading-an-excel-file-from-c-sharp
	try
	{

		string startFolder = @"C:\Users\Sam\Downloads\Delete\Excel\";
		System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
		IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.xls*", System.IO.SearchOption.AllDirectories).OrderBy(d => d.DirectoryName).ThenBy(d => d.FullName);
	 

		OleDbConnection ExcelCon = new OleDbConnection();
		OleDbDataAdapter ExcelAdp = default(OleDbDataAdapter);
		OleDbCommand ExcelComm = default(OleDbCommand);
	 	DataSet DS = new DataSet();
		

		for (int c = 0; c < fileList.Count(); c++)
		{
			Console.WriteLine(fileList.ElementAt(c).FullName);
			//string strFilePath = @"C:\Users\Administrator\Downloads\delete\Linqpad.xlsx";
			string strFilePath =fileList.ElementAt(c).FullName.ToString();

			ExcelCon.ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", fileList.ElementAt(c).FullName);
			//2003 string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended 		
			Console.WriteLine(ExcelCon);

			ExcelCon.Open();
			dynamic StrSql = "Select * From [Contains$]";
			ExcelComm = new OleDbCommand(StrSql, ExcelCon);
			ExcelAdp = new OleDbDataAdapter(ExcelComm);
			DataTable  dt = new DataTable();
			dt.TableName="Table_"+ c;
			ExcelAdp.Fill(dt);
			
			DS.Tables.Add(dt);
			
			
			ExcelCon.Close();
		
	
		}
		
		int table = Convert.ToInt32(DS.Tables.Count);// count the number of table in dataset
		
		for (int i = 1; i < table; i++)// set the table value in list one by one
		{	
			Console.WriteLine(DS.Tables[i].TableName.ToString());
			foreach (DataRow dr in DS.Tables[i].Rows)
		{
			///consolidatedList.Add(new retObjts { Name = Convert.ToString(dr["Tables"]), Type=DS.Tables[i].TableName });
			Console.WriteLine(dr);
			
		}
		}




	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
		throw;
	}


}

// Define other methods and classes here
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