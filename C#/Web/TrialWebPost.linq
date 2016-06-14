<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	PostForm();	
}

private void PostForm()
        {
          //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:41787/api/product");
		 HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:41787");
		//	HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData ="home=Cosby&favorite+flavor=flies";
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
			result.Dump();
            stream.Dispose();
            reader.Dispose();
        }