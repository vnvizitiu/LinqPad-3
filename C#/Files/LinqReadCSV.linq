<Query Kind="Program" />

void Main()
{
       string[] allLines = File.ReadAllLines(@"C:\delete.csv");
       var query = from line in allLines
                           let data = line.Split(',') 
                           select new
                           {
                                  Workspace= data[0],
                                  RunNumber= data[1],
                                  Product = data[2]
                           };

       foreach (var s in query)
       {
              if (!s.RunNumber.Contains("4"))
              {
                     Console.WriteLine("[{0}] {1} {2}", s.Workspace, s.RunNumber, s.Product);
              }
       }
       Console.WriteLine(query.Count(q => q.RunNumber == "4"));
       Console.WriteLine(query.Count(q => q.RunNumber != "4"));
}

 

// Define other methods and classes here
