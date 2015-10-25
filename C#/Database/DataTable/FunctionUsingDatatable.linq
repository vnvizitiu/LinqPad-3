<Query Kind="Program" />

void Main()
{
	DataTable dt = new DataTable();
	string sql = "Select * from Categories";
	//String cString= new ConnString.
	dt = GetSQLobj.getObj(sql,ConnString.getConn());
	dt.Dump();
}

public static class GetSQLobj
{
	public static DataTable getObj(string sql, string conStr)
	{
		try
		{
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

public static class ConnString
{
	public static string getConn()/// removing static keyword will break http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
	{
		//string result = @"Server=vaunswd044\sqluat_ciapps2;Database=ThreeWayRec;Trusted_Connection=True;";
		string result = @"Server=SAMMYPRO;Database=Northwind;Trusted_Connection=True;";
		return result;
	}
  
}