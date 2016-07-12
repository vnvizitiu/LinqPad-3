<Query Kind="Program" />

void Main()
{
	string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
	Console.WriteLine(userName);
	
	string user=Environment.UserName;
	Console.WriteLine(user);
}

// Define other methods and classes here
