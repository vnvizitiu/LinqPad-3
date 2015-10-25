<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
</Query>

//https://support.microsoft.com/en-us/kb/320727

   class host
   {
	[STAThread]
	static void Main(string[] args)
	{
		// Create an arary of car objects.      
		car[] arrayOfCars = new car[6]
		{
			new car("Ford",1992),
			new car("Fiat",1988),
			new car("Buick",1932),
			new car("Ford",1932),
			new car("Dodge",1999),
			new car("Honda",1977)
		};

		// Write out a header for the output.
		Console.WriteLine("Array - Unsorted\n");

		foreach (car c in arrayOfCars)
			Console.WriteLine(c.Make + "\t\t" + c.Year);

		// Demo IComparable by sorting array with "default" sort order.
		Array.Sort(arrayOfCars);
		Console.WriteLine("\nArray - Sorted by Make (Ascending - IComparable)\n");

		foreach (car c in arrayOfCars)
			Console.WriteLine(c.Make + "\t\t" + c.Year);

		// Demo ascending sort of numeric value with IComparer.
		Array.Sort(arrayOfCars, car.sortYearAscending());
		Console.WriteLine("\nArray - Sorted by Year (Ascending - IComparer)\n");

		foreach (car c in arrayOfCars)
			Console.WriteLine(c.Make + "\t\t" + c.Year);

		// Demo descending sort of string value with IComparer.
		Array.Sort(arrayOfCars, car.sortMakeDescending());
		Console.WriteLine("\nArray - Sorted by Make (Descending - IComparer)\n");

		foreach (car c in arrayOfCars)
			Console.WriteLine(c.Make + "\t\t" + c.Year);

		// Demo descending sort of numeric value using IComparer.
		Array.Sort(arrayOfCars, car.sortYearDescending());
		Console.WriteLine("\nArray - Sorted by Year (Descending - IComparer)\n");

		foreach (car c in arrayOfCars)
			Console.WriteLine(c.Make + "\t\t" + c.Year);

	}
}

public class car : IComparable
{
	// Beginning of nested classes.

	// Nested class to do ascending sort on year property.
	private class sortYearAscendingHelper : IComparer
	{
		int IComparer.Compare(object a, object b)
		{
			car c1 = (car)a;
			car c2 = (car)b;

			if (c1.year > c2.year)
				return 1;

			if (c1.year < c2.year)
				return -1;

			else
				return 0;
		}
	}

	// Nested class to do descending sort on year property.
	private class sortYearDescendingHelper : IComparer
	{
		int IComparer.Compare(object a, object b)
		{
			car c1 = (car)a;
			car c2 = (car)b;

			if (c1.year < c2.year)
				return 1;

			if (c1.year > c2.year)
				return -1;

			else
				return 0;
		}
	}

	// Nested class to do descending sort on make property.
	private class sortMakeDescendingHelper : IComparer
	{
		int IComparer.Compare(object a, object b)
		{
			car c1 = (car)a;
			car c2 = (car)b;
			return String.Compare(c2.make, c1.make);
		}
	}

	// End of nested classes.

	private int year;
	private string make;

	public car(string Make, int Year)
	{
		make = Make;
		year = Year;
	}

	public int Year
	{
		get { return year; }
		set { year = value; }
	}

	public string Make
	{
		get { return make; }
		set { make = value; }
	}

	// Implement IComparable CompareTo to provide default sort order.
	int IComparable.CompareTo(object obj)
	{
		car c = (car)obj;
		return String.Compare(this.make, c.make);
	}

	// Method to return IComparer object for sort helper.
	public static IComparer sortYearAscending()
	{
		return (IComparer)new sortYearAscendingHelper();
	}

	// Method to return IComparer object for sort helper.
	public static IComparer sortYearDescending()
	{
		return (IComparer)new sortYearDescendingHelper();
	}

	// Method to return IComparer object for sort helper.
	public static IComparer sortMakeDescending()
	{
		return (IComparer)new sortMakeDescendingHelper();
	}

}
