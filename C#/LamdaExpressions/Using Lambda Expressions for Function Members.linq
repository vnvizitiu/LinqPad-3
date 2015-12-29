<Query Kind="Program" />

void Main() //http://csharp.2000things.com/2014/11/03/1217-using-lambda-expressions-for-function-members/
{
	Dog d=new Dog("lucky",5);
	Console.WriteLine(d.Age);
	d.AgeIncrement();
	Console.WriteLine(d.Age);
	
}
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

// Define other methods and classes here
