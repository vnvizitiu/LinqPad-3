<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

//http://www.dotnetperls.com/action
class Program
{
	static void Main()
	{
		Dictionary<string, Action> dict = new Dictionary<string, Action>();
		dict["cat"] = new Action(Cat);
		dict["dog"] = new Action(Dog);

		dict["cat"].Invoke();
		dict["dog"].Invoke();
	}

	static void Cat()
	{
		Console.WriteLine("CAT");
	}

	static void Dog()
	{
		Console.WriteLine("DOG");
	}
}