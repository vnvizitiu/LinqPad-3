<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

////PARAMTERS--PAGE 157 Programming Linq (Marco Russo-Microsoft Press)
void Main()

{
	// DataContext takes a connection string. 
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");

	var query = db.ExecuteQuery<EmployeeInfo>(@"
	WITH EmployeeHierarchy (EmployeeID, LastName, FirstName,
	ReportsTo, HierarchyLevel) AS
	( SELECT EmployeeID,LastName, FirstName,
	ReportsTo, 1 as HierarchyLevel
	FROM Employees
	WHERE ReportsTo IS NULL
	UNION ALL
	SELECT e.EmployeeID, e.LastName, e.FirstName,
	e.ReportsTo, eh.HierarchyLevel + 1 AS HierarchyLevel
	FROM Employees e
	INNER JOIN EmployeeHierarchy eh
	ON e.ReportsTo = eh.EmployeeID
	)
	SELECT *
	FROM EmployeeHierarchy
	ORDER BY HierarchyLevel, LastName, FirstName");

	db.Log = Console.Out;



	foreach (var element in query)
	{
		 Console.WriteLine(element);
	}
	
	////PARAMTERS--PAGE 157 Programming Linq (Marco Russo-Microsoft Press)
	var qquery = db.ExecuteQuery<CompanyOrders>(@"
	SELECT c.CompanyName, MIN( o.OrderDate ) AS FirstOrderDate,	MAX( o.OrderDate ) AS LastOrderDate	FROM Customers c
	LEFT JOIN Orders o ON o.CustomerID = c.CustomerID GROUP BY c.CustomerID, c.CompanyName HAVING COUNT(o.OrderDate) > 0
	AND MIN( o.OrderDate ) BETWEEN {0} AND {1} ORDER BY FirstOrderDate ASC",
	new DateTime(1997, 1, 1), new DateTime(1997, 12, 31));
	
	db.Log = Console.Out;
		
//	foreach (var element in qquery)
//	{
//		Console.WriteLine(element);
//	}
		List<CompanyOrders> _CompanyOrders = new List<CompanyOrders> { };
		
		_CompanyOrders=qquery.ToList();
		
		foreach (var l in _CompanyOrders)
		{
			Console.WriteLine(l);
		}
		
	 

}

public class EmployeeInfo
{
	public int EmployeeID;
	public string LastName;
	private string firstName;
	public int? ReportsTo; // int? Corresponds to Nullable<int>
	public int HierarchyLevel;
	
	 public string Firstname {
		get { return firstName; }
		set
		{
			if (value.Length > 5)
			{
				firstName = value + "__converted";
			 	Console.WriteLine("Error!  Name must be less than 5 characters!");
			}	
			else
				firstName= value;
		}

	}


}
public class CompanyOrders
{
	public string CompanyName;
	public DateTime FirstOrderDate;
	public DateTime LastOrderDate;


}