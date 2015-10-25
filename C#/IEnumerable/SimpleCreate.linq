<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

class Program
{
    static void Main()
	{


		// List of cities we need to join.
		List<string> cities = new List<string>();
		cities.Add("New York");
		cities.Add("Mumbai");
		cities.Add("Berlinx");
		cities.Add("Istanbul");
		cities.Add("Istanbul, Berlin");
		
		IEnumerable<string> result = from value in cities
								  select value;

		// Loop.
		foreach (string value in result)
		{
			Console.WriteLine(value);
		}

	 
	}
}
