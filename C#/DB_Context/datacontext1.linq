<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
</Query>

void Main()
{
	string connStr =@"Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=LinqInAction;app=LINQPad [6.15 Multiple aggregates]";

	DataContext dc = new DataContext(connStr); // this;
	//DataContext dataContext = this;
	
	Console.WriteLine(Connection.ConnectionString);
	dc.Dump();

	var books = dc.GetTable<Book>();
	var query =
		  from book in books
		  group book by book.Subject into groupedBooks
		  select new
		  {
			  groupedBooks.Key,
			  TotalPrice = groupedBooks.Sum(b => b.Price),
			  LowPrice = groupedBooks.Min(b => b.Price),
			  HighPrice = groupedBooks.Max(b => b.Price),
			  AveragePrice = groupedBooks.Average(b => b.Price)
		  };

	query.Dump();



}

// Define other methods and classes here
