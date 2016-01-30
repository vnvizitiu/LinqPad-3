<Query Kind="Program">
  <Connection>
    <ID>c588a4a4-e398-4bdf-97c4-ea4b578e359e</ID>
    <Persist>true</Persist>
    <Driver>AstoriaAuto</Driver>
    <Server>http://localhost:12565/BookDataService.svc </Server>
  </Connection>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
</Query>


    class Program/// got from C:\Users\samtran\OneDrive\Documents\TextBookCodes\OData Programming Cookbook for .NET Developers\ch02\WebRequestClientSln
{
	static void Main(string[] args)
	{
		//QueryAndCreateProductsByServiceProxy();

		QueryProductsByWebRequest();
		Console.ReadLine();

		//CreateProductByWebRequest();
	}
#region
//	static void QueryAndCreateProductsByServiceProxy()//this requires Entity Framework-inside Visual Studio Solution
//	{
//		var svcUri = new Uri("http://localhost:47568/NWDataService.svc/");
//		var ctx = new NWDataSvc.NorthwindEntities(svcUri);
//
//		Console.WriteLine("There are {0} products:", ctx.Products.Count());
//		foreach (var prod in ctx.Products)
//		{
//			ctx.LoadProperty(prod, "Category");
//			Console.WriteLine("Name:{0}, Category:{1}",
//				prod.ProductName,
	//				prod.Category.CategoryName
	//				);
	//		}
	//
	//		var id = DateTime.Now.Ticks.ToString();
	//		var newProduct = new NWDataSvc.Product()
	//		{
	//			ProductName = "NewProduct_" + id,
	//			CategoryID = 1,
	//			Discontinued = false,
	//			QuantityPerUnit = "5 x 5",
	//			ReorderLevel = 3,
	//			SupplierID = 1,
	//			UnitPrice = 33,
	//			UnitsInStock = 22,
	//			UnitsOnOrder = 11
//		};
//
//		ctx.AddObject("Products", newProduct);
//		var saveResponse = ctx.SaveChanges();
//
//		Console.WriteLine("Save Response Status Code: {0}", saveResponse.First().StatusCode);
//
//		Console.WriteLine("There are {0} products:", ctx.Products.Count());
//	}
   #endregion
	static void QueryProductsByWebRequest()
	{
		// Generate the OData request Uri
		var svcUri = new Uri("http://localhost:47568/NWDataService.svc/");
		var productsUri = new Uri(svcUri, "Products");

		// Create WebRequest object
		var req = WebRequest.Create(productsUri) as HttpWebRequest;
		req.Method = "GET";

		// Retrieve the query response and load it as Xml 
		var rep = req.GetResponse() as HttpWebResponse;
		var doc = XDocument.Load(rep.GetResponseStream());
		rep.Close();

		// Parse the response XML with LINQ to XML 
		var nsDefault = XNamespace.Get("http://www.w3.org/2005/Atom");
		var nsMetadata = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
		var nsData = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");

		try
		{
			var elmsProducts = from p in doc.Descendants(nsDefault + "entry")
							   select p.Descendants(nsMetadata + "properties").First();
			Console.WriteLine("There are {0} products.", elmsProducts.Count());
			foreach (var elmProduct in elmsProducts)
			{
				var pID = elmProduct.Descendants(nsData + "ProductID").First().Value;
				var pName = elmProduct.Descendants(nsData + "ProductName").First().Value;
				var cateID = elmsProducts.Descendants(nsData + "CategoryID").First().Value;

				Console.WriteLine("ID:{0}, Name:{1}, CategoryID:{2}",
					pID,
					pName,
					cateID
					);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			throw;
		}


	}

	static void CreateProductByWebRequest()
	{
		// Compose OData request Uri(for creating entity)
		var svcUri = new Uri("http://localhost:47568/NWDataService.svc/");
		var productsUri = new Uri(svcUri, "Products");

		// Create WebRequest object(and initialize the proper headers)
		var req = WebRequest.Create(productsUri) as HttpWebRequest;
		req.Method = "POST";
		req.Headers.Add("DataServiceVersion", "1.0;NetFx");
		req.Headers.Add("MaxDataServiceVersion", "2.0;NetFx");
		req.Accept = "application/atom+xml,application/xml";
		req.ContentType = "application/atom+xml";

		// Construct the Xml element for the new entity
		var elmNewProduct = CreateXElementForNewProduct();

		// Write the Xml content into request stream of WebRequest
		using (var reqWriter = XmlWriter.Create(req.GetRequestStream()))
		{
			elmNewProduct.WriteTo(reqWriter);
		}

		// Retrieve and process the HTTP response
		var rep = req.GetResponse() as HttpWebResponse;
		if (rep.StatusCode == HttpStatusCode.Created)
		{
			Console.WriteLine("New Product created at {0}", rep.Headers["Location"]);
		}
		else
		{
			Console.WriteLine("New Product creation failed");
		}
	}

	static XElement CreateXElementForNewProduct()
	{
		// Compose the HTTP request body via LINQ to XML
		var nsDefault = XNamespace.Get("http://www.w3.org/2005/Atom");
		var nsMetadata = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
		var nsData = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");

		var id = DateTime.Now.Ticks;
		var elmProperties = new XElement(nsMetadata + "properties",
			new XElement(nsData + "ProductName", "NewProduct_" + id),
			new XElement(nsData + "CategoryID", "1"),
			new XElement(nsData + "Discontinued", "false"),
			new XElement(nsData + "QuantityPerUnit", "5 x 5"),
			new XElement(nsData + "ReorderLevel", "3"),
			new XElement(nsData + "SupplierID", "1"),
			new XElement(nsData + "UnitPrice", "33"),
			new XElement(nsData + "UnitsInStock", "22"),
			new XElement(nsData + "UnitsOnOrder", "11")
			);

		var elmCreateProduct = new XElement(nsDefault + "entry",
			new XElement(nsDefault + "title", "New Product Entity"),
			new XElement(nsDefault + "id"),
			new XElement(nsDefault + "updated", DateTime.Now),
			new XElement(nsDefault + "author"),
			new XElement(nsDefault + "content",
				new XAttribute("type", "application/xml"),
				elmProperties
			)
		);

		return elmCreateProduct;
	}
}
