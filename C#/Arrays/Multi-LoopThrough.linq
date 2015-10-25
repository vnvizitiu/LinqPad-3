<Query Kind="Program" />

//https://msdn.microsoft.com/en-us/library/vstudio/9b9dty7d(v=vs.100).aspx
//http://stackoverflow.com/questions/8184306/iterate-through-2-dimensional-array-c-sharp
class TestArraysClass
{
    static void Main()
	{
		// Declare a single-dimensional array 
		int[] array1 = new int[5];

		// Declare and set array element values
		int[] array2 = new int[] { 1, 3, 5, 7, 9 };
		
		for (int i = 0; i < array2.Count(); i++)
		{
			Console.WriteLine(array2.ElementAt(i));
		}

		// Alternative syntax
		int[] array3 = { 1, 2, 3, 4, 5, 6 };

		// Declare a two dimensional array
		int[,] multiDimensionalArray1 = new int[2, 3];

		// Declare and set array element values
		int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
		
		Console.WriteLine();
		Console.WriteLine("Two Dimension Array");
		

		for (int i = 0; i < multiDimensionalArray2.GetLength(0); i++)
		{
			for (int j = 0; j < multiDimensionalArray2.GetLength(1); j++)
			{
				Console.WriteLine(string.Format("{0}\t", multiDimensionalArray2[i, j]));
			}
			Console.WriteLine("<br/>");
		}




		// Declare a jagged array
		int[][] jaggedArray = new int[6][];

		// Set the values of the first array in the jagged array structure
		jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
	}
}
