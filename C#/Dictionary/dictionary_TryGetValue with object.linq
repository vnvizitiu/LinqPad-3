<Query Kind="Program" />

void Main()
{

	var areas = new Dictionary<string, AreaInfo>
	{{"Key1", new AreaInfo() {Name = "Name1", Total = 0, All = 0}},
  	{"Key2", new AreaInfo() {Name = "Name2", Total = 0, All = 0}},};

	var arrayA = new[] { "Key1", "element2","Key10","Key1"};

	for (int i = 0; i < arrayA.Count(); i++)
	{
		AreaInfo myreturn;
	//	areas.TryGetValue(arrayA.ElementAt(i).ToString(), out myreturn);
		//http://stackoverflow.com/questions/9382681/what-is-more-efficient-dictionary-trygetvalue-or-containskeyitem
		if (areas.TryGetValue(arrayA.ElementAt(i).ToString(), out myreturn))
		{
			Console.WriteLine(myreturn.Name);
		}
		else
		{
			Console.WriteLine("not found on "+ i);
		}
	}

}

class AreaInfo
{
	public string Name { get; set; }
	public int Total { get; set; }
	public int All { get; set; }

	public override bool Equals(object obj)
	{
		var ai = obj as AreaInfo;
		if (object.ReferenceEquals(ai, null))
			return false;
		return Name == ai.Name && Total == ai.Total && All == ai.All;
	}

	public override int GetHashCode()
	{
		var hc = 0;
		if (Name != null)
			hc = Name.GetHashCode();
		hc = unchecked((hc * 7) ^ Total);
		hc = unchecked((hc * 21) ^ All);
		return hc;
	}

	public override string ToString()
	{
		return string.Format("{{ Name = {0}, Total = {1}, All = {2} }}", Name, Total, All);
	}
}
