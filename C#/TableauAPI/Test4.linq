<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

static async Task RunAsync()
{

	var baseAddress = new Uri("https://tableau.cba/");

	using (var httpClient = new HttpClient { BaseAddress = baseAddress })
	{
		httpClient.DefaultRequestHeaders.Authorization=  new AuthenticationHeaderValue("X-Tableau-Auth","fFkJJJGo9NBKs4WEfXoVKKdzi67HuSjj");
		using (var response = await httpClient.GetAsync("api/2.0/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/workbooks/1df2bf4c-df65-43df-a2c1-bd404a218dc6/connections"))
		{


			string responseData = await response.Content.ReadAsStringAsync();
			responseData.Dump();

		}
	}
}
async Task Main()
{
	await RunAsync();
}
