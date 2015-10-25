<Query Kind="Program" />

void Main()
{
	List<Book> Books = new List<Book>() {
	new Book { Title = "LINQ in Action", Cost = 10, Publisher = "Sam" },
	new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymond" },
  new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymondx" },
  new Book { Title = "Extreme LINQ", Cost = 1, Publisher = "Krystal" }};

List<nBook> nBooks = new List<nBook>() {
  new nBook { Title="LINQ in Action", Cost=10, Publisher="Sam" },
  new nBook { Title="LINQ for Fun", Cost =12, Publisher="Raymond" },
  new nBook { Title="Extreme LINQ", Cost=1 , Publisher="Krystal"}};
 
 Program.Shuffle(Books);
 Program.Shuffle(nBooks);


}

  static class Program // IF not static CS1109 Extension methods must be defined in a top level static class; Program is a nested class
{
	// Define other methods and classes here
	public static void Shuffle<T>(this List<T> source)
	{
		source.Dump();
		source.ToArray();

	}
}

 

public class nBook
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }

	public bool Equals(nBook other)
	{
		// Check whether the compared object is null.
		if (Object.ReferenceEquals(other, null)) return false;
		// Check whether the compared object references the same data.
		if (Object.ReferenceEquals(this, other)) return true;
		// Check whether the objects’ properties are equal.
		return Title.Equals(other.Title) &&
			   Title.Equals(other.Title);
	}

	// If Equals returns true for a pair of objects,
	// GetHashCode must return the same value for these objects.
	public override int GetHashCode()
	{

		// Get the hash code for the Textual field if it is not null.
		int hashTextual = Title == null ? 0 : Title.GetHashCode();
		// Get the hash code for the Digital field.
		int hashDigital = Title.GetHashCode();
		// Calculate the hash code for the object.
		return hashDigital ^ hashDigital;
	}
}



public class Book : IEquatable<Book>
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }

	public bool Equals(Book other)
	{
		// Check whether the compared object is null.
		if (Object.ReferenceEquals(other, null)) return false;
		// Check whether the compared object references the same data.
		if (Object.ReferenceEquals(this, other)) return true;
		// Check whether the objects’ properties are equal.
		return Title.Equals(other.Title) &&
			   Title.Equals(other.Title);
	}

	// If Equals returns true for a pair of objects,
	// GetHashCode must return the same value for these objects.
	public override int GetHashCode()
	{

		// Get the hash code for the Textual field if it is not null.
		int hashTextual = Title == null ? 0 : Title.GetHashCode();
		// Get the hash code for the Digital field.
		int hashDigital = Title.GetHashCode();
		// Calculate the hash code for the object.
		return hashDigital ^ hashDigital;
	}
}