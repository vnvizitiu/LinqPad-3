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

void Main()
{
	var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
	int x = 0;
//http://www.tek-tips.com/viewthread.cfm?qid=1685932
	bool breaking = false;
	foreach (Domain d in allDomains)
	{
		if (allDomains.ElementAt(0).Name!="x")
		{
			Console.WriteLine(allDomains.ElementAt(0).Name);
		}
		string email = "samtran@colonialfirststate.com.au", displayName = "", samaccountname = "samtran";
		var searcher = new DirectorySearcher(new DirectoryEntry("LDAP://" + d.Name));
		searcher.Filter = "(ObjectClass=user)";
		SearchResultCollection result = searcher.FindAll();

		foreach (SearchResult sr in result)
		{
			if (sr.Properties["mail"].Count > 0)
			{
				if (sr.Properties["mail"][0].ToString().ToLower().Equals("samtran@colonialfirststate.com.au"))
				{
					samaccountname = sr.Properties["samaccountname"][0].ToString();
					email = sr.Properties["mail"][0].ToString();
					displayName = sr.Properties["displayname"][0].ToString();

					Console.WriteLine("Found it! " + email + " is on domain " + d.ToString());
					Console.WriteLine("Display Name : " + displayName);
					Console.WriteLine("Account Name: " + samaccountname);

					breaking = true;
					break;
				}
			}
		}
		searcher = null;
		if (breaking) { break; }
	}
}
