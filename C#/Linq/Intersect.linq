<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb355408%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
{
	Product[] store1 = { new Product { Name = "apple", Code = 9 },
					   new Product { Name = "orange", Code = 4 } };

	Product[] store2 = { new Product { Name = "apple", Code = 9 },
					   new Product { Name = "lemon", Code = 12 } };
	// Get the products from the first array 
	// that have duplicates in the second array.

	IEnumerable<Product> duplicates =
		store1.Intersect(store2, new ProductComparer());

	foreach (var product in duplicates)
		Console.WriteLine(product.Name + " " + product.Code);

	/*
		This code produces the following output:
		apple 9
	*/
}

// Define other methods and classes here
public class Product
{
	public string Name { get; set; }
	public int Code { get; set; }
}

// Custom comparer for the Product class
class ProductComparer : IEqualityComparer<Product>
{
	// Products are equal if their names and product numbers are equal.
	public bool Equals(Product x, Product y)
	{

		//Check whether the compared objects reference the same data.
		if (Object.ReferenceEquals(x, y)) return true;

		//Check whether any of the compared objects is null.
		if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
			return false;

		//Check whether the products' properties are equal.
		return x.Code == y.Code && x.Name == y.Name;
	}

	// If Equals() returns true for a pair of objects 
	// then GetHashCode() must return the same value for these objects.

	public int GetHashCode(Product product)
	{
		//Check whether the object is null
		if (Object.ReferenceEquals(product, null)) return 0;

		//Get hash code for the Name field if it is not null.
		int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

		//Get hash code for the Code field.
		int hashProductCode = product.Code.GetHashCode();

		//Calculate the hash code for the product.
		return hashProductName ^ hashProductCode;
	}

}