<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
</Query>

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
		FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"systems.actuarial@cba.com.au");
		
		string folderid=GetSub(service);
		Console.WriteLine(folderid);
		
		
		
		
		ItemView itemView = new ItemView(1000);
		FindItemsResults<Item> findResults = service.FindItems(folderid, sf, itemView);

		//FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
		Item item = findResults.FirstOrDefault();
		
		if (item !=null)
		{
			item.Load(itempropertyset);
		}
 
		Console.WriteLine("Begin=============================================");
		Console.WriteLine("Email Subject is: " + item.Subject);
		Console.WriteLine("=============================================");
		Console.WriteLine("Email Content is: " +item.Body);
		

		///////////////////////////////







 
		item.Load(itempropertyset);
		Console.WriteLine(item.Body);

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

	static string GetSub(ExchangeService es)
	{

		FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"systems.actuarial@cba.com.au");

		// Create a view with a page size of 10.
		FolderView view = new FolderView(50);

		// Identify the properties to return in the results set.
		view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
		view.PropertySet.Add(FolderSchema.DisplayName);

		// Return only folders that contain items.
		SearchFilter searchFilter = new SearchFilter.IsGreaterThan(FolderSchema.TotalCount, 0);

		// Unlike FindItem searches, folder searches can be deep traversals.
		view.Traversal = FolderTraversal.Deep;

		// Send the request to search the mailbox and get the results.
		//FindFoldersResults findFolderResults = es.FindFolders(SharedMailbox, searchFilter, view);


		FindFoldersResults findResults = es.FindFolders(
  		 SharedMailbox,
  		 new FolderView(int.MaxValue));

		foreach (Folder folder in findResults.Folders)
		{
			Console.WriteLine(folder.DisplayName + " ID: " + folder.Id);
			if (folder.DisplayName == "Jira_In")
			{
				return folder.Id.ToString();
			}
		
		}
		return null;
	}
	}