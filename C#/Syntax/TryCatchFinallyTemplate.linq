<Query Kind="Program" />

class Program //http://www.dotnetperls.com/sqlconnection
{
	static void Main() {
		string connectionString = "Persist Security Info=False;Integrated Security=true; Initial Catalog=AdventureWorksDW2008R2x;Server=SAMMYPRO";
		//
		// In a using statement, acquire the SqlConnection as a resource.
		//
		try {
			Console.WriteLine("trying");
			Console.WriteLine(connectionString);
			 
			} 
		catch (Exception x) 
			{
			//WriteLine (x.Message.ToString);
			Console.WriteLine("Error was caught: " + x.Message);
			}
		finally
			{
			Console.WriteLine("this will run regardless");
			}

	}
}