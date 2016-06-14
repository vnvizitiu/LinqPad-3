<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

//Linq In Action- page 211
void Main()

{
	// DataContext takes a connection string. 
 	//	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");
	CallStoredProcedure();

 

 
}
public static void CallStoredProcedure()
{
	SampleDb db = new SampleDb("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");
	db.Log = Console.Out;

	foreach (var row in db.CustomersByCity("London"))
	{
		Console.WriteLine("{0} {1}", row.CustomerID, row.CompanyName);
	}
	
	
	var mySingleCity=db.CustomersByCity("London").SingleOrDefault().City;
	Console.WriteLine(mySingleCity);
	var myOtherSingle=db.CustomersByCity("Sydney").SingleOrDefault().CompanyName;
	
	
	
	
	
	
	IMultipleResults results = db.TwoCustomerGroups();
	foreach (var row in results.GetResult<CustomerInfo>())
	{
		Console.WriteLine("{0} {1} - {2} ({3})", row.CustomerID, row.City, row.CompanyName, row.ContactName);
	}
	Console.WriteLine("---");
	foreach (var row in results.GetResult<CustomerShortInfo>())
	{
		Console.WriteLine("{0} {1} - {2}", row.CustomerID, row.City, row.CompanyName);
	}

	// ******************************
	// DEMO COMPOSABILITY STORED PROCEDURE (does not compose a SQL query!)
	//
	var query =
		from c in db.CustomersByCity("London")
		where c.CompanyName.Length > 15 
		select new { c.CustomerID, c.CompanyName };

	Console.WriteLine("** COMPOSABILITY **");
	foreach (var row in query)
	{
		Console.WriteLine(row);
	}
	//
	// ******************************


}

public class SampleDb : DataContext
{
	public SampleDb(IDbConnection connection) : base(connection) { }
	public SampleDb(string fileOrServerOrConnection) : base(fileOrServerOrConnection) { }
	public SampleDb(IDbConnection connection, MappingSource mapping) : base(connection, mapping) { }

	public Table<Customer> Customers;

	// ************************************************
	// ************************************************
	// 
	// Listing 5-12
	// 
	[Function(Name = "Customers by City", IsComposable = false)]
	public ISingleResult<CustomerInfo> CustomersByCity(string param1)
	{
		IExecuteResult executeResult =
			this.ExecuteMethodCall(
					 this,
					 (MethodInfo)(MethodInfo.GetCurrentMethod()), // Get Stored Procedure Name
					 param1);    // Stored Procedure Parameter
		ISingleResult<CustomerInfo> result =
			(ISingleResult<CustomerInfo>)executeResult.ReturnValue;
		return result;
	}

	// 
	// Listing 5-13
	// 
	[Function(Name = "TwoCustomerGroups", IsComposable = false)]
	[ResultType(typeof(CustomerInfo))]
	[ResultType(typeof(CustomerShortInfo))]
	public IMultipleResults TwoCustomerGroups()
	{
		IExecuteResult executeResult =
				 this.ExecuteMethodCall(
					 this,
					 (MethodInfo)(MethodInfo.GetCurrentMethod()));
		IMultipleResults result =
			(IMultipleResults)executeResult.ReturnValue;
		return result;
	}

	// 
	// Listing 5-14
	// 
	[Function(Name = "dbo.MinUnitPriceByCategory", IsComposable = true)]
	public decimal? MinUnitPriceByCategory(int? categoryID)
	{
		IExecuteResult executeResult =
			this.ExecuteMethodCall(
				this,
				((MethodInfo)(MethodInfo.GetCurrentMethod())),
				categoryID);
		decimal? result = (decimal?)executeResult.ReturnValue;
		return result;
	}

	// 
	// Listing 5-15
	// 
	[Function(Name = "dbo.CustomersByCountry", IsComposable = true)]
	public IQueryable<Customer> CustomersByCountry(string country)
	{
		return this.CreateMethodCallQuery<Customer>(
			this,
			((MethodInfo)(MethodInfo.GetCurrentMethod())),
			country);
	}
}
static public class Extensions
{
	public static string Highlight(this string s)
	{
		return "** " + s + " **";
	}
}

public class CustomerData
{
	public CustomerData(string customerID, string companyName)
	{
		this.CustomerID = customerID;
		this.Name = companyName;
	}
	public CustomerData()
	{
	}

	public string CustomerID;
	public string Name;
}

public class CustomerShortInfo
{
	public string CustomerID;
	public string CompanyName;
	public string City;
}

public class CustomerInfo
{
	public string CustomerID;
	public string CompanyName;
	public string City;
	public string ContactName;
}
public class EmployeeInfo
{
	public int EmployeeID;
	public string LastName;
	public string FirstName;
	public int? ReportsTo; // int? Corresponds to Nullable<int>
	public int HierarchyLevel;

	public override string ToString()
	{
		return String.Format("ID={0} LastName={1} FirstName={2} ReportsTo={3} HierarchyLevel={4}",
							  this.EmployeeID, this.LastName, this.FirstName, this.ReportsTo, this.HierarchyLevel);
	}

}
//
[Table(Name = "Customers")]
public class Customer
{
	[Column(IsPrimaryKey = true)]
	public string CustomerID;
	[Column]
	public string CompanyName;
	[Column]
	public string City;
	[Column(Name = "Region")]
	public string State;
	[Column]
	public string Country;
}