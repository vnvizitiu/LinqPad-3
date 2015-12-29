<Query Kind="Program">
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

//Chapter 1: C# in Depth 3rd Edition
[Description("Listing 1.3")]
class Product
{
	public string Name { get; private set; }
	public decimal Price { get; private set; }

	public Product(string name, decimal price)
	{
		Name = name;
		Price = price;
	}

	Product()
	{
	}

	public static List<Product> GetSampleProducts()
	{
		return new List<Product>
			{
				new Product { Name="West Side Story", Price = 9.99m },
				new Product { Name="Assassins", Price=14.99m },
				new Product { Name="Frogs", Price=13.99m },
				new Product { Name="Sweeney Todd", Price=10.99m}
			};
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}", Name, Price);
	}
}

class ListSortWithLambdaExpression
{
	static void Main()
	{
		
		List<Product> products = Product.GetSampleProducts();
	
		
		products.Sort(
			(first, second) => first.Name.CompareTo(second.Name)
		);
		foreach (Product product in products)
		{
			Console.WriteLine(product);
		}
		ListSortWithComparer.Main2();
	}
}

//below is old way
public static class ListSortWithComparer
{
	class ProductNameComparer : IComparer<Product>
	{
		public int Compare(Product first, Product second)
		{
			return first.Name.CompareTo(second.Name);
		}
	}

	public static void Main2()
	{
		List<Product> products = Product.GetSampleProducts();
		products.Sort(new ProductNameComparer());
		foreach (Product product in products)
		{
			Console.WriteLine(product);
		}
	}
}