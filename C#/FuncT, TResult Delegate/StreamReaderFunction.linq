<Query Kind="Program" />

void Main()
{
	try
	{
		string userLAn = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
		Func<string, string> PersonRole = (i) =>
			{
				string[] sData = null;
				string myfile=@"C:\Users\samtran\OneDrive\Documents\LinqPad_Queries\InputOutput_Files\Lamda.txt";
				using (StreamReader sr = new StreamReader(myfile))
				{
					while (!sr.EndOfStream)
					{
						sData = sr.ReadLine().Split(',');
						if (userLAn.ToLower() == sData[0].Trim().ToLower())
						{
							sData[1].Trim().ToLower();

							//publicRole = sData[1].Trim().ToLower();
							return sData[1].Trim().ToLower();
						}
					}
				}//
					return null;
			};

		Person user = new Person { LAN = System.Security.Principal.WindowsIdentity.GetCurrent().Name, Role = PersonRole(userLAn) };

	 
		user.Dump();

	}
	catch (Exception ex)
	{
		System.Diagnostics.Debug.WriteLine("User not found"); 
		System.Diagnostics.Debug.WriteLine(ex);
	}
}

// Define other methods and classes here

class Person
{
	public string LAN { get; set; }
	public string Role { get; set; }
	public string ToLowerName => new string(LAN.ToLower().ToArray());
}