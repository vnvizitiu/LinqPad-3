<Query Kind="Program" />

public void Main()
{

	SqlConnection Conn = new SqlConnection();
	SqlDataAdapter Adpt = default(SqlDataAdapter);
	SqlCommand Cmd = default(SqlCommand);
	//DataColumn Col1 = null;
	//string strFilePath = @"X:\Finance\Systems Accounting\Diagnostics\ULD PM\Calibre St Andrews\CubesAutoLoad\2-2011.xls";
	try
	{
		Conn.ConnectionString = ConnString();
		Conn.Open();

		dynamic StrSql = "Select * From Person.EmailAddress";
		Cmd = new SqlCommand(StrSql, Conn);
		Adpt = new SqlDataAdapter(Cmd);
		DataTable dt = new DataTable();
		Adpt.Fill(dt);
		Conn.Close();

		Console.WriteLine(dt.Columns.Count);

		for (int i = 0; i <= dt.Columns.Count - 1; i++)
		{
			Console.WriteLine(dt.Columns[i].ToString());
			//	Console.WriteLine(dt.Columns[i]);
		}


		List<DataRow> mylist = dt.AsEnumerable().ToList();


		foreach (DataRow element in mylist)
		{
			Console.WriteLine(element.ItemArray[0].ToString() + " " + element.ItemArray[1].ToString() + " " + element.ItemArray[2].ToString());
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
	string result = @"Server=SAMMYPRO;Database=AdventureWorks2014;Trusted_Connection=True;";
	return result;
}//END