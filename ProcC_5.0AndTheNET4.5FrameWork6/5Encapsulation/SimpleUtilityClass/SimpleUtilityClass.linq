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
            Console.WriteLine("***** Fun with Static Classes *****\n");

            // This is just fine.
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();

            // Compiler error! Can't create static classes!
            // TimeUtilClass u = new TimeUtilClass();

            Console.ReadLine();
        }
    }


    // Static classes can only
    // contain static members!
    static class TimeUtilClass
    {
        public static void PrintTime()
        { Console.WriteLine(DateTime.Now.ToShortTimeString()); }

        public static void PrintDate()
        { Console.WriteLine(DateTime.Today.ToShortDateString()); }
    }
