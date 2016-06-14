<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

static async Task RunAsync()
{
	string _user;
	string _password;
	string _authorizationType;
	string _contentType;
	string _CredentialsToBase64;
	string _url = "http://tableau.cba/";

	_user = @"au\samtran";
	_password = "Raymond123";
	_authorizationType = "basic";
	_contentType = "application/json";
	_CredentialsToBase64 = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_user + ":" + _password));


	using (var client = new HttpClient())
	{
		client.BaseAddress = new Uri(_url);
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_contentType));
		client.DefaultRequestHeaders.Add("Authorization", _authorizationType + " " + _CredentialsToBase64);

		using (HttpResponseMessage httpResponse = await client.GetAsync("api/2.0/sites/791f4c7a-6452-4422-9e5a-78fbde52c89f/workbooks/1df2bf4c-df65-43df-a2c1-bd404a218dc6/connections"))
 	 //	using (HttpResponseMessage httpResponse = await client.GetAsync("http://tableau.cba/api/2.0/sites/Default?key=name"))
 
		{
			if (httpResponse.IsSuccessStatusCode)
			{
			Console.WriteLine("Success");
			httpResponse.Content.Dump();
			
     	     httpResponse.Dump();
		}
			else
			{
			Console.WriteLine(string.Format("Service request failed ({0})", httpResponse.StatusCode));
			httpResponse.Dump();
		}
	}

}
}

async Task Main()
{
	await RunAsync();
}