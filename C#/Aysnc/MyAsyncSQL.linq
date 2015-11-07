<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//https://msdn.microsoft.com/en-us/library/hh211418(v=vs.110).aspx
//http://stackoverflow.com/questions/12595119/return-datatable-using-async-net-4-0
//https://msdn.microsoft.com/en-us/library/hh211418(v=vs.110).aspx 

 ///==========MOST LIKELY WRONG============
 
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 
    {
        
        static void Main()
        {
            Console.WriteLine("The of the Main method: {0}. \r\n",
                Thread.CurrentThread.ManagedThreadId);

            //Wait on the user to begin the reading of the file.
          //  Console.ReadLine();

            // Create task, start it, and wait for it to finish.
            Task task = new Task(ProcessFileAsync);
            task.Start();
            Console.WriteLine("hello");
            task.Wait();

            //Wait for a return before exiting.
            Console.ReadLine();
        }

        static async void ProcessFileAsync()
        {
            // Write out the id of the thread of the task that will call the async method to read the file.
            Console.WriteLine("The thread id of the ProcessFileAsync method: {0}. \r\n",
               Thread.CurrentThread.ManagedThreadId);

            // Start the HandleFile method.
            string connString = @"server=DESKTOP-E80R7DQ\SQL_MAIN;database=AdventureWorks;Integrated Security=true";
            Task<DataSet> task = GetDataset(connString);

            // Wait for the task to finish reading the file.
             DataSet results = await task;


            var myTables = results.Tables["SamsResultTable"].AsEnumerable().ToList();

            foreach (var  item in myTables)
            {
                Console.WriteLine(item);

            }
            // Perform some other work.
            Console.WriteLine("Do some other work. \r\n");

            Console.WriteLine("Proceed with waiting on the read to complete. \r\n");
           
             
          

        }

        static async Task<DataSet> GetDataset(string connection)
		{
			// Write out the id of the thread that is performing the read.
			Console.WriteLine("The thread id of the ReadFileAsync method: {0}. \r\n",
			   Thread.CurrentThread.ManagedThreadId);

			Console.WriteLine("Begin Reading file asynchronously. \r\n");

			// Read the specified file.


			SqlConnection conn = new SqlConnection(connection);

			// Query
			string sql = @"BEGIN WAITFOR DELAY '00:00:05'; EXECUTE sp_helpdb; END;";
			// Create Dataset
			DataSet ds = new DataSet();

			try
			{
				// Open connection
				await conn.OpenAsync();
				//await awConnection.OpenAsync();


				// Create Data Adapter
				SqlDataAdapter da = new SqlDataAdapter(sql, conn);



				// Fill Dataset
				da.Fill(ds, "SamsResultTable");

				return ds;



			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + ex.StackTrace);
				return null;
			}
			finally
			{
				//connection close
				conn.Close();
				Console.WriteLine("Done Reading File asynchronously. \r\n");

			}




		}

		 
	}

 
