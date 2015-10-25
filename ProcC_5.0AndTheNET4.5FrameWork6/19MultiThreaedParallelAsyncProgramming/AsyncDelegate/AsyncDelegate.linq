<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
</Query>


    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // This message will keep printing until
            // the Add() method is finished.
            while (!iftAR.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }

            // Now we know the Add() method is complete.
            int answer = b.EndInvoke(iftAR);

            Console.WriteLine("10 + 10 is {0}.", answer);
            //Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
    }
