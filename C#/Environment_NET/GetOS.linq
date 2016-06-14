<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.Install.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.JScript.dll</Reference>
  <Namespace>System.Management</Namespace>
</Query>

void Main()
{
	var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
				select x.GetPropertyValue("Caption")).FirstOrDefault();
	//return name != null ? name.ToString() : "Unknown";
	Console.WriteLine(name);
	
	string friedly=GetOSFriendlyName();
	Console.WriteLine(friedly);
}

// Define other methods and classes here
public static string GetOSFriendlyName()
{
	string result = string.Empty;
	ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
	foreach (ManagementObject os in searcher.Get())
	{
		result = os["Caption"].ToString();
		break;
	}
	return result;
}