<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Namespace>System.DirectoryServices</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.DirectoryServices.ActiveDirectory</Namespace>
  <Namespace>System.DirectoryServices.Protocols</Namespace>
</Query>

void Main()
{//http://stackoverflow.com/questions/5162897/how-can-i-get-a-list-of-users-from-active-directory
	using (var context = new PrincipalContext(ContextType.Domain, "au"))
{
    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
    {
        foreach (var result in searcher.FindAll())
        {
            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
            Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
            Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
            Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
            Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
            Console.WriteLine();
        }
    }
}
Console.ReadLine();
}

// Define other methods and classes here



void Main2()
{
	using (var context = new PrincipalContext(ContextType.Domain, "au"))
{
    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
    {
        foreach (var result in searcher.FindAll().Where(s => s.SamAccountName=="Samtran"))
        {
            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
            Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
            Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
            Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
            Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
            Console.WriteLine();
			de.Dump();
			break;
        }
    }
}

}

//displays this
//First Name: Vy
//Last Name : Tran
//SAM account name   : Samtran
//User principal name: samtran@cbainet.com