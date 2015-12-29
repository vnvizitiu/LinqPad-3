<Query Kind="Program" />

//using System;

//using System.Collections.Generic;

//using System.Text;

//using Teradata.Client.Provider;

//https://developer.teradata.com/doc/connectivity/tdnetdp/15.00/webhelp/DevelopingNetDataProviderforTeradataApplications.html

//https://developer.teradata.com/doc/connectivity/tdnetdp/15.11/help/DevelopingNetDataProviderforTeradataApplications.html

void Main() //http://forums.teradata.com/forum/connectivity/net-connection-string-with-ldap

{
	using (TdConnection cn = new TdConnection())
	{
		TdConnectionStringBuilder conStrBuilder = new TdConnectionStringBuilder();
		// i got the server from the ldap odbc description of the connection
		conStrBuilder.DataSource = "Teradata.gdw.cba";
		conStrBuilder.Database = "00_Teradata_Prod";
     	conStrBuilder.UserId = "samtran";
		conStrBuilder.Password = "Raymond123";
		conStrBuilder.AuthenticationMechanism = "LDAP";
		Console.WriteLine("conn string was: " + conStrBuilder.ConnectionString);
		cn.ConnectionString = conStrBuilder.ConnectionString; cn.Open();
		TdCommand cmd = cn.CreateCommand();
		cmd.CommandText = @"SELECT Id, Name, NameI FROM DBC.ownerdb ";
		TdDataReader reader = cmd.ExecuteReader();

		Console.WriteLine("{0} records affected.", reader.RecordsAffected);
		int currentRow = 1;
		while (reader.Read())
		{
			for (int columnIndex = 0; columnIndex < reader.FieldCount; columnIndex++)
			{
				// this is pretty cool.  Does every field with it's name.
				Console.WriteLine("Row [{0,4}] [{1,20}] = {2}",
							  currentRow, reader.GetName(columnIndex),
							  reader.GetValue(columnIndex));
			}
			Console.WriteLine();
			currentRow++;
		}
	}
}

