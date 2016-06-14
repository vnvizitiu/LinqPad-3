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
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

///https://msdn.microsoft.com/en-us/library/office/dn567668.aspx
//https://msdn.microsoft.com/en-us/library/office/dn535506(v=exchg.150).aspx
//////////////////////////////////////// MUST USE NORMAL ACCOUNT========DON'T RUN UNDER THE CREDENTIALS OF ADM ACCOUNT
  class Program
  {
       static void Main(string[] args)
       {



              ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
              service.UseDefaultCredentials = true;
              //     service.AutodiscoverUrl("username@domain.tld");



              service.TraceEnabled = true;
              service.TraceFlags = TraceFlags.All;

              service.AutodiscoverUrl("samtran@colonialfirststate.com.au");

       //     EmailMessage email = new EmailMessage(service);

              //            email.ToRecipients.Add("samtran@colonialfirststate.com.au");
              //            email.CcRecipients.Add("sammy1188@hotmail.com");
              //
              //            email.Subject = "HelloWorld_Marry had a little lamb======no passwords";
              //            email.Body = new MessageBody("This is the first email I've sent by using the EWS Managed API-save and send");
              //     email.SendAndSaveCopy();
              //            //email.Send();
              // Create an email message and provide it with connection 
              // configuration information by using an ExchangeService 
              // object named service.
              EmailMessage message = new EmailMessage(service);

              // Set properties on the email message.
              message.Subject = "Company Soccer Team";
              message.Body = "Are you interested in joining?";
              message.ToRecipients.Add("samtran@colonialfirststate.com.au");

              // Save the email to the mailbox owner's Drafts folder.
              // This method call results in a CreateItem call to EWS.
              // The FolderId parameter contains the context for the 
              // mailbox owner’s Inbox folder. Any additional actions 
              // taken on this message will be performed in the mailbox 
              // owner’s mailbox. 
//            message.Save(new FolderId(WellKnownFolderName.SentItems, new Mailbox("samtran@colonialfirststate.com.au")));

              // Send the email and save the message in the mailbox owner's 
              // Sent Items folder.
              // This method call results in a SendItem call to EWS.
              try
              {      
                       message.Save(new FolderId(WellKnownFolderName.Drafts, new Mailbox("samtran@colonialfirststate.com.au")));
                     message.SendAndSaveCopy(new FolderId(WellKnownFolderName.SentItems, new Mailbox("samtran@colonialfirststate.com.au")));
              }
              catch (Exception ex)
              {
                     ex.Dump();
                     throw;
              }

              Console.WriteLine("An email with the subject '" + message.Subject + "' has been sent to '"
              + message.ToRecipients[0] + "' and saved in the Sent Items folder of the mailbox owner.");





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
                     Console.WriteLine("this is the subject:" + subject);
                     Console.WriteLine("this is the body....");
                     mailMessage.Dump();
              }

              Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
              //            view.Dump();

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
