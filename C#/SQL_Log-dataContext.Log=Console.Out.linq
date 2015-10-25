<Query Kind="Statements">
  <Connection>
    <ID>5425ee32-433b-4bb8-9259-760ac63d355b</ID>
    <Persist>true</Persist>
    <Server>SAMMYPRO</Server>
    <Database>LinqInAction</Database>
  </Connection>
</Query>

//6.19: Original rewritten
//LINQPad abstracts the context. We'll set it to this.
DataContext dataContext = this;



Table<Subject> subjects = dataContext.GetTable<Subject>();
Table<Book> books = dataContext.GetTable<Book>();

var query =
	from subject in subjects
  	join book in books
		on subject.ID equals book.Subject
	where book.Price < 30
	orderby subject.Name
  	select new
	{
		subject.Name,
		book.Title,
		book.Price
	};

dataContext.Log = Console.Out;///get SQL sent to Server 

query.Dump();