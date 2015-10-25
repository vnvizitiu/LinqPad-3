<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/1175645/find-an-item-in-list-by-linq
{
	// List of cities we need to join.
	List<string> cities = new List<string>();
	cities.Add("New York");
	cities.Add("Mumbai");
	cities.Add("Berlin");
	cities.Add("Istanbul");
	cities.Add("Istanbul, Berlin");


	string search = "Berlin";
	// Throws if not found
	var item = cities.First(itemx => itemx == search);///>>>>>>>throws error if not found
	Console.WriteLine(item);


	var itemb = (from itemy in cities
				where item == search
				select item).FirstOrDefault();
	
	Console.WriteLine(itemb);
	int count = cities.Count(i => i == search);
	Console.WriteLine(count);

	int c = (from i in cities
				 where i == search
				 select i ).Count();
				 Console.WriteLine(c);

	var items = cities.Where(e => e == search);
	Console.WriteLine(items);


}

// Define other methods and classes here
