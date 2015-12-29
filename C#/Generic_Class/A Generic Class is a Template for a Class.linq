<Query Kind="Program" />

void Main()
{//http://csharp.2000things.com/2011/05/12/323-a-generic-class-is-a-template-for-a-class/
	ThingContainer<int> intContainer = new ThingContainer<int>();
	intContainer.SetThing(5);

	ThingContainer<Dog> dogContainer = new ThingContainer<Dog>();
	dogContainer.SetThing(new Dog("Kirby", 5));

}

public class ThingContainer<TParam>
{
	private TParam theThing;

	public void SetThing(TParam newValue)
	{
		theThing = newValue;
		Console.WriteLine(theThing);
	}
}


class Dog
{
	public string PetName { get; set; }
	public int Age { get; set; }
	public Dog(string petname, int age)
	{

	}


}