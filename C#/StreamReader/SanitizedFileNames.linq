<Query Kind="Program" />

void Main()
{	
	string dir=@"C:\MyServices\Logs\BIDA_API\";
	string sanitizedfilename=dir+Foo.SanitizeFileName("file?<name|.txt");
	Console.WriteLine(sanitizedfilename);
}

public static class Foo
{

 private static readonly Regex InvalidFileRegex = new Regex($"[{Regex.Escape(@"<>:""/\|?*")}]");

	public static string SanitizeFileName(string fileName)
	{
		return InvalidFileRegex.Replace(fileName, string.Empty);
	}
}
// Define other methods and classes here
