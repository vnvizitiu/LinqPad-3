<Query Kind="Program">
  <GACReference>System.Data.OracleClient, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</GACReference>
  <Namespace>System</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.Common</Namespace>
</Query>

class FactorySample /// HOME Unable to find the requested .Net Framework Data Provider. It may not be installed
{//https://docs.oracle.com/cd/B28359_01/win.111/b28375/OracleClientFactoryClass.htm
  static void Main()
  {//An OracleClientFactory object allows applications to instantiate ODP.NET classes in a generic way.
    string constr = "user id=hr;password=fate;data source=orcl";
 
    DbProviderFactory factory =
            DbProviderFactories.GetFactory("Oracle.DataAccess.Client"); //System.Data.OracleClient
 
    DbConnection conn = factory.CreateConnection();
 
    try
    {
      conn.ConnectionString = constr;
      conn.Open();
 
      DbCommand cmd = factory.CreateCommand();
      cmd.Connection = conn;
      cmd.CommandText = "select * from employees";
 
      DbDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
        Console.WriteLine(reader[1] + " : " + reader[1]);
    }
    catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
	}
}