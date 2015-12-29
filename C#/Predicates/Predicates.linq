<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.IO</Namespace>
</Query>


    [Description("Listing 6.9")]
    class FakeLinq
{
	public static IEnumerable<T> Where<T>(IEnumerable<T> source, Predicate<T> predicate)
	{
		if (source == null || predicate == null)
		{
			throw new ArgumentNullException();
		}
		return WhereImpl(source, predicate);
	}

	private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, Predicate<T> predicate)
	{
		foreach (T item in source)
		{
			if (predicate(item))
			{
				yield return item;
			}
		}
	}

	static void Main()
	{
		IEnumerable<string> lines = LineReader.ReadLines(@"C:\Users\samtran\OneDrive\Documents\TextBookCodes\C# in Depth\OtherChapters\Chapter06\FakeLinq.cs");
		Predicate<string> predicate = delegate (string line)
			{ return line.StartsWith("using"); };
		foreach (string line in Where(lines, predicate))
		{
			Console.WriteLine(line);
		}
	}
}


[Description("Listing 6.8")]
class LineReader
{
	public static IEnumerable<string> ReadLines(string filename)
	{
		using (TextReader reader = File.OpenText(filename))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				yield return line;
			}
		}
	}

//	static void Main()
//	{
//		foreach (string line in ReadLines("../../LineReader.cs"))
//		{
//			Console.WriteLine(line);
//		}
//	}
}
