<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

void Main()
{
	Program p=new Program();
	String[] AD = new String[] { "SGG-WM_PAPAFilesDev", "au" };
	p.Main(AD);	
}
public class Program
{
	public static string groupName = string.Empty;
	public static string domainName = string.Empty;

	public  void Main(string[] args)
	{
		groupName = args[0];
		domainName = args[1];
		PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
		GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, groupName);
		List<ADGroups> _AD = new List<ADGroups>();
		
		if (grp != null)
		{				
		foreach (Principal p in grp.GetMembers(true))
			{
				Console.WriteLine(p.Name); //You can add more attributes, samaccountname, UPN, DN, object type, etc... 
				ADGroups AD = new ADGroups
				{
					Login = p.Context.ConnectedServer,
					Description = p.Description,
					DisplayName = p.DisplayName
											,
					SamAccountName = p.SamAccountName,
					UserPrincipalName = p.UserPrincipalName
											,
					DistinguishedName = p.DistinguishedName,
			 
					 
					Name = p.Name};
					_AD.Add(AD);
					p.Dump();
				}
				
			grp.Dispose();
     		ctx.Dispose();
			//_AD.Dump();
		}
	 	
		
		else
		{
			Console.WriteLine("\nWe did not find that group in that domain, perhaps the group resides in a different domain?");
		}
		
		ctx.Dispose();
         
	}

}

public class ADGroups
{
	public string Login { get; set; }
	public string Context { get; set; }
	public string Description { get; set; }
	public string DisplayName { get; set; }
	public string SamAccountName { get; set; }
	public string UserPrincipalName { get; set; }
	public string DistinguishedName { get; set; }
	public string Name { get; set; }
	public bool Enabled { get; set; }
	public string LastLogon { get; set; }
	public string HomeDir { get; set; }
	public string HomePath { get; set; }
	public DateTime LastPasswordReset { get; set; }
	public DateTime LastBadPasswordAttempt { get; set; }
	public string GivenName { get; set; }
	public string MiddleName { get; set; }
	public string SurName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string EmpID { get; set; }

}