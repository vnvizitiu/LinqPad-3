<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data.Common</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class A {//https://msdn.microsoft.com/en-us/library/hh211418%28v=vs.110%29.aspx
   static async Task PerformDBOperationsUsingProviderModel(string connectionString, string providerName) {
      DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
      using (DbConnection connection = factory.CreateConnection()) {
         connection.ConnectionString = connectionString;
         await connection.OpenAsync();

         DbCommand command = connection.CreateCommand();
         command.CommandText = "SELECT * FROM AUTHORS";

         using (DbDataReader reader = await command.ExecuteReaderAsync()) {
            while (await reader.ReadAsync()) {
               for (int i = 0; i < reader.FieldCount; i++) {
                  // Process each column as appropriate
                  object obj = await reader.GetFieldValueAsync<object>(i);
                  Console.WriteLine(obj);
               }
            }
         }
      }
   }

   public static void Main()
	{
		SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
		// replace these with your own values
		builder.DataSource = @"DESKTOP-E80R7DQ\SQL_MAIN";
		builder.InitialCatalog = "pubs";
		builder.IntegratedSecurity = true;
		string provider = "System.Data.SqlClient";

		Task task = PerformDBOperationsUsingProviderModel(builder.ConnectionString, provider);
		task.Wait();
		Console.WriteLine("Finsihed");
	}
}
