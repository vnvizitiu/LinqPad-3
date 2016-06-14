<Query Kind="Program" />

class Program //Polymorphism
{ 
static void Main(string[] args) 
{ Person p = new Employee();
	p.FirstName = "Sander"; 
	p.LastName = "Rossel"; 
	PrintFullName(p); // Press any key to quit. 
	 
}
public static void PrintFullName(Person p)
	{ Console.WriteLine(p.GetFullName()); }

} 


public class Person
{
public string FirstName { get; set; } 
public string LastName { get; set; } 
public virtual string GetFullName() 
{ return FirstName + " " + LastName; } 

}
public class Employee : Person
{ public decimal Salary { get; set; } 
public sealed override string GetFullName()
{ return LastName + ", " + FirstName; } 
}