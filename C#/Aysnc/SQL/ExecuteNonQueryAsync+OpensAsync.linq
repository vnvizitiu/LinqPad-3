<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class A {
//https://msdn.microsoft.com/en-us/library/hh211418%28v=vs.110%29.aspx
	static async Task<int> Method(SqlConnection conn, SqlCommand cmd)
	{
		await conn.OpenAsync();
		await cmd.ExecuteNonQueryAsync();
		return 1;
	}

	public static void Main()
	{
		using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E80R7DQ\SQL_MAIN; Initial Catalog=NorthWind; Integrated Security=SSPI"))
		{
			SqlCommand command = new SqlCommand("select top 2 * from orders", conn);

			int result = A.Method(conn, command).Result;

			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
				Console.WriteLine(String.Format("{0}", reader[0]));
		}
	}
}