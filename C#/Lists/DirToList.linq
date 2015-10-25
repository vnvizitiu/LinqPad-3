<Query Kind="Program" />

void Main()
{
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
			string startFolder = @"C:\Users\Administrator\Documents\GRM\papa_deploy02Sam\";

			// Take a snapshot of the file system.
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

			// This method assumes that the application has discovery permissions 
			// for all folders under the specified path.
			IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

			string searchTerm = @"dbo";

			// Search the contents of each file. 
			// A regular expression created with the RegEx class 
			// could be used instead of the Contains method. 
			// queryMatchingFiles is an IEnumerable<string>. 
			var queryMatchingFiles =
				from file in fileList
				where file.Extension == ".sql"
				let fileText = GetFileText(file.FullName)
				where fileText.Contains(searchTerm)
				select file.Name;

			// Execute the query.
			Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
			foreach (string filename in queryMatchingFiles)
			{
				//   Console.WriteLine(filename);
			}

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

			foreach (myFiles element in myFirstList)
			{
				Console.WriteLine(element.Filename);
				Console.WriteLine(element.Path);
			}


			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit");
		}
		catch (Exception x)
		{
			//WriteLine (x.Message.ToString);
		}
	}
}
