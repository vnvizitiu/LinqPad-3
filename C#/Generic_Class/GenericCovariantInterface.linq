<Query Kind="Program" />

//http://csharp.2000things.com/category/classes/
static void Main(string[] args)
{
	Pile<Terrier> lilDogs = new Pile<Terrier>();
	lilDogs.Add(new Terrier("Jack"));
	lilDogs.Add(new Terrier("Eddie"));
	
	lilDogs.pile.Dump();
	

	// This works !
    ShowFirstDog(lilDogs);
	
	lilDogs.GetFirst();
}

static void ShowFirstDog(IGetFirst<Dog> dogs)
{
	Console.WriteLine(dogs.GetFirst().Name);
}

class Terrier
{
	public string Name { get; set; }
	public Terrier(string name)
	{
		Name = name;
	}
}
class Dog
{
	public string Name { get; set; }
	public Dog(string name)
	{
		Name = name;
	}
}
public interface IGetFirst<out T>
{
	T GetFirst();
}

public class Pile<T> : IGetFirst<T> where T : class
{
	public List<T> pile = new List<T>();

	public void Add(T item)
	{
		if (!pile.Contains(item))
			pile.Add(item);
	}

	public T GetFirst()
	{
		Console.WriteLine(pile[0].ToString());
		return (pile.Count > 0) ? pile[0] : null;

	}
	 
}
// Define other methods and classes here
