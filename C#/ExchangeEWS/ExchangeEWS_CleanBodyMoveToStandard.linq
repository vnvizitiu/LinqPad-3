<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
</Query>

///https://msdn.microsoft.com/en-us/library/office/dn600291(v=exchg.150).aspx
///https://msdn.microsoft.com/en-us/library/office/dn567668.aspx
//http://stackoverflow.com/questions/11243911/ews-body-plain-text
//https://msdn.microsoft.com/en-us/library/office/dn535506(v=exchg.150).aspx
/////shared
	//http://stackoverflow.com/questions/9259565/how-to-access-group-folders-shared-folders-from-ews-exchangeservice-in-c-sha
	//http://stackoverflow.com/questions/35480611/c-sharp-ews-managed-api-how-to-access-shared-mailboxes-but-not-my-own-inbox
	//http://stackoverflow.com/questions/32973691/how-can-i-use-exchangeservice-to-access-a-shared-mailbox-outlook-2013
  class Program
  {
	static void Main(string[] args)
	{
		ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

		service.Credentials = new WebCredentials("samtran@cbainet.com", "Hotdog88");

		service.TraceEnabled = true;
		service.TraceFlags = TraceFlags.All;

		service.AutodiscoverUrl("samtran@colonialfirststate.com.au", RedirectionUrlValidationCallback);
 

		// Bind the Inbox folder to the service object.
		Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);

		// The search filter to get unread email.
		SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
		ItemView view = new ItemView(1);


		PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
		itempropertyset.RequestedBodyType = BodyType.Text;


		////////////////////////////////
		FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"samtran@colonialfirststate.com.au");
		ItemView itemView = new ItemView(1000);
		FindItemsResults<Item> findResults = service.FindItems(SharedMailbox, itemView);

		//FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
		Item item = findResults.FirstOrDefault();
		item.Load(itempropertyset);
		Console.WriteLine("Begin=============================================");
		Console.WriteLine("Email Subject is: " + item.Subject);
		Console.WriteLine("=============================================");
		Console.WriteLine("Email Content is: " +item.Body);
		Console.WriteLine(item.Id);

		///////////////////////////////


		item.Load(itempropertyset);
		Console.WriteLine(item.Body);



		Folder rootfolder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot);
		rootfolder.Load();

		//		foreach (Folder folder in rootfolder.FindFolders(new FolderView(100)))
		//		{
		//			// Finds the emails in a certain folder, in this case the Junk Email
		//			FindItemsResults<Item> findResults2 = service.FindItems(WellKnownFolderName.JunkEmail, new ItemView(10));
		//
		//			// Enter your destination folder name below this:
		//			if (folder.DisplayName == "resolved")
		//			{
		//				// Stores the Folder ID in a variable
		//				var fid = folder.Id;
		//				Console.WriteLine(fid);
		//				foreach (Item itemx in findResults2.Items)
		//				{
		//					// Load the email, move it to the specified folder
		//					item.Load();
		//					item.Move(fid);
		//				}
		//
		//			}
		//		}



		//move
		// As a best practice, limit the properties returned by the Bind method to only those that are required.
		PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.Subject, EmailMessageSchema.ParentFolderId);

		// Bind to the existing item by using the ItemId.
		// This method call results in a GetItem call to EWS.
		EmailMessage beforeMessage = EmailMessage.Bind(service, item.Id, propSet);

		// Move the specified mail to the JunkEmail folder and store the returned item.
		Item itemx = beforeMessage.Move(WellKnownFolderName.Drafts);
		

		// Check that the item was moved by binding to the moved email message 
		// and retrieving the new ParentFolderId.
		// This method call results in a GetItem call to EWS.
		//EmailMessage movedMessage = EmailMessage.Bind(service, item.Id, propSet);

		Console.WriteLine("An email message with the subject '" + beforeMessage.Subject + "' has been moved from the '" + beforeMessage.ParentFolderId + "' folder to the '");/// + movedMessage.ParentFolderId + "' folder.");



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