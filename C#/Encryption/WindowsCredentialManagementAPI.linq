<Query Kind="Program">
  <NuGetReference>CredentialManagement</NuGetReference>
  <Namespace>CredentialManagement</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main() //http://stackoverflow.com/questions/32548714/how-to-store-and-retrieve-credentials-on-windows-using-c-sharp
{	//http://stackoverflow.com/questions/32548714/how-to-store-and-retrieve-credentials-on-windows-using-c-sharp
	var test = new PasswordRepository();
	//test.SavePassword("hell_yeah");
	string x = test.GetPassword();
	x.Dump();
}


public class PasswordRepository
{
	private const string MyCredentials = "Jira"; //need to check this against Credentials Manager
	private const string User = "samtran"; 
	public void SavePassword(string password)
	{
		using (var cred = new Credential())
		{
			cred.Password = password;
			cred.Username=User;
			cred.Target = MyCredentials;
			cred.Type = CredentialType.Generic;
			cred.PersistanceType = PersistanceType.LocalComputer;
			cred.Save();
		}
	}

	public string GetPassword()
	{
		using (var cred = new Credential())
		{
			cred.Target = MyCredentials;
			cred.Load();
			Console.WriteLine(cred.Username);
			Console.WriteLine(cred.Type + cred.Description);
			Console.WriteLine(cred.Password);
			return cred.Password;
		}
	}
}