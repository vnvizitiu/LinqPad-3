<Query Kind="Program" />

static IEnumerable<Dog> DogsWithKids(IEnumerable<Dog> dogList)
{
	foreach (Dog d in dogList)
	{
		yield return d;
		yield return new Dog(d.Name + " Jr.",
							 Math.Max(d.Age - 3, 1));
	}
}
//http://csharp.2000things.com/2014/06/16/1118-foreach-works-with-iterator-returned-by-yield/
static void Main(string[] args)
{
	List<Dog> myDogs = new List<Dog>
		{
			new Dog {Name = "Kirby", Age = 15},
			new Dog {Name = "Ruby", Age = 2}
		};

	// Iterate through dogs w/offsprings
	foreach (Dog d in DogsWithKids(myDogs))
		Console.WriteLine(d);

 
}
public class Dog
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Dog(string name, int age)
	{
		Name = name;
		Age = age;
	}
	public Dog() {}
}