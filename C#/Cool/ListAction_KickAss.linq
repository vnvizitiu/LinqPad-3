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

	//recommended by Resharper but doesn't work..
	description.ToList().ForEach((Action<Component>)(component => new StringBuilder().Append(component.Name + ","))); 
	 
	
	
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