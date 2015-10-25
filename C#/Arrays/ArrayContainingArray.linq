<Query Kind="Program" />

 //http://stackoverflow.com/questions/2912476/using-c-sharp-to-check-if-string-contains-a-string-in-string-array
//http://stackoverflow.com/questions/496896/how-to-delete-an-element-from-an-array-in-c-sharp
//http://stackoverflow.com/questions/496896/how-to-delete-an-element-from-an-array-in-c-sharp
void Main()
{
	var arrayA = new[] { "element1", "element2" };
	var arrayB = new[] { "element1", "element3" };
 
	if (arrayA.Any(arrayB.Contains ))
	{
		Console.WriteLine("contains");
		for (int i = 0; i < arrayA.Count(); i++)
		{
		
			Console.WriteLine(arrayA.ElementAt(i));
		}
	}
}

// Define other methods and classes here