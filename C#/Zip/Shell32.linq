<Query Kind="Program" />

//http://www.fluxbytes.com/csharp/unzipping-files-using-shell32-in-c/

//http://www.codeproject.com/Articles/34165/How-to-Utilise-the-Shell-Library-in-NET-as-a-COM
//https://msdn.microsoft.com/en-us/library/ms404280%28v=vs.110%29.aspx
public static void UnZip(string zipFile, string folderPath)

{

	if (!File.Exists(zipFile))

		throw new FileNotFoundException();



	if (!Directory.Exists(folderPath))

		Directory.CreateDirectory(folderPath);



	Shell32.Shell objShell = new Shell32.Shell();

	Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);

	Shell32.Folder sourceFile = objShell.NameSpace(zipFile);



	foreach (var file in sourceFile.Items())

	{

		destinationFolder.CopyHere(file, 4 | 16);

	}

}
void Main()



{

	//string x=@"T:\bak\";

	//string y=@"T:\bak\del2.txt";

	UnZip(@"T:\bak\del2.zip", @"T:\bak\");



}
