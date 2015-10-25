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
		//ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source= " + strFilePath + ";Extended Properties=\"Excel 8.0;\"";
		ExcelCon.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
		ExcelCon.Open();

		dynamic StrSql = "Select * From [Sheet1$]";
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

	} 
	finally 
	{
		ExcelCon = null;
		ExcelAdp = null;
		ExcelComm = null;
	}
}