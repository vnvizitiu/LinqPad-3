<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/vstudio/bb300779(v=vs.100).aspx
{
	Product[] fruits1 = { new Product { Name = "apple", Code = 9 },
							   new Product { Name = "orange", Code = 4 },
								new Product { Name = "lemon", Code = 12 } };

	Product[] fruits2 = { new Product { Name = "apple", Code = 9 } };

	//Get all the elements from the first array
	//except for the elements from the second array.

	IEnumerable<Product> except =
		fruits1.Except(fruits2);

	foreach (var product in except)
		Console.WriteLine(product.Name + " " + product.Code);

	/*
	  This code produces the following output:

	  orange 4
	  lemon 12
	*/

}

// Define other methods and classes here

public class Product : IEquatable<Product>
{
	public string Name { get; set; }
	public int Code { get; set; }

	public bool Equals(Product other)
	{

		//Check whether the compared object is null.
		if (Object.ReferenceEquals(other, null)) return false;

		//Check whether the compared object references the same data.
		if (Object.ReferenceEquals(this, other)) return true;

		//Check whether the products' properties are equal.
		return Code.Equals(other.Code) && Name.Equals(other.Name);
	}

	// If Equals() returns true for a pair of objects 
	// then GetHashCode() must return the same value for these objects.

	public override int GetHashCode()
	{

		//Get hash code for the Name field if it is not null.
		int hashProductName = Name == null ? 0 : Name.GetHashCode();

		//Get hash code for the Code field.
		int hashProductCode = Code.GetHashCode();

		//Calculate the hash code for the product.
		return hashProductName ^ hashProductCode;
	}
}

