<Query Kind="Program" />

void Main()//https://msdn.microsoft.com/en-us/library/0wwkb7kw(v=vs.110).aspx
{
	 string InsertValue="Krystal"; string conn=GetConnectionString(); 
	 int returnValue= AddProductCategory(InsertValue,conn);
	 Console.WriteLine(returnValue);
}


static public int AddProductCategory(string newName, string connString)
{
    Int32 newProdID = 0;
    string sql =
        "INSERT INTO Production.ProductCategory (Name) VALUES (@Name); "
        + "SELECT CAST(scope_identity() AS int)";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
        cmd.Parameters["@name"].Value = newName;
        try
        {
            conn.Open();
            newProdID = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
	Console.WriteLine(newProdID);
    return (int)newProdID;
}
// Define other methods and classes here

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,             
        // you can retrieve it from a configuration file.  

        // If you have not included "Asynchronous Processing=true" in the
        // connection string, the command is not able 
        // to execute asynchronously. 
        return "Data Source=WIN-90API3QKTDS;Integrated Security=SSPI;" +
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    } 
