<Query Kind="Program" />

void Main()
{

	var areas = new Dictionary<string, AreaInfo>
	{{"Key1", new AreaInfo() {Name = "Name1", Total = 0, All = 0}},
  	{"Key2", new AreaInfo() {Name = "Name2", Total = 0, All = 0}},};

	foreach (var area in areas.Keys.ToArray())
	{
		var areaname = areas[area].Name;
		Console.WriteLine(area.ToString());
		Console.WriteLine(areaname.ToString());
		Console.WriteLine("======================================");
	}
	Console.WriteLine(areas.Keys);
	Console.WriteLine(areas.Values);
	areas.Dump();
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
