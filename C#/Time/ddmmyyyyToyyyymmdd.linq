<Query Kind="Program" />

void Main()
{
	string strDate = "01/12/2013";
	string[] sa = strDate.Split('/');
	string strNew = sa[2] + "-" + sa[1] + "-" + sa[0];
	
	Console.WriteLine(strDate);
	Console.WriteLine(strNew);
	
}

// Define other methods and classes here
