<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb503062%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
{
	int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

	IEnumerable<int> topThreeGrades =
		grades.OrderByDescending(grade => grade).Take(3);

	Console.WriteLine("The top three grades are:");
	foreach (int grade in topThreeGrades)
	{
		Console.WriteLine(grade);
	}
	/*
	 This code produces the following output:

	 The top three grades are:
	 98
	 92
	 85
	*/
}

// Define other methods and classes here
