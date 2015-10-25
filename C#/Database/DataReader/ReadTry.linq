<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @"server=.\sql2012;database=AdventureWorks;Integrated Security=SSPI";

	// Query
	string sql = @"select Name from Production.Product";

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		// Open connection
		conn.Open();

		// Create command
		SqlCommand cmd = new SqlCommand(sql, conn);

		// Create data reader
		SqlDataReader rdr = cmd.ExecuteReader();

		// Loop through result set
		while (rdr.Read())
		{
			// Print one row at a time
			Console.WriteLine(rdr[0]);
		}

		// Close data reader
		rdr.Close();
	}

	catch (SqlException ex)
	{
		Console.WriteLine(ex.Message + ex.StackTrace);
	}

	finally
	{
		conn.Close();
	}
}

// Define other methods and classes here
