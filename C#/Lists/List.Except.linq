<Query Kind="Program" />

void Main()
{
	var authorsList = new List<Author>()
{
	new Author{ Firstname = "Bob", Lastname = "Smith" },
	new Author{ Firstname = "Fred", Lastname = "Jones" },
	new Author{ Firstname = "Brian", Lastname = "Brains" },
	new Author{ Firstname = "Billy", Lastname = "TheKid" }
};

	var authors = authorsList.Where(a => a.Firstname == "Bob");
	authorsList = authorsList.Except(authors).ToList();
	authorsList = authorsList.Except(authorsList.Where(a => a.Firstname == "Billy")).ToList();
	authorsList.Dump();
}

class Author
{
	public string Firstname { get; set; }
	public string Lastname { get; set; }
}
// Define other methods and classes here
