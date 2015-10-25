<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
</Query>

//using System;
//using System.IO;
//using System.Text.RegularExpressions;
//https://msdn.microsoft.com/en-us/library/system.idisposable%28v=vs.110%29.aspx

void Main()
{
	WordCount wc=new WordCount(@"C:\Users\Sam\SkyDrive\Documents\C#\BigData\How to Communicate to Hadoop via Hive using _NET-C# - CodeProject.mht");
	//Console.WriteLine(wc.nWords);
	
}

public class WordCount
{
   private String filename = String.Empty;
  private int nWords = 0;
  // public int nWords = 0;
   private String pattern = @"\b\w+\b"; 

   public WordCount(string filename)
   {
      if (! File.Exists(filename))
         throw new FileNotFoundException("The file does not exist.");

      this.filename = filename;
      string txt = String.Empty;
      using (StreamReader sr = new StreamReader(filename)) {
         txt = sr.ReadToEnd();
      }
      nWords = Regex.Matches(txt, pattern).Count;
	  Console.WriteLine(nWords);
	  
   }

   public string FullName
   { get { return filename; } }

   public string Name
   { get { return Path.GetFileName(filename); } }

   public int Count 
   { get { return nWords; } }
}   
