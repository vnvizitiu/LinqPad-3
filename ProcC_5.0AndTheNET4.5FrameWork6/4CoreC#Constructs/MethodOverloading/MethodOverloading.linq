<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Method Overloading *****\n");

            // Calls int version of Add()
            Console.WriteLine(Add(10, 10));

            // Calls long version of Add()
            Console.WriteLine(Add(900000000000, 900000000000));

            // Calls double version of Add()
            Console.WriteLine(Add(4.3, 4.4));
            
            Console.ReadLine();
        }

        #region Overloaded Add() method
        // Overloaded Add() method.
        static int Add(int x, int y)
        { return x + y; }

        static double Add(double x, double y)
        { return x + y; }

        static long Add(long x, long y)
        { return x + y; }
        #endregion
    }
