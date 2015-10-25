<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @"server=.\sql2012;database=AdventureWorks;Integrated Security=true";

	// Query
	string qry = @" select *
                          from HumanResources.Department
                           where GroupName = 'Research and Development' ";

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		// Create Data Adapter
		SqlDataAdapter da = new SqlDataAdapter();
		da.SelectCommand = new SqlCommand(qry, conn);

		// Create command builder
		SqlCommandBuilder cb = new SqlCommandBuilder(da);
		

		// Create and Fill Dataset
		DataSet ds = new DataSet();
		da.Fill(ds, "HumanResources.Department");

		// Get Data Table reference
		DataTable dt = ds.Tables["HumanResources.Department"];

		// Add a row
		DataRow newRow = dt.NewRow();
		newRow["Name"] = "Language Design";
		newRow["GroupName"] = "Research and Development";
		newRow["ModifiedDate"] = "2012-04-29";

		dt.Rows.Add(newRow);

		// Display rows
		foreach (DataRow row in dt.Rows)
		{
			Console.WriteLine(row["Name"].ToString());
			Console.WriteLine("\t\t");
			Console.WriteLine(row["GroupName"].ToString());
			Console.WriteLine("\t");
			Console.WriteLine(row["ModifiedDate"].ToString());
			Console.WriteLine("\n");
		}

		// Insert department
		da.Update(ds, "HumanResources.Department");
	}

	catch (Exception ex)
	{
		Console.WriteLine(ex.Message + ex.StackTrace);
	}

	finally
	{
		//Connection close
		conn.Close();
	}
}
 

// Define other methods and classes here
