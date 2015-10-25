<Query Kind="Program" />

void Main() //http://blogs.msdn.com/b/csharpfaq/archive/2009/03/25/how-to-use-linq-methods-to-compare-objects-of-custom-types.aspx
{
	List<Book> Books = new List<Book>() {
  new Book { Title="LINQ in Action", Cost=10, Publisher="Sam" },
  new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
	new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
	  new Book { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"},
  new Book { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};

	List<nBook> nBooks = new List<nBook>() {
  new nBook { Title="LINQ in Action", Cost=10, Publisher="Samxx" },
		//  new nBook { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
		new nBook { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};




////	var commonUsers = Books.Select(l1 => l1.Publisher)
////			   .Where(u => nBooks.Select(l2 => l2.Publisher)
////								 .Contains(u));
//	//commonUsers.Dump();
//
//	Console.WriteLine(commonUsers.ToString());
//	Console.WriteLine("Finally");
	
	var distinctbook = Books.Distinct(new BookComparer());
	foreach (var b in distinctbook)

		Console.WriteLine(b.Publisher);

	Console.WriteLine("Finally");





}
public class nBook
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }

}


public class Book
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }
	


}

class BookComparer : IEqualityComparer<Book>
{

	public bool Equals(Book x, Book y)
	{
	if (Object.ReferenceEquals(x, y)) return true;

		if (Object.ReferenceEquals(x, null) ||
			Object.ReferenceEquals(y, null))
			return false;

		return x.Publisher == y.Publisher && x.Publisher == y.Publisher;

	}


	public int GetHashCode(Book book)
	{
		if (Object.ReferenceEquals(book, null)) return 0;

		int hashTextual = book.Publisher == null

			? 0 : book.Publisher.GetHashCode();

		int hashDigital = book.Publisher.GetHashCode();

		return hashTextual ^ hashDigital;

	}

}
