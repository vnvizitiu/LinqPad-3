<Query Kind="Program" />

class Test 
{
    public static void Main() 
    {
        try 
        {
 			string[] sData = null;
			int i=0;
            using (StreamReader sr = new StreamReader(@"\\naunsw002\cis8_upia_sy$\UPCPDATA\PAS_DATA\StampDuty\Nov14-15\Jan15\L41501DV"))
            {
                string line;
                 while ((line = sr.ReadLine()) != null & i<85601) 
                {
         
					if (i>85595)
					{
						 Console.WriteLine(i.ToString() + "............." + line);
					}
					i=i+1;
                }
            }
        }
 
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
} 