<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference Relative="..\..\Files\System.Net.Http.Formatting.dll">C:\Linqpad_Queries\Files\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 2\Assemblies\System.Web.Mvc.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

 static void ListBook(int id)  
 
        {
	HttpClient client = new HttpClient();
	client.BaseAddress = new Uri("http://n03fwt0w6250.s4.chp.cba/idr/");

//	HttpResponseMessage resp = client.GetAsync("api/requests/{10}").Result;
   var resp = client.GetAsync(string.Format("api/Jobs/{0}", id)).Result;
  // resp.Dump();
   Console.WriteLine(resp.Content);
   Console.WriteLine(resp.RequestMessage);

	resp.EnsureSuccessStatusCode();



	//  var book1 = resp.Content.ReadAsAsync<Book>().Result;  

         //   Console.WriteLine("ID {0}: {1}", id, book1.Name);

}
void Main()
{
	ListBook(1026);
}
