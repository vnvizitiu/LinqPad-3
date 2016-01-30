<Query Kind="Program" />

void Main()
{
	ProductsController pc=new ProductsController();
	IQueryable<Product> ret=pc.GetAllProductsasIQuery();
	ret.Dump();

	ret.ToArray();
	
	 

}

// Define other methods and classes here
public class ProductsController
{
	Product[] products = new Product[]
	{
			new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
			new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
			new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
	};

	public IEnumerable<Product> GetAllProducts()
	{
		return products;
	}

	public IQueryable<Product> GetAllProductsasIQuery()
	{
		IQueryable<Product> iqueryProduct=products.AsQueryable(); //https://msdn.microsoft.com/en-us/library/bb507003.aspx
		return iqueryProduct;
		
	}

}
public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Category { get; set; }
	public decimal Price { get; set; }

}