<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main()
{
	PostForm();	//wrong data type so will not work, have not figured a way for 
}

private void PostForm()
        {
          //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:41787/api/product");
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:56851/api/user/AddUser");
            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
			// request.ContentType = "json";
			
			
			
            string postData ="home=Cosby&favorite+flavor=flies";

		string postData2 = new JavaScriptSerializer().Serialize(new
		{
		ID = 500,
		FirstName = "Trial",
		LastName = "Call",
		Company = "Commonwealth Bankk",
		PhoneNo = "8888"

		});



	byte[] bytes = Encoding.UTF8.GetBytes(postData2);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
			
			try
				{
					var result = reader.ReadToEnd();
					stream.Dispose();
					reader.Dispose();
				}
			catch (Exception ex)
			{
				
				 Console.WriteLine(ex.ToString());
			}
			
        }