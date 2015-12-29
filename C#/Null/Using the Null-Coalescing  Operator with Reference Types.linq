<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2011/01/17/214-using-the-null-coalescing-operator-with-reference-types/
{
	Person favArtist = new Person("Connee", "Boswell");
	Person oldBlueEyes = new Person("Frank", "Sinatra");

	Person buyCDOf = favArtist ?? oldBlueEyes;  // Frank is our fallback
	buyCDOf.Dump();

}
class Person
{
	public string First { get; set; }
	public string Second { get; set; }
	public Person(string first, string second) 
	{
	First=first;
	Second=second;
	}
}
// Define other methods and classes here
