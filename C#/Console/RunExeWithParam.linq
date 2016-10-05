<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	try
	{
		ProcessStartInfo startInfo = new ProcessStartInfo(string.Concat("control.exe"));
		//startInfo.Arguments ="Microsoft.CredentialManager";
	    // startInfo.UseShellExecute = true;
		// startInfo.CreateNoWindow=false;
		System.Diagnostics.Process.Start(startInfo);
		
	}
	catch (Win32Exception ex)
	{
		Console.WriteLine(ex);
		// ...
	}
}

// Define other methods and classes here