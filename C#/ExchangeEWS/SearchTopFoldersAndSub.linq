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

//http://stackoverflow.com/questions/7590510/find-all-subfolders-of-the-inbox-folder-using-ews
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


		FindFoldersResults findResults = service.FindFolders(
  		 WellKnownFolderName.Inbox,
  		 new FolderView(int.MaxValue));

		foreach (Folder folder in findResults.Folders)
		{
			Console.WriteLine(folder.DisplayName + " ID: "+folder.Id);
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