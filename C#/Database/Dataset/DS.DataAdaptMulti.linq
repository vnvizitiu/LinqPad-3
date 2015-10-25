<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @"server=.\sql2012; database=AdventureWorks; Integrated Security=true";

	// Query1 
	string sql1 = @" select *
                           from Production.Product
                           where Name Like 'Mountain%'";

	// Query2 
	string sql2 = @" select *
                           from Production.Location
                           where CostRate > 10.0 ";

	// Combine queries
	string sql = sql1 + sql2;

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		// Create Data Adapter
		SqlDataAdapter da = new SqlDataAdapter();
		da.SelectCommand = new SqlCommand(sql, conn);

		// Create and Fill Data Set
		DataSet ds = new DataSet();
		da.Fill(ds, "Production.Product");

		// Get the data tables collection
		DataTableCollection dtc = ds.Tables;

		// Display data from first data table
		//
		// Display output header
		Console.WriteLine("Results from Product table:\n");
		Console.WriteLine("***************************************************\n");
		Console.WriteLine("Name\t\t\t\tProductNumber\n");

		Console.WriteLine("_________________________________________\n");
		// set display filter
		string fl = "Color = 'Black'";

		// Set sort
		string srt = "ProductNumber asc";

		// display filtered and sorted data
		foreach (DataRow row in dtc["Production.Product"].Select(fl, srt))
		{
			Console.WriteLine(row["Name"].ToString().PadRight(25));
			Console.WriteLine("\t\t");
			Console.WriteLine(row["ProductNumber"].ToString());
			Console.WriteLine(Environment.NewLine);
		}

		Console.WriteLine("============================================\n");
		// Display data from second data table

		// Display output header

		Console.WriteLine("Results from Location table:\n");
		Console.WriteLine("***********************************************\n");
		Console.WriteLine("Name\t\t\tCostRate\n");
		Console.WriteLine("__________________________________________\n");

		// Display data
		foreach (DataRow row in dtc[1].Rows)
		{
			Console.WriteLine(row["Name"].ToString().PadRight(25));
			Console.WriteLine("\t");
			Console.WriteLine(row["CostRate"].ToString());
			Console.WriteLine(Environment.NewLine);
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message + ex.StackTrace);
	}

	finally
	{
		// Connection close
		conn.Close();
	}
}

// Define other methods and classes here
