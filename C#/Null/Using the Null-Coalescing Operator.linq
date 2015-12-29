<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2011/01/14/211-using-the-null-coalescing-operator/
{
	uint? age = null;   // Nullable age -- might not have a value

	// Later: assign to a non-nullable uint.
	//   Store the age (if non-null)
	//   Store 0  (if null)
	uint ageStore = age ?? 0;
	
	Console.WriteLine(age);
	Console.WriteLine(ageStore);
	

}

// Define other methods and classes here
