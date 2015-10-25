<Query Kind="Program" />

class Program //http://www.dotnetperls.com/sqlconnection
{
	static void Main() {
		string connectionString = "Persist Security Info=False;Integrated Security=true; Initial Catalog=AdventureWorksDW2008R2;Server=SAMMYPRO";
		//
		// In a using statement, acquire the SqlConnection as a resource.
		//
		try {
			Console.WriteLine("trying");
			using(SqlConnection con = new SqlConnection(connectionString)) {
				// Open the SqlConnection.
				con.Open();
				using(SqlCommand command = new SqlCommand("SELECT TOP 10 SalesReasonKey,SalesReasonName,SalesReasonReasonType FROM DimSalesReason", con))
				using(SqlDataReader reader = command.ExecuteReader()) {
					while (reader.Read()) {
						Console.WriteLine("{0} {1} {2}",
						reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
					}
				}
			}
		} catch (Exception x) {
			//WriteLine (x.Message.ToString);
			Console.WriteLine("Error was caught: " + x.Message);
		} finally {
			Console.WriteLine("this will run regardless");

		}

	}
}