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
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit the return key to shut down this app");
            Console.WriteLine("and force the GC to invoke Finalize()");
            Console.WriteLine("for finalizable objects created in this AppDomain.");
            Console.ReadLine();
            MyResourceWrapper rw = new MyResourceWrapper();
        }
    }



    // Override System.Object.Finalize() via finalizer syntax.
    class MyResourceWrapper
    {
        ~MyResourceWrapper()
        {
            // Clean up unmanaged resources here.

            // Beep when destroyed (testing purposes only!)
            Console.Beep();
        }
    }
