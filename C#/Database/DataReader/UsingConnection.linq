<Query Kind="Program">
  <GACReference>Microsoft.SqlServer.SqlClrProvider, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
</Query>

static void RetrieveMultipleResults(SqlConnection connection)
{
    using (connection)
    {
        SqlCommand command = new SqlCommand(
          "SELECT SalesReasonKey, SalesReasonName FROM dbo.DimSalesReason;" +
          "SELECT GeographyKey,StateProvinceName FROM dbo.DimGeography",
          connection);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.HasRows)
        {
            Console.WriteLine("\t{0}\t{1}", reader.GetName(0),
                reader.GetName(1));

            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{1}", reader.GetInt32(0),
                    reader.GetString(1));
            }
            reader.NextResult();
        }
    }
	
	
}
static void Main(string[] args)
      {
         int a;
         int b;
           Console.WriteLine("A equals 3:");
         a = Convert.ToInt32(3);

         Console.WriteLine("B equals 5:");
         b = Convert.ToInt32(5);
		 
		 string myConnectionString=ConnString(); 
		 Console.WriteLine(myConnectionString) ;
		 
		 SqlConnection conn= new SqlConnection(myConnectionString);
		 RetrieveMultipleResults(conn);
		 	 	  

          }//END   Main

 public static string ConnString()/// removing static keyword will break http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
      { 
         string result = "Persist Security Info=False;Integrated Security=true; Initial Catalog=AdventureWorksDW2008R2;Server=SAMMYPRO";
         return result;
      }//END   Add



