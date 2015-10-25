<Query Kind="Program" />

//https://msdn.microsoft.com/en-us/library/t3c3bfhx.aspx
class OutReturnExample
{
	static void Method(out int i, out string s1, out string s2)
	{
		i = 44;
		s1 = "I've been returned";
		s2 = null;
	}
	static void Main()
	{
		int value= 3;
		string str1="sam";
		string str2="tran";
		Method(out value, out str1, out str2);
		Console.WriteLine(value);
		Console.WriteLine(str1);
		Console.WriteLine(str2);
		
		// value is now 44 
		// str1 is now "I've been returned" 
		// str2 is (still) null;
	}
}