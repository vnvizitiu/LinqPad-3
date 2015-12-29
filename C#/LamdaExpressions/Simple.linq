<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>


class Program
{//http://www.dotnetperls.com/lambda
	static void Main()
	{
		List<int> elements = new List<int>() { 10, 20, 22, 31, 40 };
		// ... Find index of first odd element.
		int oddIndex = elements.FindIndex(x => x % 2 != 0);
		Console.WriteLine(oddIndex);
		 
		List<int> greater=elements.Where(e => e>  30).ToList();
 
	 
		
		
		greater.Dump();
		
		foreach (var element in greater)
		{
			Console.WriteLine(element);
			
		}
		
		
		
		
	}
}

//Output
//
//3