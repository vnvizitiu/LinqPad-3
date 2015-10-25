<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @"server=.\sql2012; database=AdventureWorks;Integrated Security=SSPI";

	// Query 
	string sql = @"select * from  Person.Address";

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		conn.Open();

		SqlCommand cmd = new SqlCommand(sql, conn);
		SqlDataReader rdr = cmd.ExecuteReader();

		// Store Employees schema in a data table
		DataTable schema = rdr.GetSchemaTable();

		// Display info from each row in the data table.
		// Each row describes a column in the database table.

		foreach (DataRow row in schema.Rows)
		{
			foreach (DataColumn col in schema.Columns)
			{
				Console.WriteLine(col.ColumnName + " = " + row[col]);
				Console.WriteLine("\n");
			}
			Console.WriteLine("-----------------");
		}

		//Close reader
		rdr.Close();

	}
	catch (Exception err)
	{
		Console.WriteLine(err.ToString());
	}
	finally
	{
		//connection close
		conn.Close();
	}
}

// Define other methods and classes here
