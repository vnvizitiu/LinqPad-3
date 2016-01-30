<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main() //http://www.albahari.com/threading/part5.aspx
{
	
	try
	{
		if (!File.Exists("WordLookup.txt"))    // Contains about 150,000 words
			new WebClient().DownloadFile(
			  "http://www.albahari.com/ispell/allwords.txt", @"C:\Users\samtran\Downloads\WordLookup.txt");
			  

	
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
		throw;
	}
	var wordLookup = new HashSet<string>(
	  File.ReadAllLines(@"C:\Users\samtran\Downloads\WordLookup.txt"),
	  StringComparer.InvariantCultureIgnoreCase);

	var random = new Random();
	string[] wordList = wordLookup.ToArray();

	string[] wordsToTest = Enumerable.Range(0, 1000000)
	  .Select(i => wordList[random.Next(0, wordList.Length)])
	  .ToArray();

	wordsToTest[12345] = "woozsh";     // Introduce a couple
	wordsToTest[23456] = "wubsie";     // of spelling mistakes.


	var query = wordsToTest
  .AsParallel()
  .Select((word, index) => new IndexedWord { Word = word, Index = index })
  .Where(iword => !wordLookup.Contains(iword.Word))
  .OrderBy(iword => iword.Index);

	query.Dump();     // Display output in LINQPad
}
struct IndexedWord { public string Word; public int Index; }
// Define other methods and classes here