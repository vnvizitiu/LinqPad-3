<Query Kind="Program" />

void Main()
{//http://stackoverflow.com/questions/1551273/c-sharp-var-to-listt-conversion
//http://stackoverflow.com/questions/15071828/convert-list-type-to-ienumerable-interface-type
	string FirstFolder = @"C:\Users\Administrator\Documents\GRM\papa_deploy02Sam\";
	string SecondFolder = @"C:\Users\Administrator\Documents\GRM\papa_deploy02Sam\";
	QueryContents qc = new QueryContents();
	qc.Process(FirstFolder);



}
public class myFiles
{
	public string Filename { get; set; }
	public string Path { get; set; }

}

/////////////////////////////////////////////////////////////
// Read the contents of the file. 
static string GetFileText(string name)
{
	string fileContents = String.Empty;

	// If the file has been deleted since we took  
	// the snapshot, ignore it and return the empty string. 
	if (System.IO.File.Exists(name))
	{
		fileContents = System.IO.File.ReadAllText(name);
	}
	return fileContents;
}
 
// Define other methods and classes here

class QueryContents
{

	public void Process(string folder)
	{

		// Modify this path as necessary. 
		//string startFolder = @"C:\Users\Administrator\SkyDrive\Documents\LinqPad_Queries\";

		try
		{
			Console.WriteLine("trying");
			string startFolder = @"C:\Users\Sam\OneDrive\Documents\LinqPad_Queries\";

			// Take a snapshot of the file system.
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

			// This method assumes that the application has discovery permissions 
			// for all folders under the specified path.
			IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

			string searchTerm = @"a";

			// Search the contents of each file. 
			// A regular expression created with the RegEx class 
			// could be used instead of the Contains method. 
			// queryMatchingFiles is an IEnumerable<string>. 
			var queryMatchingFiles =
				from file in fileList
				where file.Extension == ".linq"
				let fileText = GetFileText(file.FullName)
				where fileText.Contains(searchTerm)
				select file.Name;

			// Load quickly
			
			List<string> fastList= queryMatchingFiles.ToList();///////////////////////////////////////////////////////////////////////////////////////////
			foreach (var fl in fastList)
			{
				Console.WriteLine(fl.ToString());
			}
			
			
			
			
			
			
			
			//slow list
		

			List<myFiles> myFirstList = new List<myFiles>();

			for (int i = 0; i < fileList.Count(); i++)
			{
				//Console.WriteLine(fileList.ElementAt(i));	
				myFiles mf = new myFiles();
				//new myFiles{ Filename=fileList.ElementAt(i).ToString(), Path="sam"};
				mf.Filename = fileList.ElementAt(i).ToString();
				mf.Path = fileList.ElementAt(i).ToString();
				myFirstList.Add(mf);
			}

			IEnumerable<myFiles>imyFirst_i=myFirstList;
			foreach (var element in imyFirst_i)
			{
				Console.WriteLine(element.Filename);
			}
			
			//OR var imyFirst_i=(IEnumerable<myFiles>)myFirstList;


			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit");
		}
		catch (Exception x)
		{
			//WriteLine (x.Message.ToString);
		}
	}
}