<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.Auth.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft\Exchange\Web Services\2.0\Microsoft.Exchange.WebServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>C:\Download_Codes\API_ExampleWithNeeded_DLL\WebAPIClient\WebAPIClient\bin\Debug\System.Net.Http.Formatting.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>Microsoft.Exchange.WebServices.Data</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
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

		service.UseDefaultCredentials = true;
	//	service.TraceEnabled = true;
	//	service.TraceFlags = TraceFlags.All;

		service.AutodiscoverUrl("samtran@colonialfirststate.com.au", RedirectionUrlValidationCallback);
 

		// Bind the Inbox folder to the service object.
		Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);

		// The search filter to get unread email.
		SearchFilter.SearchFilterCollection sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
		sf.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
	//	sf.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "Jira")));
		sf.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject,"jira", ContainmentMode.Substring, ComparisonMode.IgnoreCase));


	//	ItemView view = new ItemView(1);


//		PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
//		itempropertyset.RequestedBodyType = BodyType.Text;


		////////////////////////////////
	//	FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"systems.actuarial@cba.com.au");
		FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"samtran@colonialfirststate.com.au");
			
		string fromfoldername="Jira_In";
		string fromfolderid=GetSub(service,fromfoldername);
		Console.WriteLine(fromfolderid);

		string toFoldername = "Jira_Out";
		string  tofolderid = GetSub(service, toFoldername);
		Console.WriteLine(tofolderid);


		ItemView itemView = new ItemView(1000);
	//	FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, itemView);
		
		FindItemsResults<Item> findResults = service.FindItems(fromfolderid, sf, itemView); //only if from sub folder
		 
		Console.WriteLine(findResults.Count());
		
		
		
		foreach (var element in findResults)
		{
			try
			{
				Console.WriteLine(element.Subject);
				//FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
				//Item item = findResults.FirstOrDefault();
				//	FindItemsResults<Item> allitems=service.FindItems(sf,view);
			 
				
				Console.WriteLine("Begin=============================================");
				Console.WriteLine("Email Subject is: " + element.Subject);
				Console.WriteLine("=============================================");

				PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
				itempropertyset.RequestedBodyType = BodyType.Text;
				element.Load(itempropertyset);
				Console.WriteLine("Email Content is: " + element.Body);
				
				
				//sender
				string senderEmail = ((EmailMessage) element).From.Name;
				Console.Write(senderEmail);
				
				//sender
				EmailMessage mes = (EmailMessage)element;
				var sender= mes.Sender.Name;
				Console.Write(sender);


				//	RaiseJira(element.Subject,element.Body);
				
				string postUrl = "https://jira.odp.cba/rest/api/latest/";


				//get attachment
				//SaveEmailAttachment(ExchangeService service, ItemId itemId)
				//SaveEmailAttachment(service,element.Id);
				List<FileInfo> myAttachment = GetAttachmentsFromEmail(service, element.Id);
				Console.WriteLine(myAttachment);
				
				 //PostFile(string restUrl,IEnumerable<FileInfo> filePaths)

				//move
				// As a best practice, limit the properties returned by the Bind method to only those that are required.
				PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.Subject, EmailMessageSchema.ParentFolderId);

				// Bind to the existing item by using the ItemId.
				// This method call results in a GetItem call to EWS.
				EmailMessage beforeMessage = EmailMessage.Bind(service, element.Id, propSet);

				// Move the specified mail to the JunkEmail folder and store the returned item.
				Item itemx = beforeMessage.Move(tofolderid);


			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString());
			}


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

	static string GetSub(ExchangeService es, string foldername)
	{

		//FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"systems.actuarial@cba.com.au");
		FolderId SharedMailbox = new FolderId(WellKnownFolderName.Inbox,"samtran@colonialfirststate.com.au");
		 

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
			if (folder.DisplayName == foldername)
			{
				if (folder.DisplayName=="Jira_In")
				{
					Console.WriteLine(folder.ParentFolderId.ToString());
					return folder.ParentFolderId.ToString();
				}
				return folder.Id.ToString();
			}
		
		}
		return null;
	}
	}

