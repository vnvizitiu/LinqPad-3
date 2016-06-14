<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
</Query>

///https://msdn.microsoft.com/en-us/library/office/dn567668.aspx
//https://msdn.microsoft.com/en-us/library/office/dn535506(v=exchg.150).aspx

  class Program
  {
	static void Main(string[] args)
	{
		ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

		service.Credentials = new WebCredentials("samtran@cbainet.com", "Hotdog88");

		service.TraceEnabled = true;
		service.TraceFlags = TraceFlags.All;

		service.AutodiscoverUrl("samtran@colonialfirststate.com.au", RedirectionUrlValidationCallback);

		EmailMessage email = new EmailMessage(service);

		email.ToRecipients.Add("samtran@colonialfirststate.com.au");
		email.CcRecipients.Add("sammy1188@hotmail.com");

		email.Subject = "HelloWorld_Marry had a little lamb";
		email.Body = new MessageBody("This is the first email I've sent by using the EWS Managed API-save and send");
	 //	email.SendAndSaveCopy();
		//email.Send();


		// Bind the Inbox folder to the service object.
		Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);

		// The search filter to get unread email.
		SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
		ItemView view = new ItemView(1);

		// Fire the query for the unread items.
		// This method call results in a FindItem call to EWS.
		FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
		findResults.Dump();

		foreach (Item item in findResults.Items)
		{
			item.Load();
			string subject = item.Subject;
			string mailMessage = item.Body;
			Console.WriteLine("this is the subject:"+subject);
			Console.WriteLine("this is the body....");
			mailMessage.Dump();
		}

		Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
//		view.Dump();

	}

	private static bool RedirectionUrlValidationCallback(string redirectionUrl)
	{
		// The default for the validation callback is to reject the URL.
		bool result = false;

		Uri redirectionUri = new Uri(redirectionUrl);

		// Validate the contents of the redirection URL. In this simple validation
		// callback, the redirection URL is considered valid if it is using HTTPS
		// to encrypt the authentication credentials. 
		if (redirectionUri.Scheme == "https")
		{
			result = true;
		}
		return result;
	}
}