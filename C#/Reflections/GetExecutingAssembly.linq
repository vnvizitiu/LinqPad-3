<Query Kind="Program" />

public class Foo
{
	static void Main(string[] args)
	{//http://stackoverflow.com/questions/2652460/how-to-get-the-name-of-the-current-method-from-code
		//more for full application-gets clickonce folder location and exe.
		string codeBase = Assembly.GetExecutingAssembly().CodeBase;
		Console.WriteLine(codeBase); 
		 string appConfigPath = codeBase + ".config";
		 Console.WriteLine(appConfigPath);
		 

 
	}
}

// Define other methods and classes here