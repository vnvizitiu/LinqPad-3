<Query Kind="Program" />

class Program
{ //http://stackoverflow.com/questions/1175645/find-an-item-in-list-by-linq
    static void Main()
	{
		// List of cities we need to join.
		List<string> cities = new List<string>();
		cities.Add("New York");
		cities.Add("Mumbai");
		cities.Add("Berlinx");
		cities.Add("Istanbul");
		cities.Add("Istanbul, Berlin");

		// Join strings into one CSV line.
		string line = string.Join(",", cities.ToArray());
		Console.WriteLine(line);

 			string search = "Berlin";
//		//List<string> cities = new List<string>();
//		string result = cities.Single(s => s == search);<<<<<<<<<<<<<<<<<<<<throws error if not found
//		Console.WriteLine(result);
		////
		IEnumerable<string> results = cities.Where(s => s == search);
		Console.WriteLine(results);
		///
	//	string res = cities.First(s => s == search); <<<<<<<<<<<<throws error if not found
	//	Console.WriteLine(res);
		
		var item = cities.FirstOrDefault(itemx => itemx == search);
		Console.WriteLine(item);
		
	}
}
