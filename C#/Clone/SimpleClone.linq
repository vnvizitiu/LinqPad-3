<Query Kind="Program" />

public class Person : ICloneable //http://csharp.2000things.com/2010/11/05/141-implementing-icloneable-for-a-custom-type/
//The simplest way to create a copy of the object is to call the Object.MemberwiseClone method.
{
	public string LastName { get; set; }
	public string FirstName { get; set; }
	public Person(string lastname, string firstname)
	{
		LastName = lastname;
		FirstName = firstname;
	}
	public Person() {}

	public object Clone()
	{
		return this.MemberwiseClone();
	}
}

void Main()
{
	Person p=new Person();
	p.FirstName="Sam";
	p.LastName="Tran";

	Person myClone = (Person)p.Clone();


	Console.WriteLine(myClone);

}

// Define other methods and classes here

// Define other methods and classes here
