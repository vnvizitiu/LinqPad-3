<Query Kind="Program" />

//Chapter 1: C# in Depth 3rd Edition
class Car
{
	// Automatic properties!
	public string PetName { get; set; }
	public int Speed { get; set; }
	public string Color { get; set; }
	
	public void DisplayStats()
	{
		Console.WriteLine("Car Name: {0}", PetName);
		Console.WriteLine("Speed: {0}", Speed);
		Console.WriteLine("Color: {0}", Color);
	}
	

}
static void Main()
{
	 Car r=new Car{PetName="Ray",Speed=10, Color="Red"};
	Car k = new Car { PetName = "Krystal", Speed = 8, Color = "Pink" };
	Car c = new Car();
	c.PetName = "Frank";
	c.Speed = 55;
	c.Color = "Red";

	 object[] values = {r,k,c };
	//Car[] values = {r,k,c };
	
	IteratorBlockIterationSample collection = new IteratorBlockIterationSample(values, 1);
	foreach (object x in collection)
	{
		Console.WriteLine(x);
	}
	foreach (Car x in collection)
	{
		Console.WriteLine(x.PetName);
	}
}

class IteratorBlockIterationSample : IEnumerable
{
	object[] values;
	int startingPoint;

	public IteratorBlockIterationSample(object[] values, int startingPoint)
	{
		this.values = values;
		this.startingPoint = startingPoint;
	}

	public IEnumerator GetEnumerator()
	{
		for (int index = 0; index < values.Length; index++)
		{
			yield return values[(index + startingPoint) % values.Length];
		}
	}

 
}
