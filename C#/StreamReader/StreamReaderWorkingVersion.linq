<Query Kind="Program" />

void Main()
{
	var _users = new List<GUIUser>();
	_users = GetUser();

 	_users.Dump();
}

private static List<GUIUser> GetUser()
{
	var _users = new List<GUIUser>();
	try
	{
		using (StreamReader sr = new StreamReader(@"X:\Common\SystemsAccounting\Production\Aegon\Roles.txt"))
		{
			while (!sr.EndOfStream)
			{
				var sData = sr.ReadLine()?.Split(',');
					_users.Add(new GUIUser() { Name = sData[0], LAN = sData[1] });
				//var user = new GUIUser() { LAN = "sam"};
				 
			}
			return _users;
		}
	}
	catch (Exception e)
	{
		Debug.WriteLine(e.Message);
	 
		return _users;

	}
}
internal class GUIUser
{
	public string Name { get; set; }
	public string LAN { get; set; }
}
