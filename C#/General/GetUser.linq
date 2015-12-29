<Query Kind="Program" />

void Main()
{
	string s = "";
	s = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
	s.Dump();

}

// Define other methods and classes here
