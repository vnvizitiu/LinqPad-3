<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.DirectoryServices.ActiveDirectory</Namespace>
  <Namespace>System.DirectoryServices</Namespace>
</Query>

static void Main(string[] args) //http://www.tek-tips.com/viewthread.cfm?qid=1685932
 {
 var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
 int x = 0;
 Console.Write("Enter an email address: ");
 string email ="samtran@colonialfirststate.com.au";

 foreach (Domain d in allDomains)
 {

 var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + d.Name));
 searcher.Filter = "(&(ObjectClass=user)(mail=" + email + "))";
 SearchResult result = searcher.FindOne();
 ResultPropertyCollection myResult;

 //If found in Active Directory
 if (result != null)
 {
 myResult = result.Properties;
 x++;
 string ADName = result.Properties["name"][0].ToString();
 string firstname=result.Properties["displayname"][0].ToString(); //dump myresults
// string[] splitADName = ADName.Split(',');
// string firstName = splitADName[0];
// string lastName = splitADName[0];
// Console.WriteLine("Found " + firstName + " " + lastName + " is on domain " + d.Name);
 }
 }
 if (x == 0)
 {
 email = "";
 Console.WriteLine("Not Here");
	}
}