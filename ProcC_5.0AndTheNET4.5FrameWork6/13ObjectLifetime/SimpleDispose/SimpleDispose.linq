<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Dispose *****\n");

            // Use a comma-delimited list to declare multiple objects to dispose.
            using (MyResourceWrapper rw = new MyResourceWrapper(),
                                    rw2 = new MyResourceWrapper())
            {
                // Use rw and rw2 objects.
            }
        }

        // Assume you have imported
        // the System.IO namespace...
        static void DisposeFileStream()
        {
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);

            // Confusing, to say the least!
            // These method calls do the same thing!
            fs.Close();
            fs.Dispose();
        }
    }



    // Implementing IDisposable.
    class MyResourceWrapper : IDisposable
    {
        // The object user should call this method
        // when they finish with the object.
        public void Dispose()
        {
            // Clean up unmanaged resources...

            // Dispose other contained disposable objects...

            // Just for a test.
            Console.WriteLine("***** In Dispose! *****");
        }
    }
