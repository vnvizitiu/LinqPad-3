<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

//Chapter 1: C# in Depth 3rd Edition
 class ProductWithNullablePrice
{
	public string Name { get; private set; }
	public decimal? Price { get; private set; }

	public ProductWithNullablePrice(string name, decimal price)
	{
		Name = name;
		Price = price;
	}

	ProductWithNullablePrice()
	{
	}

	public static List<ProductWithNullablePrice> GetSampleProducts()
	{
		return new List<ProductWithNullablePrice>
			{
				new ProductWithNullablePrice { Name="West Side Story", Price = 9.99m },
				new ProductWithNullablePrice { Name="Assassins", Price=14.99m },
				new ProductWithNullablePrice { Name="Frogs", Price=13.99m },
				new ProductWithNullablePrice { Name="Sweeney Todd", Price=null}
			};
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}", Name, Price);
	}
}


    [Description("Listing 1.14")]
    class DisplayProductsWithUnknownPrice
    {
        static void Main()
        {
            List<ProductWithNullablePrice> products = ProductWithNullablePrice.GetSampleProducts();
            foreach (ProductWithNullablePrice product in products.Where(p => p.Price == null))
            {
                Console.WriteLine(product.Name);
            }
		}
	}


