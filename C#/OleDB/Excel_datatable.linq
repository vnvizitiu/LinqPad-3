<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Namespace>System.Data.OleDb</Namespace>
</Query>

public void Main()
{
	OleDbConnection ExcelCon = new OleDbConnection();
	OleDbDataAdapter ExcelAdp = default(OleDbDataAdapter);
	OleDbCommand ExcelComm = default(OleDbCommand);
	//DataColumn Col1 = null;
	string strFilePath = "C:\\Users\\Administrator\\Downloads\\delete\\Linqpad.xlsx";
	try
	{
		ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source= " + strFilePath + ";Extended Properties=\"Excel 8.0;\"";
		ExcelCon.Open();

		dynamic StrSql = "Select * From [Sheet1$]";
		ExcelComm = new OleDbCommand(StrSql, ExcelCon);
		ExcelAdp = new OleDbDataAdapter(ExcelComm);
		DataTable  dt = new DataTable();
		ExcelAdp.Fill(dt);
		ExcelCon.Close();
		
		Console.WriteLine(dt.Columns.Count);

		for (int i = 0; i <= dt.Columns.Count - 1; i++)
		{
 			Console.WriteLine(dt.Columns[i].ToString());
 	//	Console.WriteLine(dt.Columns[i]);
		}
		
	 
		List<DataRow> mylist = dt.AsEnumerable().ToList();
	 
		
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
		ExcelCon = null;
		ExcelAdp = null;
		ExcelComm = null;
	}
}