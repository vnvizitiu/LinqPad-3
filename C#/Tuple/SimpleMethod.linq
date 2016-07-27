<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/system.tuple%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
{
	// Create a 7-tuple.
	var population = new Tuple<string, int, int, int, int, int, int>(
							   "New York", 7891957, 7781984,
							   7894862, 7071639, 7322564, 8008278);
	// Display the first and last elements.
	Console.WriteLine("Population of {0} in 2000: {1:N0}",
					  population.Item1, population.Item7);
	// The example displays the following output:
	//       Population of New York in 2000: 8,008,278

	// Create a 7-tuple.
	var population2 = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
	// Display the first and last elements.
	Console.WriteLine("Population of {0} in 2000: {1:N0}",
					  population2.Item1, population.Item7);
	// The example displays the following output:
	//       Population of New York in 2000: 8,008,278
	var primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
	Console.WriteLine("Prime numbers less than 20: " +
					  "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
					  primes.Item1, primes.Item2, primes.Item3,
					  primes.Item4, primes.Item5, primes.Item6,
					  primes.Item7, primes.Rest.Item1);
	// The example displays the following output:
	//    Prime numbers less than 20: 2, 3, 5, 7, 11, 13, 17, and 19

}

// Define other methods and classes here
