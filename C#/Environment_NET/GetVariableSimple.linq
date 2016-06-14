<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/77zkk0b6(v=vs.110).aspx
public class Example
{
   public static void Main()
	{
		// Change the directory to %WINDIR%
		Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir");
		DirectoryInfo info = new DirectoryInfo(".");

		Console.WriteLine("Directory Info:   " + info.FullName);
	}
}
// The example displays output like the following:
//        Directory Info:   C:\windows