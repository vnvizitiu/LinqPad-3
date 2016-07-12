<Query Kind="Program" />

//http://stackoverflow.com/questions/2835929/c-funct-tresult-for-generic-methods
static void Main()
{
	Func<IEnumerable<int>, Func<int, int>, IOrderedEnumerable<int>> orderByFunc =
   System.Linq.Enumerable.OrderBy<int, int>;

	int[] ints = new int[] { 1, 3, 5, 4, 7, 2, 6, 9, 8 };

	// here you're really calling OrderBy<int, int> --
	// you've just stored its address in a variable of type Func<...>
	foreach (int i in orderByFunc(ints, x => x))
		Console.WriteLine(i);

}