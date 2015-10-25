<Query Kind="Program" />

//http://stackoverflow.com/questions/1449646/how-can-i-execute-a-sql-from-c

void Main()
{
	 string server="SAMMYPRO", database="Papa", file=@"C:\Users\Sam\Documents\Papa\GRM_Deployment\Tables\001\dbo.app_t_CCPBalances.sql"
	 				,user="sa", password="Fate1972";
	try
	{
		var startInfo = new ProcessStartInfo();
		startInfo.FileName = "SQLCMD.EXE";
		startInfo.Arguments = String.Format("-S {0} -d {1} -U {2} -P {3} -i {4}",
											server,
											database,
											user,
											password,
											file);
//		startInfo.CreateNoWindow = true;
//		startInfo.RedirectStandardError = true;
//		startInfo.RedirectStandardOutput = true;

		Process.Start(startInfo);


		//without passwords
		//		string server = "SAMMYPRO", database = "Papa", file = @"C:\Users\Sam\Documents\Papa\GRM_Deployment\Tables\001\dbo.app_t_CCPBalances.sql";
		////
		//		var startInfo = new ProcessStartInfo();
//		startInfo.FileName = "SQLCMD.EXE";
//		startInfo.Arguments = String.Format("-S {0} -d {1} -i {2}",
//											server,
//											database,
//											file);
//		Process.Start(startInfo);

	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
		throw;
	}
}

