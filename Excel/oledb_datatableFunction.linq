<Query Kind="Program">
  <Namespace>System.Data.OleDb</Namespace>
</Query>

//Using System.Data.OleDb;
//http://stackoverflow.com/questions/14261655/best-fastest-way-to-read-an-excel-sheet-into-a-datatable
void Main()
{
	Console.WriteLine("lets begin");
	string strFilePath = "C:\\Users\\Administrator\\Downloads\\delete\\Linqpad.xlsx";
	////ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source= " + strFilePath + ";Extended Properties=\"Excel 8.0;\"";
	DataTable  rdt = new DataTable();
	rdt=ImportExceltoDatatable(strFilePath);
	Console.WriteLine(rdt.Columns.Count);
 	
	for (int i = 0; i <= rdt.Columns.Count - 1; i++)
		{
			Console.WriteLine(rdt.Columns[i].ToString());
			Console.WriteLine(rdt.Columns[i]);
		}
	
		List<DataRow> mylist = rdt.AsEnumerable().ToList();
	 
		
		foreach (DataRow element  in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString()+ " "+element.ItemArray[1].ToString()+ " "+element.ItemArray[2].ToString());
		}
		
}

public DataTable ImportExceltoDatatable(string filepath)
{
    // string sqlquery= "Select * From [SheetName$] Where YourCondition";
    string sqlquery = "Select * From [Sheet1$]";
    DataSet ds = new DataSet();
    string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
    OleDbConnection con = new OleDbConnection(constring + "");
    OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
    da.Fill(ds);
    DataTable dt = ds.Tables[0];
    return dt;
 
	
}
// Define other methods and classes here