<Query Kind="Program" />

//using System;

//using System.Collections.Generic;

//using System.Text;

//using Teradata.Client.Provider;

//https://developer.teradata.com/doc/connectivity/tdnetdp/15.00/webhelp/DevelopingNetDataProviderforTeradataApplications.html

//https://developer.teradata.com/doc/connectivity/tdnetdp/15.11/help/DevelopingNetDataProviderforTeradataApplications.html

class HelloWorld
{
	static void Main(string[] args)
	{////http://forums.teradata.com/forum/connectivity/net-connection-string-with-ldap
		using (TdConnection cn = new TdConnection("Data Source = Teradata.gdw.cba ;User ID= samtran;Password = Raymond123; Authentication Mechanism=LDAP;"))
		{
			cn.Open();
			TdCommand cmd = cn.CreateCommand();
			cmd.CommandText = "SELECT  UserName, AccountName, UserOrProfile FROM DBC.AccountInfo";
			using (TdDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					// Print one row at a time
					Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
				}
			}
		}
	}
}
