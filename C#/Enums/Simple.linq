<Query Kind="Program" />

 class EnumProgram //http://www.tutorialspoint.com/csharp/csharp_enums.htm
{
	enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };

	static void Main(string[] args)
	{
		int WeekdayStart = (int)Days.Mon;
		int WeekdayEnd = (int)Days.Fri;
		Console.WriteLine("Monday: {0}", WeekdayStart);
		Console.WriteLine("Friday: {0}", WeekdayEnd);
	 
	}
}