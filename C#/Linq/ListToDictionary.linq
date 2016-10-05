<Query Kind="Program" />

void Main()
{
	ToDictionaryEx1();
}

class Package
{
	public string Company { get; set; }
	public double Weight { get; set; }
	public long TrackingNumber { get; set; }
}

public static void ToDictionaryEx1()
{
	List<Package> packages =
		new List<Package>
			{ new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
			  new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
			  new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
			  new Package { Company = "Adventure Works", Weight = 33.8, TrackingNumber = 4665518773L } };

	// Create a Dictionary of Package objects, 
	// using TrackingNumber as the key.
	Dictionary<long, Package> dictionary =
		packages.ToDictionary(p => p.TrackingNumber);

	foreach (KeyValuePair<long, Package> kvp in dictionary)
	{
		Console.WriteLine(
			"Key {0}: {1}, {2} pounds",
			kvp.Key,
			kvp.Value.Company,
			kvp.Value.Weight);
	}
}

/*
 This code produces the following output:

 Key 89453312: Coho Vineyard, 25.2 pounds
 Key 89112755: Lucerne Publishing, 18.7 pounds
 Key 299456122: Wingtip Toys, 6 pounds
 Key 4665518773: Adventure Works, 33.8 pounds
*/

