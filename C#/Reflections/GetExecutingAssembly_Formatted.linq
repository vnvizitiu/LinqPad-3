<Query Kind="Program" />

void Main()
{//http://stackoverflow.com/questions/864484/getting-the-path-of-the-current-assembly
	string s = Assembly.GetExecutingAssembly().CodeBase;
	Console.WriteLine("CodeBase: [" + s + "]");
	s = (new Uri(s)).AbsolutePath;
	Console.WriteLine("AbsolutePath: [" + s + "]");
	s = Uri.UnescapeDataString(s);
	Console.WriteLine("Unescaped: [" + s + "]");
	s = Path.GetFullPath(s);
	Console.WriteLine("FullPath: [" + s + "]");
	Console.WriteLine(s);
}

// Define other methods and classes here
