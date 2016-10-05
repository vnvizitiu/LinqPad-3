<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

class Program
{
    static void Main()
	{
		List<Tuple<int, string>> list = new List<Tuple<int, string>>();
		list.Add(new Tuple<int, string>(1, "cat"));
		list.Add(new Tuple<int, string>(100, "apple"));
		list.Add(new Tuple<int, string>(2, "zebra"));
		
		list.Dump();

		// Use Sort method with Comparison delegate.
		// ... Has two parameters; return comparison of Item2 on each.
		list.Sort((a, b) => a.Item2.CompareTo(b.Item2));

		foreach (var element in list)
		{
			Console.WriteLine(element);
		}
	}
}