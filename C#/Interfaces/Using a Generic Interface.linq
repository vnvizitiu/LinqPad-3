<Query Kind="Program" />

void Main() ///http://csharp.2000things.com/2012/03/09/536-implement-a-generic-interface/
{
	Farmer burton = new Farmer("Burton");
	burton.Remember(new Joke("A man walks into a bar.", "Ouch"));
	//burton.TellMeMostRecent().Output();
	burton.TellMeMostRecent().Dump();

	burton.Remember(new Joke("What's red and invisible?", "No tomatoes"));
	//burton.TellMeMostRecent().Output();
	burton.TellMeMostRecent().Dump();

}
public interface IRememberMostRecent<T>
{
	void Remember(T thingToRemember);
	T TellMeMostRecent();
	List<T> PastThings { get; }
}

public class Farmer : IRememberMostRecent<Joke>
{
	public string Name { get; protected set; }

	public Farmer(string name)
	{
		Name = name;
		lastJoke = null;
		allJokes = new List<Joke>();
	}

	// IRememberMostRecent implementation
	private Joke lastJoke;
	private List<Joke> allJokes;

	public void Remember(Joke jokeToRemember)
	{
		if (lastJoke != null)
			allJokes.Add(lastJoke);

		lastJoke = jokeToRemember;
	}

	public Joke TellMeMostRecent()
	{
		return lastJoke;
	}

	public List<Joke> PastThings
	{
		get { return allJokes; }
	}
}
public class Joke
{	
	public string First { get; set; }
	public string Second { get; set; }
	public Joke(string first, string second) {First=first; Second=second;}
	
}

