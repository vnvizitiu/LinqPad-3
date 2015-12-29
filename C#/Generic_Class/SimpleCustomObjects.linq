<Query Kind="Program">
  <Namespace>System.Collections.Generic</Namespace>
</Query>

class Test<T> //http://www.dotnetperls.com/generic
{
	T _value;

	public Test(T t)
	{
		// The field has the same type as the parameter.
		this._value = t;
	}

	public void Write()
	{
		Console.WriteLine(this._value);
		Console.WriteLine(this.GetType());
				
	}
}

class Program
{
	static void Main()
	{
		// Use the generic type Test with an int type parameter.
		Test<int> test1 = new Test<int>(5);
		// Call the Write method.
		test1.Write();

		// Use the generic type Test with a string type parameter.
		Test<string> test2 = new Test<string>("cat");
		test2.Write();

		Book mybook = new Book { Title = "Sam's Greatest", Cost = 888, Publisher = "Ray's Publishing" };
		Test<Book> test3= new Test<Book>(mybook);
		test3.Write();

		List<Book> myCollection = new List<Book>() {
	new Book { Title = "LINQ in Action", Cost = 10, Publisher = "Sam" },
	new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymond" },
  new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymondx" },
  new Book { Title = "Extreme LINQ", Cost = 1, Publisher = "Krystal" }};

		Test<List<Book>> test4 = new Test<List<Book>>(myCollection);
		test4.Write();
		
	 




	}
}

public class Book
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }
}

