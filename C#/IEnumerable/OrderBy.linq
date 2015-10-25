<Query Kind="Program" />

void Main()
{
	 string FolderName=@"C:\Users\Sam\Documents\Papa\GRM_Deployment\Tables";
	//System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(myfolders.ElementAt(i).ToString());
	System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(FolderName);
	//IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories).OrderByDescending(d => d.FullName);
	IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories).OrderBy(d => d.FullName);
	
	var OrderfileList = from x in dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)
	where true
	orderby x ascending
	select x.FullName;

	IEnumerable ss = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories).OrderBy(d => d.FullName).Select(d => new { d.FullName, d.Directory, d.DirectoryName});
	IEnumerable sss = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Select(d => new { d.FullName, d.Directory, d.DirectoryName}).OrderBy(d => d.Directory);
	
	 
	
	foreach (var element in fileList)
	{
		Console.WriteLine(element.FullName);
	}
	
//	foreach (var el in OrderfileList)
//	{
//		Console.WriteLine(el);
//	}
	foreach (var  s in ss)
	{
		Console.WriteLine(s);
		
	}
	
	 
}


// Define other methods and classes here