<Query Kind="Program" />

void Main()
{
	// Connection string
	string connString = @" server=.\sql2012;database=AdventureWorks;Integrated Security=true";

	// Query
	string qry = @" select *
                           from HumanResources.Department
                            where GroupName = 'Manufacturing'";

	// SQL to insert employees
	string ins = @"insert into HumanResources.Department
                           (Name,GroupName, ModifiedDate)        
                            values(@Name, @GroupName, @ModifiedDate)";

	// Create connection
	SqlConnection conn = new SqlConnection(connString);

	try
	{
		// Create data adapter
		SqlDataAdapter da = new SqlDataAdapter();
		da.SelectCommand = new SqlCommand(qry, conn);

		// Create and fill dataset
		DataSet ds = new DataSet();
		da.Fill(ds, "HumanResources.Department");

		// Get data table reference
		DataTable dt = ds.Tables["HumanResources.Department"];

		// Add a row
		DataRow newRow = dt.NewRow();
		newRow["Name"] = "Microsoft Development";
		newRow["GroupName"] = "Global Development";
		newRow["ModifiedDate"] = "2012-04-28";
		dt.Rows.Add(newRow);

		// Display rows
		foreach (DataRow row in dt.Rows)
		{

			Console.WriteLine(row["Name"].ToString());
			Console.WriteLine("\t");
			Console.WriteLine(row["GroupName"].ToString());
			Console.WriteLine("\t");
			Console.WriteLine(row["ModifiedDate"].ToString());
			Console.WriteLine("\n");
		}

		// Create command
		SqlCommand cmd = new SqlCommand(ins, conn);
		//
		// Map parameters
		cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
		cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar, 50, "GroupName");
		cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 25, "ModifiedDate");

		// Insert department
		da.InsertCommand = cmd;
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
