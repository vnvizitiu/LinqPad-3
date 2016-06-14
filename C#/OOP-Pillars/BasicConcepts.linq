<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here


public sealed class Person //--On the other end of the spectrum, we can explicitly state that a class or method may not be inherited or overridden. We can do this using the sealed keyword.
{ 	
public string FirstName { get; set; } 
	public string LastName { get; set; } 
	
	public string GetFullName() 
	{ 
	return FirstName + " " + LastName;
	} 
}
public abstract class AbstractPerson //An abstract class can’t be instantiated and must be inherited (with all abstract members overridden).
{ 
public string FirstName { get; set; } 
public string LastName { get; set; } 
public abstract string GetFullName(); 
}

public class Employee : AbstractPerson
{
	public decimal Salary { get; set; }
	public override string GetFullName()
	{
		return LastName + ", " + FirstName;
	}
}
 
 /// Composition
 public class Engine
 { // ...
 
 }
 public class Car 
 { 
 	private Engine engine = new Engine(); // ... 
 }
 