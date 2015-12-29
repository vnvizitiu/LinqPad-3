<Query Kind="Program" />

void Main() //http://csharp.2000things.com/tag/generic-methods/
{
	Dog fido = new Dog("Fido");

	fido.Bury(new Bone());
	fido.Bury(new Lawyer());
	//fido.Bury<Cow>(new Cow("Bessie"));
	fido.Bury<Lawyer>(new Lawyer(), "One less lawyer");
	fido.Bury<Cow, Cat>(new Cow("Bessie"), new Cat("Puffy"));

}
 
class Bone
{
	public string Name { get; set; }
}
class Lawyer
{
	public string Name { get; set; }
}
class Cow
{
	public Cow(string name)
	{
		Name = name;
	}
	public string Name { get; set; }
}

class Cat
{
	public string Name { get; set; }
	public Cat (string name)
	{
		Name = name;
	}
}
public class Dog
{
	public string Name { get; set; }

	public Dog(string name)
	{
		Name = name;
	}

//	public void Bury(Bone b)
//	{
//		Console.WriteLine("{0} is burying: {1}", Name, b);
//	}
//
//	public void Bury(Lawyer l)
//	{
//		Console.WriteLine("{0} is burying: {1}", Name, l);
//	}

	public void Bury<T>(T thing)
	{
		Console.WriteLine("{0} is burying: {1}", Name, thing);
	}

	public void Bury<T>(T thing, string msg)
	{
		Console.WriteLine("{0} : {1}", msg, thing);
	}

	public void Bury<T1, T2>(T1 thing1, T2 thing2)
	{
		Console.WriteLine("{0} is burying: {1}", Name, thing1);
		Console.WriteLine("{0} is burying: {1}", Name, thing2);
	}
}

// Define other methods and classes here
