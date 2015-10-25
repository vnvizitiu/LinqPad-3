<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Namespace>System.Data.OleDb</Namespace>
</Query>

public void Main()
{
	OleDbConnection Conn = new OleDbConnection();
	OleDbDataAdapter Adpt = default(OleDbDataAdapter);
	OleDbCommand Cmd = default(OleDbCommand);//DataColumn Col1 = null;
	//string strFilePath = @"X:\Finance\Systems Accounting\Diagnostics\ULD PM\Calibre St Andrews\CubesAutoLoad\2-2011.xls";
	try
	{
		 Conn.ConnectionString = ConnString();
		Conn.Open();

		dynamic StrSql = "Select * From app_run_no";
		Cmd = new OleDbCommand(StrSql, Conn);
		Adpt = new OleDbDataAdapter(Cmd);
		DataTable  dt = new DataTable();
		Adpt.Fill(dt);
		Conn.Close();
		
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
		
 
	//  Conn.Close()
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.InnerException.ToString());
	} 
	finally 
	{
		Conn = null;
		Adpt = null;
		Cmd = null;
	}
}
 public static string ConnString()/// removing static keyword will break http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
      { 
         string result = @"Provider=sqloledb;Data Source=vaunswd044\sqluat_ciapps2;Initial Catalog=ThreeWayRec;Integrated Security=SSPI;";
         return result;
      }//END  

// Define other methods and classes here
