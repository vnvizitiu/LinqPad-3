<Query Kind="Program" />

class Test 
{
    public static void Main() 
    {
        try 
        {
            // Create an instance of StreamReader to read from a file. 
            // The using statement also closes the StreamReader. 
            using (StreamReader sr = new StreamReader(@"C:\Users\Sam\SkyDrive\Documents\LinqPad_Queries\C#\FunctionConnString.linq"))
            {
                string line;
                // Read and display lines from the file until the end of  
                // the file is reached. 
                while ((line = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e) 
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}//https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx