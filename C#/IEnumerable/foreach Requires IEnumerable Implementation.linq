<Query Kind="Program" />

void Main() ///http://csharp.2000things.com/2014/06/13/1117-foreach-requires-ienumerable-implementation/
{
	DogPack pack = new DogPack();
	pack.Add(new Dog("Lassie", 8));
	pack.Add(new Dog("Shep", 12));
	pack.Add(new Dog("Kirby", 10));
	pack.Add(new Dog("Jack", 15));
	pack.Cull();

	// Who's left?
	foreach (Dog d in pack)
		Console.WriteLine(d);

}
public class Dog
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Dog(string name, int age)
	{
		Name=name;
		Age=age;
	}
}
public class DogPack : IEnumerable<Dog>
{
	private List<Dog> thePack;
	
	public DogPack()
	{
		thePack = new List<Dog>();
	}

	public void Add(Dog d)
	{
		thePack.Add(d);
	}

	// Remove arbitrary dog
	public void Cull()
	{
		if (thePack.Count == 0)
			return;

		if (thePack.Count == 1)
			thePack.RemoveAt(0);
		else
		{
			Random rnd1 = new Random();
			int indRemove = rnd1.Next(thePack.Count);
			thePack.RemoveAt(indRemove);
		}
	}

	// IEnumerable<T> implementation

	public IEnumerator<Dog> GetEnumerator()
	{
		return thePack.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
 
// Define other methods and classes here
