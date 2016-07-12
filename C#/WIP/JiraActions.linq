<Query Kind="Program" />

void Main()
{
	var description = new List<Component>();


	description.Add(new Component() { ID = "a", Name = "AA", Description = "AAA" });
	description.Add(new Component() { ID = "b", Name = "BB", Description = "BBB" });
	description.Add(new Component() { ID = "c", Name = "CC", Description = "CCC" });

	var cName = new StringBuilder();
	Action<Component> concatName = component => cName.Append(component.Name + ",");
	description.ToList().ForEach(concatName);
	 
	Debug.WriteLine(cName.ToString());


	// Action: 3 parameters
	Action<string, int, double> goofyDel =
		(s, i, d) => Console.WriteLine(string.Format(s, i, d));
	goofyDel("Int is {0}, Double is {1}", 5, 12.2);

	
//	string a; string b;
//	var ccName = new StringBuilder();
//	Action<string, List<Component>> cconcatName =
//	(s, t) => ccName.Append(t + ",");
//
//	a = cconcatName("ss", description);
//	
//	a=ccName.ToString();
//	Console.WriteLine(a);
//	
	
		// Function: 2 parameters, returns string
	
	
		Func<List<Component>, string, string> test =
		(List<Component> L, string s) =>
		{
		var cNamex = new StringBuilder();
			Action<Component> concatNamex = componentx => cNamex.Append(componentx.Name + ",");
		description.ToList().ForEach(concatNamex);
		Console.WriteLine(cNamex);
		return cNamex.ToString();
	};
	string testanswer = test(description,"hello");
	Console.WriteLine(testanswer);
	testanswer.Dump();

	var epicdescription = new List<Epics>();
	epicdescription.Add(new Epics() { ID = "a", Name = "AA", Description = "AAA" });
	epicdescription.Add(new Epics() { ID = "b", Name = "BB", Description = "BBB" });
	epicdescription.Add(new Epics() { ID = "c", Name = "CC", Description = "CCC" });
}



// Define other methods and classes 
public class Component
{
	public Component()
	{
		ID = "NA";
		Name = "NA";
		Description = "NA";
	}


	public string ID { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }
}
public class Epics
{
	public Epics()
	{
		ID = "NA";
		Name = "NA";
		Description = "NA";
	}


	public string ID { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }
}