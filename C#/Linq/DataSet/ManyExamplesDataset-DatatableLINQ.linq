<Query Kind="Program" />

void Main()
{
 	 
	
 //	DemoLinqToDataSet.LoadDataSetUsingDataAdapter();	
//	DemoLinqToDataSet.LoadDataSetWithCopyToDataTable();
//	DemoLinqToDataSet.AddDataWithCopyToDataTable();
//	DemoLinqToDataSet.QueryDataTable();
  //DemoLinqToDataSet.UntypedNullCheck();
	 DemoLinqToDataSet.CheckIntersect();
	
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

		var highDiscountOrders =
			from o in ds.Tables["OrderDetails"].AsEnumerable()
			where o.Field<double?>("Discount") > 0.2
			select o;

		DataTable highDiscountOrdersTable = highDiscountOrders.CopyToDataTable();
		highDiscountOrdersTable.TableName = "HighDiscountOrders";
		ds.Tables.Add(highDiscountOrdersTable);
 
	}

	public static void AddDataWithCopyToDataTable()
	{
		//
		// Listing 11-5
		//
		DataSet ds = LoadDataSetUsingDataAdapter();

		var highDiscountOrders =
			from o in ds.Tables["OrderDetails"].AsEnumerable()
			where o.Field<double?>("Discount") > 0.2
			select o;

		DataTable selectionTable = highDiscountOrders.CopyToDataTable();

		var lowDiscountOrders =
			from o in ds.Tables["OrderDetails"].AsEnumerable()
			where o.Field<double?>("Discount") < 0.05
			select o;

		lowDiscountOrders.CopyToDataTable(selectionTable, LoadOption.PreserveChanges);


	}

	public static void QueryDataTable()
	{
		//
		// Listing 11-6
		//
		DataSet ds = LoadDataSetUsingDataAdapter();
		DataTable orders = ds.Tables["Orders"];

		var query =
			from o in orders.AsEnumerable()
			where o.Field<DateTime>("OrderDate").Year >= 1998
			orderby o.Field<DateTime>("OrderDate") descending
			select o;


		for (int i = 0; i < query.Count(); i++)
		{
			Console.WriteLine(query.ElementAt(i).Field<String>("ShipName"));

		}

		foreach (var element in query)
		{
			Console.WriteLine(element.Field<String>("ShipAddress"));
			
		}
	}


	public static void QueryJoinDataTables()
	{
		//
		// Listing 11-7
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
 
	}

	public static void QueryUsingImplicitJoin()
	{
		//
		// Listing 11-8
		//
		DataSet ds = LoadDataSetUsingDataAdapter();
		DataTable orders = ds.Tables["Orders"];
		DataTable orderDetails = ds.Tables["OrderDetails"];
		ds.Relations.Add("OrderDetails",
						  orders.Columns["OrderID"],
						  orderDetails.Columns["OrderID"]);

		var query =
			from o in orders.AsEnumerable()
			where o.Field<DateTime>("OrderDate").Year >= 1998
			orderby o.Field<DateTime>("OrderDate") descending
			select new
			{
				OrderID = o.Field<int>("OrderID"),
				OrderDate = o.Field<DateTime>("OrderDate"),
				Amount = o.GetChildRows("OrderDetails").Sum(
							 od => od.Field<decimal>("UnitPrice")
								   * od.Field<short>("Quantity"))
			};

		 
	}

	public static void UntypedNullCheck()
	{
		DataSet ds = LoadDataSetUsingDataAdapter();
		DataTable orderDetails = ds.Tables["OrderDetails"];

		//
		// Listing 11-12
		//
		foreach (DataRow r in orderDetails.Rows)
		{
			double? discount = r.Field<double?>("Discount");
			if (discount.HasValue && discount.Value > 0.10)
			{
				r.SetField<double?>("Discount", 0.10);
			}
		}

 
	}

	//	// Find the intersection of the two queries
	//	var queryOrders = oldOrders.AsEnumerable().Intersect(
	//	lowFreightOrders.AsEnumerable(),
//	DataRowComparer.Default);

	public static void CheckIntersect()
	{
	//page 354 programming LINQ
		//		Important If you do not use DataRowComparer.Default as an equality comparer when DataRow
		//comparison is involved, the comparison could be false even if the rows have the same content but
		//a different instance reference. LINQ operators that should use this comparer are Distinct, Except,
		//Intersect, and Union.
		DataSet ds = LoadDataSetUsingDataAdapter();
		string filterCustomerID = "QUICK";

		 Console.WriteLine(ds.Tables.Count);
		 

		//
		// Listing 11-13
		//
		var queryOldOrders =
			from o in ds.Tables["Orders"].AsEnumerable()
			where o.Field<DateTime>("OrderDate").Year>=1997
			select o;

		var queryLowFreightOrders =
			from o in ds.Tables["Orders"].AsEnumerable()
			where o.Field<DateTime>("OrderDate").Year <= 1997
			select o;

		DataTable oldOrders = queryOldOrders.CopyToDataTable();
		DataTable lowFreightOrders = queryLowFreightOrders.CopyToDataTable();

		// Find the intersection of the two queries
		var queryOrders = oldOrders.AsEnumerable().Intersect(
							  lowFreightOrders.AsEnumerable(),
							  DataRowComparer.Default);

		DataTable orders = queryOrders.CopyToDataTable();

		var  OrdersExcept = oldOrders.AsEnumerable().Except(
							  lowFreightOrders.AsEnumerable(),
							  DataRowComparer.Default);

		DataTable Except = queryOrders.CopyToDataTable();
//■■ Distinct
//■■ Except
//■■ Intersect
//■■ Union

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