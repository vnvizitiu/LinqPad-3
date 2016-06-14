<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.Install.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.JScript.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Management</Namespace>
</Query>

void Main() //https://msdn.microsoft.com/en-us/library/system.operatingsystem.servicepack(v=vs.110).aspx
{
	var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
				select x.GetPropertyValue("Caption")).FirstOrDefault();
	//return name != null ? name.ToString() : "Unknown";
	Console.WriteLine(name);
	Sample.Main();
	 
}

// Define other methods and classes here



class Sample 
{
    public static void Main() 
    {
    Console.WriteLine();
    Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());
	SampleSP.SP();
    }
}
/*
This example produces the following results:

OSVersion: Microsoft Windows NT 5.1.2600.0
*/
class SampleSP
{
	public static void SP()
	{
		OperatingSystem os = Environment.OSVersion;
		String sp = os.ServicePack;
		Console.WriteLine("Service pack version = \"{0}\"", sp);
	}
}
/*
This example produces the following results:

Service pack version = "Service Pack 1"

*/
