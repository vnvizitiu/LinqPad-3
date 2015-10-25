<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

void Main()
{
	// DataContext takes a connection string. 
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=Northwind");

	// Get a typed table to run queries.
	Table<Customers> Customers = db.GetTable<Customers>();

	// Query for customers from London.
	var query =
		from cust in Customers
	//	where cust.CompanyName=="Sam"
		select cust;

	foreach (var cust in query)
		Console.WriteLine(cust.CompanyName);
		
		

}
[Table]
public class Customers
{
	[Column]
	public String CompanyName { get; set; }
	[Column]
	public String ContactName { get; set; }
 
	
}
// Define other methods and classes here