public static void RaiseJira(string subject, string body) //http://stackoverflow.com/questions/13974208/creating-jira-issue-via-rest-c-sharp-httpclient
{ //https://answers.atlassian.com/questions/79902/using-httpclient-c-to-create-a-jira-issue-via-rest-generates-bad-request-response
  // string data = @"{""fields"":{""project"":{""key"": ""TEST""},""summary"": ""REST EXAMPLE"",""description"": ""Creating an issue via REST API"",""issuetype"": {""name"": ""Bug""}}}";
  //	string path = @"C:\Download_Codes\JiraExample_Console\JiraExample\JSON_Results\RaiseIssue.json";
	Console.WriteLine("subject: " + subject + "     body: " + body);

	//string jData = File.ReadAllText(path);

	string jData = @"{""fields"":{""project"":{""key"": ""BIDA""},""summary"": ""Jira raised via REST API-alternative"",
                               ""description"": ""To test if raising JI?A via REST API is possible"",""issuetype"": {""name"": ""Improvement""}}}";
	JavaScriptSerializer json_serializer = new JavaScriptSerializer();
	Issue jsonIssue = json_serializer.Deserialize<Issue>(jData);
	//   (Issue)json_serializer.DeserializeObject(jData);
	//var jsonIssue= JsonConvert.DeserializeObject<T>(json);
	jsonIssue.fields.summary = subject;
	jsonIssue.fields.description = body;
	Console.WriteLine(jsonIssue.fields.summary);
	jsonIssue.Dump();

	// List<test> myDeserializedObjList = (List<test>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request["jsonString"], typeof(List<test>));
	//Issue myDeserializedObj = (Issue)JavaScriptConvert.DeserializeObject(Request["jsonString"], typeof(Test));


	string postUrl = "https://jira.odp.cba/rest/api/latest/";

	System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

	client.BaseAddress = new System.Uri(postUrl);
	#region private
	byte[] cred = UTF8Encoding.UTF8.GetBytes("samtran:Hotdog88");
	#endregion

	client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

	System.Net.Http.Formatting.MediaTypeFormatter jsonFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();

	//System.Net.Http.HttpContent content = new System.Net.Http.ObjectContent<string>(data, jsonFormatter);
	System.Net.Http.HttpContent content = new System.Net.Http.ObjectContent<Issue>(jsonIssue, jsonFormatter);
	// HttpContent content = new ObjectContent<string>(jData, jsonFormatter);
	jData.Dump();
	//HttpContent content = new ObjectContent<string>(data, jsonFormatter);
	System.Net.Http.HttpResponseMessage response = client.PostAsync("issue", content).Result;
	if (response.IsSuccessStatusCode)
	{
		string result = response.Content.ReadAsStringAsync().Result;
		Console.WriteLine(result);
	}
	else
	{

		Console.WriteLine(response.StatusCode.ToString());
	}
}



       

public class Issue
{
	public Fields fields { get; set; }
}

public class Fields
{
	public Project project { get; set; }
	public string summary { get; set; }
	public string description { get; set; }
	public Issuetype issuetype { get; set; }
}

public class Project
{
	public string key { get; set; }
}

public class Issuetype
{
	public string name { get; set; }
}


