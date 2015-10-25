<Query Kind="Program" />

void Main()
{
	// Assumes that customerConnection is a valid SqlConnection object.
	// Assumes that orderConnection is a valid OleDbConnection object.
		///SqlConnection conn = new SqlConnection(conStr);
	 
	try
	{
		string conStr= @"server=SAMMYPRO;database=Northwind;Integrated Security=SSPI";
		SqlConnection conn = new SqlConnection(conStr);

		SqlDataAdapter custAdapter = new SqlDataAdapter(
		  "SELECT * FROM dbo.Customers", conn);
		SqlDataAdapter ordAdapter = new SqlDataAdapter(
		  "SELECT * FROM Orders", conn);

		DataSet customerOrders = new DataSet();

		custAdapter.Fill(customerOrders, "Customers");
		ordAdapter.Fill(customerOrders, "Orders");

		DataRelation relation = customerOrders.Relations.Add("CustOrders",
		  customerOrders.Tables["Customers"].Columns["CustomerID"],
		  customerOrders.Tables["Orders"].Columns["CustomerID"]);

		foreach (DataRow pRow in customerOrders.Tables["Customers"].Rows)
		{
			Console.WriteLine(pRow["CustomerID"]);
			foreach (DataRow cRow in pRow.GetChildRows(relation))
				Console.WriteLine("\t" + cRow["OrderID"]);
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
		throw;
	}



}

// Define other methods and classes here
