<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

void Main()//page 156 Programming Linq Framework 4
{
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");
	Table<Customer> Customers = db.GetTable<Customer>();
	
	var query =
	from c in Customers
	where c.Orders.Count > 20
	
	select c;
	foreach (var row in query)
	{
		Console.WriteLine(row.CompanyName);
		foreach (var order in row.Orders)
		{
			Console.WriteLine(order.OrderID);
		}
	}
}
[Table(Name = "Customers")]
public class Customer
{
	[Column(IsPrimaryKey = true)]
	public string CustomerID;
	[Column]
	public string CompanyName;
	[Column]
	public string Country;

	// The following is the code for Listing 5-7
	//[Association(OtherKey="CustomerID")]
	//public EntitySet<Order> Orders;

	// The following is the code for Listing 5-8
	private EntitySet<Order> _Orders;

	[Association(OtherKey = "CustomerID", Storage = "_Orders")]
	public EntitySet<Order> Orders
	{
		get { return this._Orders; }
		set { this._Orders.Assign(value); }
	}

	public Customer()
	{
		this._Orders = new EntitySet<Order>();
	}
}
[Table(Name = "Orders")]
public class Order
{
	[Column(IsPrimaryKey = true)]
	public int OrderID;
	[Column]
	private string CustomerID;
	[Column]
	public DateTime? OrderDate;




}

