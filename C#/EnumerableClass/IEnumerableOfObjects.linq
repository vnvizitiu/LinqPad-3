<Query Kind="Program" />

static void Main() //http://csharp.2000things.com/2012/04/09/557-using-an-iterator-to-return-the-elements-of-an-enumerable-type/
{
	foreach (Dog d in ListOfDogs())
		Console.WriteLine(d.Name);
}

private static IEnumerable<Dog> ListOfDogs()
{
	yield return new Dog("Jack", 17);
	yield return new Dog("Kirby", 14);
	yield return new Dog("Lassie", 72);
	yield return new Dog("Rin Tin Tin", 94);
}
class Dog
{

  public string Name { get; set; }
  public int Age { get; set; }
	public Dog(string name, int age)
	{
		Name=name;
		Age=age;
	}

	
}