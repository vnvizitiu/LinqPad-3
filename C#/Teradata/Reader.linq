<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>Teradata.Client.Provider</Namespace>
</Query>

//using System;
//using System.Collections.Generic;
//using System.Text;
//using Teradata.Client.Provider;
//https://developer.teradata.com/doc/connectivity/tdnetdp/15.00/webhelp/DevelopingNetDataProviderforTeradataApplications.html
class HelloWorld
{
	static void Main(string[] args)
	{
		using (TdConnection cn = new TdConnection("Data Source = x;User ID = y;Password = z;"))
		{
			cn.Open();
			TdCommand cmd = cn.CreateCommand();
			cmd.CommandText = "SELECT DATE";
			using (TdDataReader reader = cmd.ExecuteReader())
			{
				reader.Read();
				DateTime date = reader.GetDate(0);
				Console.WriteLine("Teradata Database DATE is {0}", date);
			}
		}
	}
}
