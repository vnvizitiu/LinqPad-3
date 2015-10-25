<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/11285045/intersect-two-lists-with-different-objects
{
	List<Book> Books = new List<Book>() {
  new Book { Title="LINQ in Action", Cost=10, Publisher="Sam" },
  new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
	new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymondx" },
  new Book { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};

	List<nBook> nBooks = new List<nBook>() {
  new nBook { Title="LINQ in Action", Cost=10, Publisher="Samxx" },
		//  new nBook { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
		new nBook { Title="LINQ in Action", Cost=10, Publisher="Sam" },
  new nBook { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};


	List<xBook> xBooks = new List<xBook>() {
  new xBook {Publisher="Samxx"},
		  new xBook {  Publisher="Raymond" },
		new xBook {  Publisher="Sam" }};


	var commonUsers = Books.Select(l1 => l1.Publisher)
		  .Where(u => xBooks.Select(l2 => l2.Publisher)
							.Contains(u));


	foreach (var element in commonUsers)
	{
		Console.WriteLine(element.ToString());
	}
















}
public class nBook
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }

}
public class xBook
{

	public string Publisher { get; set; }

}


public class Book
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }


}