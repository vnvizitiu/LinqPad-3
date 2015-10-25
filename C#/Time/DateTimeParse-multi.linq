<Query Kind="Program" />

void Main()
{
	DateTime dt = DateTime.Parse("23/12/2010");
	Console.WriteLine(dt);
	string s2 = dt.ToString("dd-MM-yyyy");
	Console.WriteLine(s2);	
	DateTime dtnew = DateTime.Parse(s2);
	Console.WriteLine(dtnew);	
	DateTime tdt = DateTime.Parse("23/12/2010");
	Console.WriteLine(tdt);	
}

// Define other methods and classes here
