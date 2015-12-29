<Query Kind="Program" />

void Main()
{
//http://csharp.2000things.com/2011/05/13/324-a-generic-class-can-have-more-than-one-type-parameter/
	ThingContainer<string, int> cont1 = new ThingContainer<string, int>();
	cont1.SetThings("Hemingway", 1899);
	Console.WriteLine(cont1.DumpThings());      //  Hemingway, 1899

	ThingContainer<Dog, DateTime> cont2 = new ThingContainer<Dog, DateTime>();
	cont2.SetThings(new Dog("Kirby", 14), new DateTime(1998, 5, 1));
	Console.WriteLine(cont2.DumpThings());      // Kirby (14 yrs), 5/1/1998 12:00:00 AM
}
public class ThingContainer<TThing1, TThing2>
{
	private TThing1 thing1;
	private TThing2 thing2;

	public void SetThings(TThing1 first, TThing2 second)
	{
		thing1 = first;
		thing2 = second;
	}

	public string DumpThings()
	{
		return string.Format("{0}, {1}", thing1.ToString(), thing2.ToString());
	}
}

class Dog
{
	public string PetName { get; set; }
	public int Age { get; set; }
	public Dog(string petname, int age)
	{

	}


}


// Define other methods and classes here
