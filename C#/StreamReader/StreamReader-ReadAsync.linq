<Query Kind="Program" />

class Example
{
    public static void Main()
    {	
		Console.WriteLine("Let's begin");
        ReadAndDisplayFilesAsync();
    }

    private async static void ReadAndDisplayFilesAsync()
    {
        String filename = @"C:\Users\Sam\SkyDrive\Documents\LinqPad_Queries\C#\FunctionConnString.linq";
        Char[] buffer;

        using (var sr = new StreamReader(filename)) {
            buffer = new Char[(int)sr.BaseStream.Length];
            await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
        }

        Console.WriteLine(new String(buffer));
    }
}
 //https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx
 //https://msdn.microsoft.com/en-us/library/hh137691(v=vs.110).aspx
 
    