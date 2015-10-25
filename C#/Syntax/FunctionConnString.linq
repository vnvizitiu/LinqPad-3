<Query Kind="Program" />

void Main()
{
	//\\Console.Writeline(MyConnectString);
//	   SqlConnection conn = new SqlConnection();
//conn.ConnectionString =
//"Data Source=ServerName;" +
//"Initial Catalog=DataBaseName;" +
//"Integrated Security=SSPI;";
//conn.Open();

	Console.WriteLine("Sam was here");
	string conn=MyConnectString();
	Console.WriteLine(conn);
	

}
	
public string MyConnectString()
{
	//Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & TextBox1.text
 
	return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" ;
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

	
	
	
	
	
 

// Define other methods and classes here
