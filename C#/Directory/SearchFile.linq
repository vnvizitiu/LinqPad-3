<Query Kind="Program">
  <CopyLocal>true</CopyLocal>
</Query>

class QueryContents
{
    public static void Main()
    {
        // Modify this path as necessary. 
        //string startFolder = @"C:\Users\Administrator\SkyDrive\Documents\LinqPad_Queries\";
		
		try {
			Console.WriteLine("trying");
		 	string startFolder=@"C:\Users\Sam\Documents\Papa\GRM_Deployment\";

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
				select file.FullName;

			// Execute the query.
			Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
			foreach (string filename in queryMatchingFiles)
			{
				Console.WriteLine(filename);
			}

			// Keep the console window open in debug mode.
			Console.WriteLine("Press any key to exit");
		}
		catch (Exception x)
		{
			//WriteLine (x.Message.ToString);
			Console.WriteLine("Error was caught: " + x.Message);
		}
		finally
		{
			Console.WriteLine("this will run regardless");
		}




	}//end 
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
}
// Define other methods and classes here