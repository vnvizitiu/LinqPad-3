<Query Kind="Program" />

class Program //https://msdn.microsoft.com/en-us/library/bh8kx08z.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
{
   static void Main()
{
	using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection("Provider=MSDataShape;Data Provider=SQLOLEDB;" +
  "Data Source=(local);Integrated Security=SSPI;Initial Catalog=northwind"))
{
System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("SHAPE {SELECT CustomerID, CompanyName FROM Customers} " +
  "APPEND ({SELECT CustomerID, OrderID FROM Orders} AS Orders " +
  "RELATE CustomerID TO CustomerID)", connection);

DataSet customers = new DataSet();
adapter.Fill(customers, "Customers");
//customers.Dump();


foreach (DataTable table in customers.Tables)
{
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn column in table.Columns)
        {
            object item = row[column];
            // read column and item
			Console.WriteLine("Items: " + row[column]);
        }
    }
}
}

// Define other methods and classes here
}

}





