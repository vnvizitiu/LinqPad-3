<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

void Main()//page 156 Programming Linq Framework 4
{
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");
	Table<Order> Orders = db.GetTable<Order>();
	var query =
	from o in Orders
	where o.Customer.Country == "USA"
	select o.OrderID;

	var xquery =
	from o in Orders
	where o.OrderID == 10528
	select o;
	foreach (var row in xquery)
	{
		Console.WriteLine(row.Customer.Country);
	}

	Console.WriteLine("next...................");
	Table<Customer> Customers = db.GetTable<Customer>();
	var qq =
			 from c in Customers
			 where c.Orders.Count > 5
			 select c;

	foreach (var row in qq)
	{
		Console.WriteLine(row.CompanyName);
		foreach (var order in row.Orders)
		{
			Console.WriteLine(order.OrderID);
		}
	}

	var qList =
			 from c in Customers
			 where c.Orders.Count > 5
			 select c;
	List<Customer> _Customers = new List<Customer> { };
	_Customers=qList.ToList();
	
	foreach (var q in _Customers)
	{
		Console.WriteLine(q);
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

	[Association(Storage = "_Customer", ThisKey = "CustomerID", IsForeignKey = true)]
	public Customer Customer
	{
		get { return this._Customer.Entity; }
		set { this._Customer.Entity = value; }
	}

	private EntityRef<Customer> _Customer;

	public Order()
	{
		_Customer = default(EntityRef<Customer>);
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