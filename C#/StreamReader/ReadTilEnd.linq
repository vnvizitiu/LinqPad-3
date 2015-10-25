<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

//using System;
//using System.IO;
//https://msdn.microsoft.com/en-us/library/system.io.streamreader.readtoend(v=vs.110).aspx
class Test
{

	public static void Main()
	{
		string path = @"C:\Users\Sam\Downloads\MyTest.txt";

		try
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}

			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine("This");
				sw.WriteLine("is some text");
				sw.WriteLine("to test");
				sw.WriteLine("Reading");
			}

			using (StreamReader sr = new StreamReader(path))
			{
				//This allows you to do one Read operation.
				Console.WriteLine(sr.ReadToEnd());
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The process failed: {0}", e.ToString());
		}
	}
}