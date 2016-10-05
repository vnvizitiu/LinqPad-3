<Query Kind="Program" />

void Main()
{
	Console.WriteLine(AssemblyDirectory);
}
public static string AssemblyDirectory
{
	get
	{
		string codeBase = Assembly.GetExecutingAssembly().CodeBase;
		UriBuilder uri = new UriBuilder(codeBase);
		string path = Uri.UnescapeDataString(uri.Path);
		return Path.GetDirectoryName(path);
	}
}
// Define other methods and classes here
//http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in