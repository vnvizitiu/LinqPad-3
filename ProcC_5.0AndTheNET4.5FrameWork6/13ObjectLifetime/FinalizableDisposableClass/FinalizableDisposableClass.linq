<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****");

            // Call Dispose() manually, this will not call the finalizer.
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            // Don't call Dispose(), this will trigger the finalizer
            // and cause a beep.
            MyResourceWrapper rw2 = new MyResourceWrapper();
        }
    }



    class MyResourceWrapper : IDisposable
    {
        // Used to determine if Dispose()
        // has already been called.
        private bool disposed = false;

        public void Dispose()
        {
            // Call our helper method.
            // Specifying "true" signifies that
            // the object user triggered the cleanup.
            CleanUp(true);

            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp( bool disposing )
        {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                // If disposing equals true, dispose all
                // managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Clean up unmanaged resources here.
            }
            disposed = true;
        }

        ~MyResourceWrapper()
        {
            Console.Beep();
            // Call our helper method.
            // Specifying "false" signifies that
            // the GC triggered the cleanup.
            CleanUp(false);
        }
    }
