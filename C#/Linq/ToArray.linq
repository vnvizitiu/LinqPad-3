<Query Kind="Program" />

void Main()
{
	ToArrayEx1();
}
class Package
{
	public string Company { get; set; }
	public double Weight { get; set; }
}

public static void ToArrayEx1()
{
	List<Package> packages =
		new List<Package>
			{ new Package { Company = "Coho Vineyard", Weight = 25.2 },
			  new Package { Company = "Lucerne Publishing", Weight = 18.7 },
			  new Package { Company = "Wingtip Toys", Weight = 6.0 },
			  new Package { Company = "Adventure Works", Weight = 33.8 } };

	string[] companies = packages.Select(pkg => pkg.Company).ToArray();

	foreach (string company in companies)
	{
		Console.WriteLine(company);
	}
}

/*
 This code produces the following output:

 Coho Vineyard
 Lucerne Publishing
 Wingtip Toys
 Adventure Works
*/
// Define other methods and classes here
