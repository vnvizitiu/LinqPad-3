<Query Kind="Program" />

class Test 
{
	
    public static void Main() 
    {
        string path = @"C:\Users\Sam\Downloads\testts\test.txt";

        try 
        {
            if (File.Exists(path)) 
            {
                File.Delete(path);
            }
			Console.WriteLine("just showing how good this is...................."); 
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                sw.WriteLine("This");
                sw.WriteLine("is some text");
                sw.WriteLine("to test");
                sw.WriteLine("Reading");
            }

            using (StreamReader sr = new StreamReader(path)) 
            {

                while (sr.Peek() > -1) 
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}