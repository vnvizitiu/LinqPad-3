<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Web.Services.Description</Namespace>
</Query>

///https://msdn.microsoft.com/en-us/library/office/dn567668.aspx
//http://stackoverflow.com/questions/11243911/ews-body-plain-text
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
	 FindFoldersResults findFolderResults = service.FindFolders(WellKnownFolderName.Root, searchFilter, view);
		//FindFoldersResults findFolderResults = cWellKnownFolderName.Inbox,searchFilter,view);
		
		foreach (Folder element in findFolderResults.Folders)
		{
			 Console.WriteLine(element.DisplayName);
		}
		
		
		
		// Process each item.
		foreach (Folder myFolder in findFolderResults.Folders)
		{
			if (myFolder is SearchFolder)
			{
				Console.WriteLine("Search folder: " + (myFolder as SearchFolder).DisplayName);
			}

			else if (myFolder is ContactsFolder)
			{
				Console.WriteLine("Contacts folder: " + (myFolder as ContactsFolder).DisplayName);
			}

			else if (myFolder is TasksFolder)
			{
				Console.WriteLine("Tasks folder: " + (myFolder as TasksFolder).DisplayName);
			}

			else if (myFolder is CalendarFolder)
			{
				Console.WriteLine("Calendar folder: " + (myFolder as CalendarFolder).DisplayName);
			}
			else
			{
				// Handle a generic folder.
				Console.WriteLine("Folder: " + myFolder.DisplayName);
			}
		}

		// Determine whether there are more folders to return.
		if (findFolderResults.MoreAvailable)
		{
			// Make recursive calls with offsets set for the FolderView to get the remaining folders in the result set.
			Console.WriteLine(findFolderResults.Count());

		}

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