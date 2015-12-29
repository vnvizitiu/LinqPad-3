<Query Kind="Program" />

static void Main()
{//http://csharp.2000things.com/2012/06/06/599-copying-an-array-onto-another-array/
	int[] bigNumbers = { 400, 500, 600 };
	int[] smallerNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

	// Copy big number array into middle of small number array
	// Start at 4th element (index = 3)
	bigNumbers.CopyTo(smallerNumbers, 3);

	bigNumbers.Dump();
	smallerNumbers.Dump();
}
