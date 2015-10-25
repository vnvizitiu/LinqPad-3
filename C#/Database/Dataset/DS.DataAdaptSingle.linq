<Query Kind="Program" />

void Main()
{
	 // Connection string
            string connString = @" server=.\sql2012;database=AdventureWorks;Integrated Security=true";
            
            // Query
            string sql = @"select Name,ProductNumber
                           from Production.Product
                           where SafetyStockLevel > 600";

            // Create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // Open connection
                conn.Open();

                // Create Data Adapter
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // Create Dataset
                DataSet ds = new DataSet();

                // Fill Dataset
                da.Fill(ds, "Production.Product");

               
                // Display data
                ds.Tables["Production.Product"].Dump();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                //connection close
                conn.Close();
            } 
}

// Define other methods and classes here
