<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/11178864/pass-property-itself-to-function-as-parameter-in-c-sharp
{
	var description = new List<Component>();


	description.Add(new Component() { ID = "a", Name = "AA", Description = "AAA" });
	description.Add(new Component() { ID = "b", Name = "BB", Description = "BBB" });
	description.Add(new Component() { ID = "c", Name = "CC", Description = "CCC" });

	var cName = new StringBuilder();
	Action<Component> concatName = component => cName.Append(component.Name + ",");
	description.ToList().ForEach(concatName);

	Func<List<int>, Func<int, int>, int> orderByFunc =
(i, c) => { return 10; };
	List<int> ints = new List<int>(new int[] { 2, 3, 7 });
	var mynumber = orderByFunc(ints, x => x);
	Console.WriteLine(mynumber);





	Func<List<Component>, Func<Component, IComparable>, string, string> test =
		(List<Component> L, Func<Component, IComparable> GetPropX, string s) =>
		{
			var cNamex = new StringBuilder();
			Action<Component> concatNamex = componentx => cNamex.Append(GetPropX(componentx)+",");
		 L.ToList().ForEach(concatNamex);
 
		return cNamex.ToString();
	};
	string testDescription = test(description,x=>x.Description,"yippee");
	Console.WriteLine(testDescription );

	string testName = test(description, x => x.Name, "yippee");
	Console.WriteLine(testName);

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