<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main() //"9.3 Going Through a Proxy"
{
	HttpWebRequest request =
			GenerateHttpWebRequest(new Uri("http://internethost/mysite/index.aspx"));

	// add the proxy info
	AddProxyInfoToRequest(request,
						new Uri("http://webproxy:80"),
						"user",
						"pwd",
						"domain");

	// Set it up to go through the same proxy for all requests to this Uri
	Uri proxyURI = new Uri("http://webproxy:80");

	// in 1.1 you used to do this:
	//GlobalProxySelection.Select = new WebProxy(proxyURI);

	// Now in 2.0 and above you do this:
	WebRequest.DefaultWebProxy = new WebProxy(proxyURI);

	// for the current user Internet Explorer proxy info use this
	WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();
}

// Define other methods and classes here
public static HttpWebRequest AddProxyInfoToRequest(HttpWebRequest httpRequest,
		   Uri proxyUri,
		   string proxyId,
		   string proxyPassword,
		   string proxyDomain)
{
	if (httpRequest == null)
		throw new ArgumentNullException(nameof(httpRequest));

	// create the proxy object
	WebProxy proxyInfo = new WebProxy();
	// add the address of the proxy server to use
	proxyInfo.Address = proxyUri;
	// tell it to bypass the proxy server for local addresses
	proxyInfo.BypassProxyOnLocal = true;
	// add any credential information to present to the proxy server
	proxyInfo.Credentials = new NetworkCredential(proxyId,
		proxyPassword,
		proxyDomain);
	// assign the proxy information to the request
	httpRequest.Proxy = proxyInfo;

	// return the request
	return httpRequest;
}
public static HttpWebRequest GenerateHttpWebRequest(Uri uri)
{
	// create the initial request
	HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uri);
	// return the request
	return httpRequest;
}