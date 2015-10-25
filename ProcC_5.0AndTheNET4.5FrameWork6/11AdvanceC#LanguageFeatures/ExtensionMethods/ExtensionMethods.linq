<Query Kind="Program">
  <Namespace>MyExtensionMethods</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Extension Methods *****\n");

            // The int has assumed a new identity!
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            // So has the DataSet!
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // And the SoundPlayer!
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            // Use new integer functionality.
            Console.WriteLine("Value of myInt: {0}", myInt);
            Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());

            Console.ReadLine();
        }

    }



    static class MyExtensions
    {
        // This method allows any object to display the assembly
        // it is defined in.
        public static void DisplayDefiningAssembly( this object obj )
        {
            Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name,
              Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // This method allows any integer to reverse its digits.
        // For example, 56 would return 65.
        public static int ReverseDigits( this int i )
        {
            // Translate int into a string, and then
            // get all the characters.
            char[] digits = i.ToString().ToCharArray();

            // Now reverse items in the array.
            Array.Reverse(digits);

            // Put back into string.
            string newDigits = new string(digits);

            // Finally, return the modified string back as an int.
            return int.Parse(newDigits);
        }
    }
