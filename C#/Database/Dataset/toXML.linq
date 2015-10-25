<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @" server=.\sql2012; database=AdventureWorks;Integrated Security=true";

	// Query
	string qry = @"select Name ,ProductNumber
                           from Production.Product";

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		// Create Data Adapter
		SqlDataAdapter da = new SqlDataAdapter();
		da.SelectCommand = new SqlCommand(qry, conn);

		// Open connection
		conn.Open();

		// Create and Fill Dataset
		DataSet ds = new DataSet();
		da.Fill(ds, "Production.Product");

		// Extract dataset to XML file
		ds.WriteXml(@"c:\productstable.xml");
		Console.WriteLine("The XML file is Created");
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
