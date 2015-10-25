<Query Kind="Program" />

void Main()
{
 	 
	
 //	DemoLinqToDataSet.LoadDataSetUsingDataAdapter();	
 	DemoLinqToDataSet.LoadDataSetWithCopyToDataTable();
 
}

 class  DemoLinqToDataSet 
{
	const string ConnectionString = @"server=DESKTOP-E80R7DQ\SQL_MAIN;database=Northwind;Integrated Security=SSPI";

	public  static DataSet LoadDataSetUsingDataAdapter()
	{
		//
		// Listing 11-1
		//
		const string QueryOrders = @"
SELECT  OrderID, OrderDate, Freight, ShipName, 
        ShipAddress, ShipCity, ShipCountry
FROM    Orders
WHERE   CustomerID = @CustomerID

SELECT     od.OrderID, od.UnitPrice, od.Quantity, CAST( NULLIF( od.Discount, 0 ) AS FLOAT ) AS Discount,
           p.[ProductName]
FROM       [Order Details] od
INNER JOIN Orders o 
      ON   o.[OrderID] = od.[OrderID]
LEFT JOIN  Products p
     ON    p.[ProductID] = od.[ProductID]
WHERE      o.CustomerID = @CustomerID";

		DataSet ds = new DataSet("CustomerOrders");
		SqlDataAdapter da = new SqlDataAdapter(QueryOrders, ConnectionString);
		da.SelectCommand.Parameters.AddWithValue("@CustomerID", "QUICK");
		da.TableMappings.Add("Table", "Orders");
		da.TableMappings.Add("Table1", "OrderDetails");
		da.Fill(ds);

		return ds;
	}

	public static void LoadDataSetWithCopyToDataTable()
	{
		//
		// Listing 11-4
		//
		DataSet ds = LoadDataSetUsingDataAdapter();
		DataTable orders = ds.Tables["Orders"];
		DataTable orderDetails = ds.Tables["OrderDetails"];

		var query =
			   from o in orders.AsEnumerable()
			   join od in orderDetails.AsEnumerable()
					   on o.Field<int>("OrderID") equals od.Field<int>("OrderID")
					   into orderLines
			   where o.Field<DateTime>("OrderDate").Year >= 1998
			   orderby o.Field<DateTime>("OrderDate") descending
			   select new
			   {
				   OrderID = o.Field<int>("OrderID"),
				   OrderDate = o.Field<DateTime>("OrderDate"),
				   Amount = orderLines.Sum(
								od => od.Field<decimal>("UnitPrice")
									  * od.Field<short>("Quantity"))
			   };

		Console.WriteLine("Before: " + ds.Tables.Count);
		
		ds.Tables.Add(query.CreateDataTable("Output"));
		
		Console.WriteLine("After: " +ds.Tables.Count);
 		
	}

	 
}// top class


public static class DataSetHelper
{
	private static bool IsNullableType(Type type)
	{
		return (type.IsGenericType
				&& type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
	}

	public static DataTable CreateDataTable<T>(this IEnumerable<T> query, string tableName)
	{
		DataTable table = new DataTable(tableName);
		var fields = typeof(T).GetProperties();
		// Create columns
		foreach (var field in fields)
		{
			DataColumn column = new DataColumn(field.Name);
			column.AllowDBNull =
				(typeof(T).IsSubclassOf(typeof(ValueType))) ?
				IsNullableType(typeof(T)) :
				true;
			table.Columns.Add(column);
		}
		// Copy rows
		foreach (var row in query)
		{
			object[] values = new object[fields.Length];
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = fields[i].GetValue(row, null);
			}
			table.Rows.Add(values);
		}
		return table;
	}
}