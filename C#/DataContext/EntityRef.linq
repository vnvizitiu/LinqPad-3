<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

void Main()//page 156 Programming Linq Framework 4
{
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=NorthWind");
	Table<Order> Orders = db.GetTable<Order>();
	 
	 
	Console.WriteLine("next...................");
	Table<Customer> Customers = db.GetTable<Customer>();

	 
	var query = from customer in db.GetTable<Customer>()
				select new
				{
					customer.CompanyName,
					customer.Country
				};
	Console.WriteLine(query.ToString());
	db.Log = Console.Out;
	
	foreach (var element in query)
	{
		Console.WriteLine(element.CompanyName+"  "+ element.Country);
	}

	Table<Order> Orderss = db.GetTable<Order>();
	var nquery =
	from o in Orders
	where o.OrderID == 10528
	select o;
	foreach (var row in nquery)
	{
		Console.WriteLine(row.Customer.Country);
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


}