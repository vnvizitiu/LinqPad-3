<Query Kind="Program" />

 //https://msdn.microsoft.com/en-us/library/bb335435.aspx
// Custom class.
class Clump<T> : List<T>
{
	// Custom implementation of Where().
	public IEnumerable<T> Where(Func<T, bool> predicate)
	{
		Console.WriteLine("In Clump's implementation of Where().");
		return Enumerable.Where(this, predicate);
	}
}

static  void  Main()
{
	// Create a new Clump<T> object.
	Clump<string> fruitClump =
		new Clump<string> { "apple", "passionfruit", "banana",
			"mango", "orange", "blueberry", "grape", "strawberry" };

	// First call to Where():
	// Call Clump's Where() method with a predicate.
	IEnumerable<string> query1 =
		fruitClump.Where(fruit => fruit.Contains("o"));

	Console.WriteLine("query1 has been created.\n");

	// Second call to Where():
	// First call AsEnumerable() to hide Clump's Where() method and thereby
	// force System.Linq.Enumerable's Where() method to be called.
	IEnumerable<string> query2 =
		fruitClump.AsEnumerable().Where(fruit => fruit.Contains("o"));

	// Display the output.
	Console.WriteLine("query2 has been created.");
}

// This code produces the following output:
//
// In Clump's implementation of Where().
// query1 has been created.
//
// query2 has been created.

// Define other methods and classes here
