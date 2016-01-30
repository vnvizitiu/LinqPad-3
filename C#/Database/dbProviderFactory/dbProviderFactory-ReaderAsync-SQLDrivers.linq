<Query Kind="Program">
  <Namespace>System.Data.Common</Namespace>
</Query>

class FactorySample /// HOME Unable to find the requested .Net Framework Data Provider. It may not be installed
{//https://docs.oracle.com/cd/B28359_01/win.111/b28375/OracleClientFactoryClass.htm
	static void Main()
	{//An OracleClientFactory object allows applications to instantiate ODP.NET classes in a generic way.
		string constr = @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN; Initial Catalog=NorthWind; Integrated Security=SSPI";

		DbProviderFactory factory =
				DbProviderFactories.GetFactory("System.Data.SqlClient"); //System.Data.OracleClient

		DbConnection conn = factory.CreateConnection();

		try
		{
			conn.ConnectionString = constr;
			conn.Open();

			DbCommand cmd = factory.CreateCommand();
			cmd.Connection = conn;
			cmd.CommandText = "select top 2 * from orders";

			DbDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
				Console.WriteLine(reader[0] + " : " + reader[1]);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
	}
}