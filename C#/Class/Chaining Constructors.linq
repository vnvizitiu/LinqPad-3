<Query Kind="Program" />



public class Dog //http://csharp.2000things.com/2011/04/03/290-chaining-constructors/
{
	public string Name { get; set; }
	public int Age { get; set; }

	public Dog(string name, int age)
	{
		Name = name;
		Age = age;
	}

	public Dog(string name)
		: this(name, 1)
	{
	}
}

void Main()
{
	Dog d1= new Dog("Kirby");
	Dog d2= new Dog ("Jack",15);
}

// Define other methods and classes here


