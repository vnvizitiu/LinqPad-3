<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb548541.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
{
	AllEx2();
}
class Pet
{
	public string Name { get; set; }
	public int Age { get; set; }
}
class Person
{
	public string LastName { get; set; }
	public Pet[] Pets { get; set; }
}

public static void AllEx2()
{
	List<Person> people = new List<Person>
		{ new Person { LastName = "Haas",
					   Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
										  new Pet { Name="Boots", Age=14 },
										  new Pet { Name="Whiskers", Age=6 }}},
		  new Person { LastName = "Fakhouri",
					   Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
		  new Person { LastName = "Antebi",
					   Pets = new Pet[] { new Pet { Name = "Belle", Age = 8} }},
		  new Person { LastName = "Philips",
					   Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
										  new Pet { Name = "Rover", Age = 13}} }
		};

	// Determine which people have pets that are all older than 5.
	IEnumerable<string> names = from person in people
								where person.Pets.All(pet => pet.Age > 5)
								select person.LastName;

	foreach (string name in names)
	{
		Console.WriteLine(name);
	}

	/* This code produces the following output:
     * 
     * Haas
     * Antebi
     */
}

// Define other methods and classes here
