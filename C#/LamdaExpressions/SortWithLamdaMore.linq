<Query Kind="Program" />

public class Part 
{
	public string PartName { get; set; }
	public int PartId { get; set; }

	public override string ToString()
	{
		return "ID: " + PartId + "   Name: " + PartName;
	}

 
}
public class Example
{
	public static void Main()
	{
		// Create a list of parts.
		List<Part> parts = new List<Part>();

		// Add parts to the list.
		parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
		parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
		parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
		parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
		parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
		parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;



		parts.Sort(
			(first, second) => first.PartName.CompareTo(second.PartName)
		);
		foreach (Part product in parts)
		{
			Console.WriteLine(product);
		}

	}
}