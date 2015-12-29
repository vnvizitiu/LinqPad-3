<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>


    [Description("Listing 11.05")]
class CastAndOfType
{
	static void Main()
	{
		ArrayList list = new ArrayList { "First", "Second", "Third" };
		var strings = list.Cast<string>();
		foreach (string item in strings)
		{
			Console.WriteLine(item);
		}
	
		Console.WriteLine("................");

		list = new ArrayList { 1, "not an int", 2, 3 };
		var ints = list.OfType<int>();
		foreach (int item in ints)
		{
			Console.WriteLine(item);
		}
	}
}