public static List<FileInfo> GetAttachmentsFromEmail(ExchangeService service, ItemId itemId) //https://msdn.microsoft.com/en-us/library/office/dn726695(v=exchg.150).aspx
{
    // Bind to an existing message item and retrieve the attachments collection.
    // This method results in an GetItem call to EWS.
    EmailMessage message = EmailMessage.Bind(service, itemId, new PropertySet(ItemSchema.Attachments));
	Console.WriteLine("IN GetAttachmentsFromEmail");
    // Iterate through the attachments collection and load each attachment.
	var AttList =new List<FileInfo>();

    foreach (Attachment attachment in message.Attachments)
    {
        if (attachment is FileAttachment)
        {
            FileAttachment fileAttachment = attachment as FileAttachment;

            // Load the attachment into a file.
            // This call results in a GetAttachment call to EWS.
            fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);
           
            Console.WriteLine("File attachment name: " + fileAttachment.Name);
			//AttList.Add(new FileInfo(@"C:\file.txt"));
			AttList.Add(new FileInfo("C:\\temp\\" + fileAttachment.Name));

        }
        else // Attachment is an item attachment.
        {
            ItemAttachment itemAttachment = attachment as ItemAttachment;

            // Load attachment into memory and write out the subject.
            // This does not save the file like it does with a file attachment.
            // This call results in a GetAttachment call to EWS.
            itemAttachment.Load();

            Console.WriteLine("Item attachment name: " + itemAttachment.Name);
			return null;
        }
		
		
    }
	return AttList;
}


public static void SaveEmailAttachment(ExchangeService service, ItemId itemId) //https://msdn.microsoft.com/en-us/library/office/dn726695(v=exchg.150).aspx#bk_saveitemattach
{
    // Bind to an existing message item and retrieve the attachments collection.
    // This method results in an GetItem call to EWS.
    EmailMessage message = EmailMessage.Bind(service, itemId, new PropertySet(ItemSchema.Attachments));
    Console.WriteLine("IN SaveEmailAttachment");
    foreach (Attachment attachment in message.Attachments)
    {
        if (attachment is ItemAttachment)
        {
            ItemAttachment itemAttachment = attachment as ItemAttachment;
            itemAttachment.Load(ItemSchema.MimeContent);
            string fileName = "C:\\Temp\\" + itemAttachment.Item.Subject + ".eml";

            // Write the bytes of the attachment into a file.
            File.WriteAllBytes(fileName, itemAttachment.Item.MimeContent.Content);

            Console.WriteLine("Email attachment name: "+ itemAttachment.Item.Subject + ".eml");
        }
		else{ Console.WriteLine("can't save attachment");}
		
    }
}


 private void PostFile(string restUrl,IEnumerable<FileInfo> filePaths)
        {
			
		//	string restUrl = String.Format("{0}rest/api/2/issue/{1}/attachments", Url);
		
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            String boundary = String.Format("----------{0:N}", Guid.NewGuid());
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            foreach (var filePath in filePaths)
            {
                var fs = new FileStream(filePath.FullName, FileMode.Open, FileAccess.Read);
                var data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();
                writer.WriteLine("--{0}", boundary);
                writer.WriteLine("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\"", filePath.Name);
                writer.WriteLine("Content-Type: application/octet-stream");
                writer.WriteLine();
                writer.Flush();
                stream.Write(data, 0, data.Length);
                writer.WriteLine();
            }
			
            writer.WriteLine("--" + boundary + "--");
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            request = WebRequest.Create(restUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Basic " + Utility.GetEncodedCredentials("samtran", "Sydney123"));
            request.Headers.Add("X-Atlassian-Token", "nocheck");
            request.ContentLength = stream.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                stream.WriteTo(requestStream);
                requestStream.Close();
            }
            using (response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    Console.WriteLine("The server returned '{0}'\n{1}", response.StatusCode, reader.ReadToEnd());
                }
            }
            request.Abort();
        }
		
		
  public void AddAttachments(string issueKey,IEnumerable<string> filePaths)
        {
       //     string restUrl = String.Format("{0}rest/api/2/issue/{1}/attachments", Url, issueKey);
            var filesToUpload = new List<FileInfo>();
            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File '{0}' doesn't exist", filePath);
                }
                var file = new FileInfo(filePath);
                filesToUpload.Add(file);
            }
            if (filesToUpload.Count <= 0)
            {
                Console.WriteLine("No file to Upload");
            }
            //PostFile(restUrl,filesToUpload);
        }


class Utility
    {
        public static string GetEncodedCredentials(string UserName, string Password)
        {
            string mergedCredentials = String.Format("{0}:{1}", UserName, Password);
            byte[] byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }