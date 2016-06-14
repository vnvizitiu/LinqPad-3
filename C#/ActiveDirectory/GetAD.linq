<Query Kind="Program">
  <Namespace>System.Security.Principal</Namespace>
</Query>

//http://stackoverflow.com/questions/5309988/how-to-get-the-groups-of-a-user-in-active-directory-c-asp-net
public List<string> GetGroups(string userName)
{
	List<string> result = new List<string>();
	WindowsIdentity wi = new WindowsIdentity(userName);

	foreach (IdentityReference group in wi.Groups)
	{
		try
		{
			result.Add(group.Translate(typeof(NTAccount)).ToString());
			Console.WriteLine(group.Value);
			string sid = "S-1-5-21-1229272821-1123561945-839522115";
			string account = new System.Security.Principal.SecurityIdentifier(sid).Translate(typeof(System.Security.Principal.NTAccount)).ToString();
			Console.WriteLine(account);

			{
				string user = "ngot1@cbainet.com";
				List<string> details = GetGroups(user);

			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}
	result.Sort();
	return result;
}
void Main()
{
	string user = "ngot1@cbainet.com";
	List<string> details= GetGroups(user);
    
}