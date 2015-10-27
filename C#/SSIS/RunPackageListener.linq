<Query Kind="Program">
  <Reference>C:\Windows\assembly\GAC_MSIL\Microsoft.SqlServer.ManagedDTS\10.0.0.0__89845dcd8080cc91\Microsoft.SqlServer.ManagedDTS.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SQL Server\130\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Namespace>Microsoft.SqlServer.Dts.Runtime</Namespace>
  <Namespace>System</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/ms136090.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1
//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/1b3ed694-cf02-445e-8ff4-0de4fd45a464/error-dts-does-not-exist-in-the-namespace-microsoftsqlserver?forum=sqlintegrationservices
// c:\program files\microsoft sql server\90\SDK\Assemblies, this willl add ManagedDTS.dll to the project and solve the problem.  
//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/c333d8e5-a4ca-470e-a2d8-4f67a5e05a10/missing-microsoftsqlservermanageddts?forum=sqlintegrationservices
//C:\Windows\assembly\gac_msil\Microsoft.SqlServer.ManagedDTS\10.0.0.0__89845dcd8080cc91
//https://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dts.runtime.dtscontainer.execute.aspx
//https://msdn.microsoft.com/en-us/library/ms403343.aspx
class MyErrorEventListener : DefaultEvents
{
	public override bool OnError(DtsObject source, int errorCode, string subComponent,
	  string description, string helpFile, int helpContext, string idofInterfaceWithError)
	{
		// Add application-specific diagnostics here.
		Console.WriteLine("Error in {0}/{1} : {2}", source, subComponent, description);
		return false;
	}
}
class MyEventListenerInfo : DefaultEvents// https://msdn.microsoft.com/en-us/library/microsoft.sqlserver.dts.runtime.defaultevents.onprogress.aspx
{
	public override void OnProgress(TaskHost taskHost,
	string progressDescription,
	int percentComplete,
	int progressCountLow,
	int progressCountHigh,
	string subComponent,
	ref bool fireAgain
)
	{
		// Add application-specific diagnostics here.
		Console.WriteLine("Progress in {0}/{1} : {2}", progressDescription, subComponent, percentComplete);
		
	}
	
	
}
 

class Program
{
	static void Main(string[] args)
	{
		
		try
		{
			string pkgLocation;
			Package pkg;
			Application app;
			DTSExecResult pkgResults;

			MyErrorEventListener ErroreventListener = new MyErrorEventListener();
			MyEventListenerInfo InfoEventListener = new MyEventListenerInfo();

			pkgLocation =
			  @"C:\Users\samtran\Documents\Visual Studio 2008\Projects\Test\Test" +
			  @"\Package.dtsx";
			app = new Application();
			//pkg = app.LoadPackage(pkgLocation, ErroreventListener);
			//pkgResults = pkg.Execute(null, null, ErroreventListener, null, null);
			pkg = app.LoadPackage(pkgLocation, InfoEventListener);
			pkgResults = pkg.Execute(null, null, InfoEventListener, null, null);

			Console.WriteLine(pkgResults.ToString());
		
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.InnerException.ToString());
			throw;
		}
	}
}