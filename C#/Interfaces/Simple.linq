<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2011/10/20/437-access-interface-members-through-an-interface-variable/
//http://csharp.2000things.com/2011/10/18/435-implementing-an-interface/
{
	Dog kirby = new Dog("Kirby", 12);
	Seal sparky = new Seal("Sparky");
	DrillSergeant sarge = new DrillSergeant("Sgt. Hartman", "Tough as nails");

	List<IBark> critters = new List<IBark>() { kirby, sparky, sarge };

	// Tell everyone to bark
	foreach (IBark barkingCritter in critters)
	{
		barkingCritter.Bark();
	}

}

public class Dog : IBark
{
	public Dog( string name, int age) { }
	public void Bark() {Console.WriteLine("woof");}
}
public class  Seal : IBark
{
     public Seal(string name) { }
	 public void Bark() { Console.WriteLine("meowf"); }
}
class DrillSergeant : IBark
{
    public DrillSergeant(string s, string f) { }
	public void Bark() {Console.WriteLine("fuck you, give me five"); }
}

// Define other methods and classes here

 
 

public interface IBark
{
	// Methods
 	void Bark();
	
 

	


}
