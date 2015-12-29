<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2014/11/04/1218-c-6-0-using-lambdas-for-getter-only-auto-properties/
//http://csharp.2000things.com/2014/11/03/1217-using-lambda-expressions-for-function-members/
{ // C# 6.0 – Using Lambdas for Getter-Only Auto-Properties
	Foo f = new Foo { FirstName = "Sam", Age = 21};
	Console.WriteLine(f.BackwardsName);

	Dog d = new Dog ("Lucky", 5);
	Console.WriteLine(d.Age);
	
	d.AgeIncrement();
	Console.WriteLine(d.Age);
	Console.WriteLine(d.AgeInDogYears());
	
}

class Foo
{	
	public string FirstName { get; set; }
	public string LastName { get; protected set; }
	public int Age { get; set; }

	public string BackwardsName => new string(FirstName.Reverse().ToArray());
}
// Define other methods and classes here
public class Dog
{
	public Dog(string name, int age)
	{
		Name = name;
		Age = age;
	}

	public string Name { get; protected set; }
	public int Age { get; set; }

	public void AgeIncrement() => Age++;
	public int AgeInDogYears() => Age * 7;
}
