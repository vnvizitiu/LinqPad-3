<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference Relative="..\..\..\..\..\Documents\Visual Studio 2015\Dowloads\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll">&lt;MyDocuments&gt;\Visual Studio 2015\Dowloads\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 2\Assemblies\System.Web.Mvc.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
//http://www.c-sharpcorner.com/UploadFile/a6fd36/understanding-how-to-call-the-web-api-from-a-client-applica/  
//http://www.codeproject.com/Articles/611176/Calling-ASP-NET-WebAPI-using-HttpClient <<<<<<<<<<<<<<<<<<<<<<<<<<DLL

    class Program  

    {  

        static HttpClient client = new HttpClient();    

        static void Main(string[] args)  

        {  

            client.BaseAddress = new Uri("http://localhost:51925/");    

            ListAllBooks();  

             ListBook(1);  

           ListBooks("Yo-yo Toys");    

            Console.WriteLine("Press Enter to quit.");  

          

        }  

  

        static void ListAllBooks()  

        {  

            //Call HttpClient.GetAsync to send a GET request to the appropriate URI   

            HttpResponseMessage resp = client.GetAsync("api/products").Result;  

            //This method throws an exception if the HTTP response status is an error code.  

            resp.EnsureSuccessStatusCode();    
			
			
			var books = resp.Content.ReadAsAsync<IEnumerable<Book>>().Result;  
			books.Dump();
           // var books = resp.Content.ReadAsAsync<IEnumerable<SelfHost1.book>>().Result;  

            foreach (var p in books)  

             {  

                Console.WriteLine("{0} {1} {2} )",   p.Name, p.Category, p.Price);  
				

             }  

        }  

        static void ListBook(int id)  

        {  

            var resp = client.GetAsync(string.Format("api/products/{0}", id)).Result;  

            resp.EnsureSuccessStatusCode();  

  

            var book1 = resp.Content.ReadAsAsync<Book>().Result;  

            Console.WriteLine("ID {0}: {1}", id, book1.Name);  

         }

	static void ListBooks(string author)

	{

		Console.WriteLine("Books in '{0}':", author);

		string query = string.Format("api/products?author={0}", author);

		var resp = client.GetAsync(query).Result;

		resp.EnsureSuccessStatusCode();

		//This method is an extension method, defined in System.Net.Http.HttpContentExtensions    

		var books = resp.Content.ReadAsAsync<IEnumerable<Book>>().Result;

		foreach (var book in books)

		{

			Console.WriteLine(book.Name);

		}

	}

}

class Book
{
	public string Name { get; set; }
	public double Price { get; set; }
	public string Category { get; set; }
}