<Query Kind="Program" />

void Main()
{
	SelectManyEx1();
}
class PetOwner
{
	public string Name { get; set; }
	public List<String> Pets { get; set; }
}

public static void SelectManyEx1()
{
	PetOwner[] petOwners =
		{ new PetOwner { Name="Higa, Sidney",
			  Pets = new List<string>{ "Scruffy", "Sam" } },
		  new PetOwner { Name="Ashkenazi, Ronen",
			  Pets = new List<string>{ "Walker", "Sugar" } },
		  new PetOwner { Name="Price, Vernette",
			  Pets = new List<string>{ "Scratches", "Diesel" } } };

	// Query using SelectMany().
	IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);

	Console.WriteLine("Using SelectMany():");

	// Only one foreach loop is required to iterate 
	// through the results since it is a
	// one-dimensional collection.
	foreach (string pet in query1)
	{
		Console.WriteLine(pet);
	}

	// This code shows how to use Select() 
	// instead of SelectMany().
	IEnumerable<List<String>> query2 =
		petOwners.Select(petOwner => petOwner.Pets);

	Console.WriteLine("\nUsing Select():");

	// Notice that two foreach loops are required to 
	// iterate through the results
	// because the query returns a collection of arrays.
	foreach (List<String> petList in query2)
	{
		foreach (string pet in petList)
		{
			Console.WriteLine(pet);
		}
		Console.WriteLine();
	}
}

// Define other methods and classes here
