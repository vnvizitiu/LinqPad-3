<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference Relative="..\..\..\..\..\Documents\Visual Studio 2015\Dowloads\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll">&lt;MyDocuments&gt;\Visual Studio 2015\Dowloads\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 2\Assemblies\System.Web.Mvc.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//http://www.codeproject.com/Articles/611176/Calling-ASP-NET-WebAPI-using-HttpClient <<<<<<<<<<<<<<<<<<<<<<<<<<DLL
//http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
//http://www.codeproject.com/Articles/611176/Calling-ASP-NET-WebAPI-using-HttpClient
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://bida.azurewebsites.net//");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }

                // HTTP POST
                var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                response = await client.PostAsJsonAsync("api/products", gizmo);
                if (response.IsSuccessStatusCode)
			{
				Uri gizmoUrl = response.Headers.Location;

				// HTTP PUT   
				gizmo.Price = 80;   // Update price
		 //      response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

				// HTTP DELETE
				response = await client.DeleteAsync(gizmoUrl);
			}
		}
	}
}