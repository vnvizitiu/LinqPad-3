<Query Kind="Program" />

void Main()// asQueryable should not be used with in memory http://stackoverflow.com/questions/755826/convert-iqueryable-type-object-to-listt-type
{
	List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

	List<Book> Books = new List<Book>() {
  new Book { Title="LINQ in Action", Cost=10, Publisher="Sam" },
  new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
  new Book { Title="LINQ for Fun", Cost =12, Publisher="Raymondx" },
  new Book { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};

	// Convert the List to an IQueryable<int>.
	IQueryable<int> iqueryable = grades.AsQueryable();
	
	IQueryable<Book>ibook=Books.AsQueryable();

	// Get the Expression property of the IQueryable object.
	System.Linq.Expressions.Expression expressionTree =
		iqueryable.Expression;

	Console.WriteLine("The NodeType of the expression tree is: "
		+ expressionTree.NodeType.ToString());
	Console.WriteLine("The Type of the expression tree is: "
		+ expressionTree.Type.Name);

	iqueryable.Dump();
	ibook.Dump();

	/*
		This code produces the following output:

		The NodeType of the expression tree is: Constant
		The Type of the expression tree is: EnumerableQuery`1
	*/

}

// Define other methods and classes here

public class Book  
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }

	 
}

