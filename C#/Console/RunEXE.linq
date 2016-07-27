<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	try
	{
		var myExe = @"C:\VisualStudioExercises\JiraAddin_EWS\JiraAttacher\bin\Debug\JiraAttacher.exe";
		Process.Start(myExe);
	}
	catch (Win32Exception ex)
	{
		// ...
	}
}

// Define other methods and classes here
