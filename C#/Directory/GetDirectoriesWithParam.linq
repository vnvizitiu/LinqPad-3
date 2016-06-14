<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

 
public   class Test 
{
    public static void Main() 
    {
        try 
        {
            string[] dirs = Directory.GetDirectories(@"c:\", "run*", SearchOption.TopDirectoryOnly);
            Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
            foreach (string dir in dirs) 
            {
                Console.WriteLine(dir);
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}