<Query Kind="Program" />

 public class GetSQLobj
{
	public static string[] getSQL()
	{

		var arrSQL = new[] {"SELECT TABLE_NAME,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
									   ,"SELECT TABLE_NAME as View,* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW'"
									   ," SELECT name AS Function ,SCHEMA_NAME(schema_id) AS schema_name ,type_desc FROM sys.objects WHERE type_desc LIKE '%FUNCTION%';"
									   ,"select ROUTINE_NAME as Proc from Papa.information_schema.routines where routine_type = 'PROCEDURE'"};
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