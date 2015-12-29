<Query Kind="Program" />

void Main()
{
	List<string> list = MakeList<string>("Line 1", "Line 2");
	foreach (string x in list)
	{
		Console.WriteLine(x);
	}

	List<int> listn = MakeList<int>(30310, 5000);
	foreach (int x in listn)
	{
		Console.WriteLine(x);
	}
}

static List<T> MakeList<T>(T first, T second)
{
	List<T> list = new List<T>();
	list.Add(first);
	list.Add(second);
	return list;
}