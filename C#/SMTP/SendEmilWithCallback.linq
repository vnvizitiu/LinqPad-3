<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>System.Net.Mime</Namespace>
  <Namespace>System.Threading</Namespace>
</Query>

//https://msdn.microsoft.com/en-au/library/system.net.mail.smtpclient(v=vs.110).aspx
    public class SimpleAsynchronousExample
{
	static bool mailSent = false;
	private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
	{
		// Get the unique identifier for this asynchronous operation.
		String token = (string)e.UserState;

		if (e.Cancelled)
		{
			Console.WriteLine("[{0}] Send canceled.", token);
		}
		if (e.Error != null)
		{
			Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
		}
		else
		{
			Console.WriteLine("Message sent.");
		}
		mailSent = true;
	}
	public static void Main(string[] args)
	{
		// Command line argument must the the SMTP host.
		SmtpClient client = new SmtpClient("mailrelay.cba.com.au");
		// Specify the e-mail sender.
		// Create a mailing address that includes a UTF8 character
		// in the display name.
		MailAddress from = new MailAddress("samtran@colonialfirststate.com.au",
		   "Jane " + (char)0xD8 + " Clayton",
		System.Text.Encoding.UTF8);
		
	//	client.EnableSsl=false;
		client.Port=25;
		
		// Set destinations for the e-mail message.
		MailAddress to = new MailAddress("samtran@colonialfirststate.com.au");
		// Specify the message content.
		MailMessage message = new MailMessage(from, to);
		message.Body = "This is a test e-mail message sent by an application. ";
		// Include some non-ASCII characters in body and subject.
		string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
		message.Body += Environment.NewLine + someArrows;
		message.BodyEncoding = System.Text.Encoding.UTF8;
		message.Subject = "test message 1" + someArrows;
		message.SubjectEncoding = System.Text.Encoding.UTF8;
		// Set the method that is called back when the send operation ends.
		client.SendCompleted += new
		SendCompletedEventHandler(SendCompletedCallback);
		// The userState can be any object that allows your callback 
		// method to identify this send operation.
		// For this example, the userToken is a string constant.
		string userState = "test message1";
		client.SendAsync(message, userState);
		Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
		string answer = "test";
		// If the user canceled the send, and mail hasn't been sent yet,
		// then cancel the pending operation.
		if (answer.StartsWith("c") && mailSent == false)
		{
			client.SendAsyncCancel();
		}
		// Clean up.
		message.Dispose();
		Console.WriteLine("Goodbye.");
	}
}
