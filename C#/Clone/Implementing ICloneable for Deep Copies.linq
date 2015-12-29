<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2010/11/07/143-an-example-of-implementing-icloneable-for-deep-copies/
{	
Person emilyBronte=new Person();
emilyBronte.FirstName="Emily";
emilyBronte.LastName="Bronte";
emilyBronte.PersonAddress=new Address();
emilyBronte.PersonAddress.HouseNumber=8;
emilyBronte.PersonAddress.StreetName="Palomar Parade";


Person herClone = (Person)emilyBronte.Clone();
emilyBronte.Dump();
herClone.Dump();



}
public class Person : ICloneable
{
	public string LastName { get; set; }
	public string FirstName { get; set; }
	public Address PersonAddress { get; set; }

	public object Clone()
	{
		Person newPerson = (Person)this.MemberwiseClone();
		newPerson.PersonAddress = (Address)this.PersonAddress.Clone();

		return newPerson;
	}
}
public class Address : ICloneable
{
	public int HouseNumber { get; set; }
	public string StreetName { get; set; }

	public object Clone()
	{
		return this.MemberwiseClone();
	}
}


// Define other methods and classes here
