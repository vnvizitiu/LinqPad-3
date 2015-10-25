<Query Kind="Program" />

void Main()
{
 
 
	
	Car r=new Car{PetName="Ray",Speed=10, Color="Red"};
	Console.WriteLine(r.PetName+" "+ r.Color +"  "+ r.Speed);
	
	Car k= new Car{PetName="Krystal", Speed=8, Color="Pink"};
	k.DisplayStats();
	
	Console.WriteLine("***** Fun with Automatic Properties *****\n");
	Car c = new Car();
	c.PetName = "Frank";
	c.Speed = 55;
	c.Color = "Red";
	Console.WriteLine("Your car is named {0}? That's odd...",
	c.PetName);
	 
	 
	 
	 Garage g = new Garage();
// OK, prints default value of zero.
	Console.WriteLine("Number of Cars: {0}", g.NumberOfCars);
// Runtime error! Backing field is currently null!
	Console.WriteLine(g.MyAuto.PetName);
	
	
	// Put car in the garage.
Garage gg = new Garage();
gg.MyAuto = c;
Console.WriteLine("Number of Cars in garage: {0}", gg.NumberOfCars);
Console.WriteLine("Your car is named: {0}", gg.MyAuto.PetName);
	
//	 Note Visual Studio provides the prop code snippet. If you type “prop” and press the Tab key twice, the IDE will
//generate starter code for a new automatic property! You can then use the Tab key to cycle through each part of
//the definition to fill in the details. Give it a try!
}
class Car
{
// Automatic properties!
public string PetName { get; set; }
public int Speed { get; set; }
public string Color { get; set; }

public void DisplayStats()
{
Console.WriteLine("Car Name: {0}", PetName);
Console.WriteLine("Speed: {0}", Speed);
Console.WriteLine("Color: {0}", Color);
}
 
}

class WrongGarage///just using this will give error on >Console.WriteLine(g.MyAuto.PetName); in Main
{
// The hidden int backing field is set to zero!
public int NumberOfCars { get; set; }
// The hidden Car backing field is set to null!
public Car MyAuto { get; set; }
}

class Garage
{
// The hidden backing field is set to zero!
public int NumberOfCars { get; set; }
// The hidden backing field is set to null!
public Car MyAuto { get; set; }
// Must use constructors to override default
// values assigned to hidden backing fields.
public Garage()
{
MyAuto = new Car();
NumberOfCars = 1;
}
public Garage(Car car, int number)
{
MyAuto = car;
NumberOfCars = number;
}
}





// A Car type using standard property
// syntax.
class Cart
{
private string carName = "";
public string PetName
{
get { return carName; }
set { carName = value; }
}
}


