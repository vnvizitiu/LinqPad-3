<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.FileSystem.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.Compression</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/ms404280%28v=vs.110%29.aspx

//This example shows how to create and extract a compressed file that has a .zip file name extension by using the ZipFile class. It compresses the contents of a folder into a new .zip file and then extracts 
//that content to a new folder. To use the ZipFile class, you must reference the System.IO.Compression.FileSystem assembly in your project.
    class Program
{
	static void Main(string[] args)
	{
		string startPath = @"c:\example\start";
		string zipPath = @"c:\example\result.zip";
		string extractPath = @"c:\example\extract";

		ZipFile.CreateFromDirectory(startPath, zipPath);

		ZipFile.ExtractToDirectory(zipPath, extractPath);
	}
}
//The next example shows how to iterate through the contents of an existing .zip file and extract files that have a .txt extension. It uses the ZipArchive class to access an existing .zip file,
//and the ZipArchiveEntry class to inspect the individual entries in the compressed file. It uses an extension method (ExtractToFile) for the ZipArchiveEntry object. The extension method is 
//available in the System.IO.Compression.ZipFileExtensions class. To use the ZipFileExtensions class, you must reference the System.IO.Compression.FileSystem assembly in your project.
class Program2
{
	static void Main(string[] args)
	{
		string zipPath = @"c:\example\start.zip";
		string extractPath = @"c:\example\extract";

		using (ZipArchive archive = ZipFile.OpenRead(zipPath))
		{
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
				{
					entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
				}
			}
		}
	}
}

//The next example uses the ZipArchive class to access an existing .zip file, and adds a new
//file to the compressed file. The new file gets compressed when you add it to the existing .zip file.

class Program3
{
	static void Main(string[] args)
	{
		using (FileStream zipToOpen = new FileStream(@"c:\users\exampleuser\release.zip", FileMode.Open))
		{
			using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
			{
				ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
				using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
				{
					writer.WriteLine("Information about this package.");
					writer.WriteLine("========================");
				}
			}
		}
	}
}
