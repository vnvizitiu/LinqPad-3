<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main() //https://msdn.microsoft.com/en-us/library/bb399340(v=vs.110).aspx
{	//https://msdn.microsoft.com/en-us/library/bb399415%28v=vs.110%29.aspx
#region
	try
	{
		// Fill the DataSet.
		DataSet ds = new DataSet();
		ds.Locale = CultureInfo.InvariantCulture;
		 


		// Create a new adapter and give it a query to fetch sales order, contact,  
		// address, and product information for sales in the year 2002. Point connection  
		// information to the configuration setting "AdventureWorks".
		string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks2014;"
			+ "Integrated Security=true;";


		SqlDataAdapter da = new SqlDataAdapter(
			"SELECT SalesOrderID, ContactID, OrderDate, OnlineOrderFlag, " +
			"TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " +
			"FROM Sales.SalesOrderHeader " +
			"WHERE DATEPART(YEAR, OrderDate) = @year; " +

			"SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " +
			"d.ProductID, d.UnitPrice " +
			"FROM Sales.SalesOrderDetail d " +
			"INNER JOIN Sales.SalesOrderHeader h " +
			"ON d.SalesOrderID = h.SalesOrderID  " +
			"WHERE DATEPART(YEAR, OrderDate) = @year; " +

			"SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " +
			"p.Color, p.ListPrice, p.Size, p.Class, p.Style, p.Weight  " +
			"FROM Production.Product p; " +

			"SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " +
			"a.City, a.StateProvinceID, a.PostalCode " +
			"FROM Person.Address a " +
			"INNER JOIN Sales.SalesOrderHeader h " +
			"ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " +
			"WHERE DATEPART(YEAR, OrderDate) = @year; " +

			"SELECT DISTINCT c.ContactID, c.Title, c.FirstName, " +
			"c.LastName, c.EmailAddress, c.Phone " +
			"FROM Person.Contact c " +
			"INNER JOIN Sales.SalesOrderHeader h " +
			"ON c.ContactID = h.ContactID " +
			"WHERE DATEPART(YEAR, OrderDate) = @year;",
		connectionString);

		// Add table mappings.
		da.SelectCommand.Parameters.AddWithValue("@year", 2002);
		da.TableMappings.Add("Table", "SalesOrderHeader");
		da.TableMappings.Add("Table1", "SalesOrderDetail");
		da.TableMappings.Add("Table2", "Product");
		da.TableMappings.Add("Table3", "Address");
		da.TableMappings.Add("Table4", "Contact");

		// Fill the DataSet.
		da.Fill(ds);

		// Add data relations.
		DataTable orderHeader = ds.Tables["SalesOrderHeader"];
		DataTable orderDetail = ds.Tables["SalesOrderDetail"];
		DataRelation order = new DataRelation("SalesOrderHeaderDetail",
								 orderHeader.Columns["SalesOrderID"],
								 orderDetail.Columns["SalesOrderID"], true);
		ds.Relations.Add(order);

		DataTable contact = ds.Tables["Contact"];
		DataTable orderHeader2 = ds.Tables["SalesOrderHeader"];
		DataRelation orderContact = new DataRelation("SalesOrderContact",
										contact.Columns["ContactID"],
										orderHeader2.Columns["ContactID"], true);
		ds.Relations.Add(orderContact);
		#endregion




		var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();
		var details = ds.Tables["SalesOrderDetail"].AsEnumerable();

		var query =
			from orderx in orders
			join detail in details
			on orderx.Field<int>("SalesOrderID")
			equals detail.Field<int>("SalesOrderID") into ords
			select new
			{
				CustomerID =
					orderx.Field<int>("SalesOrderID"),
				ords = ords.Count()
			};

		foreach (var orderx in query)
		{
			Console.WriteLine("CustomerID: {0}  Orders Count: {1}",
				orderx.CustomerID,
				orderx.ords);
		}


	}
	catch (SqlException ex)
	{
		Console.WriteLine("SQL exception occurred: " + ex.Message);
	}
}

// Define other methods and classes here
