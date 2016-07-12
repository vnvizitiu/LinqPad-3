<Query Kind="Program" />

void Main()
{	
	 CreateFolder(@"C:\Users\samtran\Downloads\delete\Delete\delete\deletagain\file.txt");
}
private void CreateFolder(string myfile)
{
	try
	{
		string myDir = System.IO.Path.GetDirectoryName(myfile);
		System.IO.Directory.CreateDirectory(myDir); //create if not exists, ignore if exists
	}
	catch (Exception e)
	{
		Console.WriteLine(e.ToString());
		throw;
	}


}
// Define other methods and classes here
