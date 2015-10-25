<Query Kind="Program">
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
</Query>

//Linq In Action- page 211
void Main()

{
	// DataContext takes a connection string. 
	DataContext db = new DataContext("Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=LinqInAction");

	// Get a typed table to run queries.
	Table<Book> Books = db.GetTable<Book>();

	// Query for customers from London.
	var query = from book in db.GetTable<Book>()
				select new
				{
					book.Title,
					book.Price,
					book.Summary
				};
	db.Log = Console.Out;

	var pagedTitles = query.Skip(2);
	var titlesToShow = pagedTitles.Take(2);
	titlesToShow.Dump();

	foreach (var element in query)
	{
		Console.WriteLine(element.Title);
	}


}

[Table]
public class Book
{
	[Column(Name = "ID", IsPrimaryKey = true)]
	public Guid BookId { get; set; }
	[Column]
	public String Isbn { get; set; }
	[Column(CanBeNull = true)]
	public String Notes { get; set; }
	[Column]
	public Int32 PageCount { get; set; }
	[Column]
	public Decimal Price { get; set; }
	[Column(CanBeNull = true)]
	public String Summary { get; set; }
	[Column(Name = "PubDate")]
	public DateTime PublicationDate { get; set; }
	[Column]
	public String Title { get; set; }
	[Column(Name = "Subject")]
	public Guid SubjectId { get; set; }
	[Column(Name = "Publisher")]
	public Guid PublisherId { get; set; }
}