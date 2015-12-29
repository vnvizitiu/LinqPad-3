<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.Compression</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/ms404280%28v=vs.110%29.aspx

//You can also use the GZipStream and DeflateStream classes to compress and decompress data. They use the same compression algorithm. 
//Compressed GZipStream objects that are written to a file that has an extension of .gz can be decompressed by using many common tools in addition 
//to the methods provided by GZipStream. This example shows how to compress and decompress a directory of files by using the GZipStream class.
    public class Program
{
	private static string directoryPath = @"c:\temp";
	public static void Main()
	{
		DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
		Compress(directorySelected);

		foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
		{
			Decompress(fileToDecompress);
		}
	}

	public static void Compress(DirectoryInfo directorySelected)
	{
		foreach (FileInfo fileToCompress in directorySelected.GetFiles())
		{
			using (FileStream originalFileStream = fileToCompress.OpenRead())
			{
				if ((File.GetAttributes(fileToCompress.FullName) &
				   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
				{
					using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
					{
						using (GZipStream compressionStream = new GZipStream(compressedFileStream,
						   CompressionMode.Compress))
						{
							originalFileStream.CopyTo(compressionStream);

						}
					}
					FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".gz");
					Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
					fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
				}

			}
		}
	}

	public static void Decompress(FileInfo fileToDecompress)
	{
		using (FileStream originalFileStream = fileToDecompress.OpenRead())
		{
			string currentFileName = fileToDecompress.FullName;
			string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

			using (FileStream decompressedFileStream = File.Create(newFileName))
			{
				using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
				{
					decompressionStream.CopyTo(decompressedFileStream);
					Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
				}
			}
		}
	}
}
