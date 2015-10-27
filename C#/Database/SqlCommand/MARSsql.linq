<Query Kind="Program" />

void Main()
{//http://csharp.net-informations.com/data-providers/csharp-multiple-resultsets.htm
	string connetionString = null;
	SqlConnection sqlCnn;
	SqlCommand sqlCmd;
	string sql = null;

	connetionString = @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Initial Catalog=AdventureWorksDW2014;User ID=sa;Password=Fate1972";
	sql = "Select top 2 * from DimGeography; select top 2 * from DimPromotion; select top 2 * from DimOrganization";

	sqlCnn = new SqlConnection(connetionString);
	try
	{
		sqlCnn.Open();
		sqlCmd = new SqlCommand(sql, sqlCnn);
		SqlDataReader sqlReader = sqlCmd.ExecuteReader();
		while (sqlReader.Read())
		{
			Console.WriteLine("From first SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1));
		}

		sqlReader.NextResult();

		while (sqlReader.Read())
		{
			Console.WriteLine("From second SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1));
		}

		sqlReader.NextResult();

		while (sqlReader.Read())
		{
			Console.WriteLine("From third SQL - " + sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1));

		}

		sqlReader.Close();
		sqlCmd.Dispose();
		sqlCnn.Close();
	}
	catch (Exception ex)
	{
		Console.WriteLine("Can not open connection ! ");
	}
}

// Define other methods and classes here
