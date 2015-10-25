<Query Kind="Program" />

 //http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
   class Program
   {
      static void Main(string[] args)
      {
         int a;
         int b;
         int c;

         Console.WriteLine("A equals 3:");
         a = Convert.ToInt32(3);

         Console.WriteLine("B equals 5:");
         b = Convert.ToInt32(5);

         //why can't I not use it this way?
         c = Add(a, b);
         Console.WriteLine("a + b = {0}", c);
      }//END   Main

      public static int Add(int x, int y)/// removing static keyword will break http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
      { 
         int result = x + y;
         return result;
      }//END   Add
   }//END      Program
   
   
//   
//    //http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
//   class Program
//   {
//      static void Main(string[] args)
//      {
//         int a;
//         int b;
//         int c;
//
//         Console.WriteLine("A equals 3:");
//         a = Convert.ToInt32(3);
//
//         Console.WriteLine("B equals 5:");
//         b = Convert.ToInt32(5);
//
//         Program prog=new Program();
//		 prog.Add(a,b);
//		 Console.WriteLine(prog);
//		 
//        
//         Console.WriteLine("a + b = {0}", 6);
//      }//END   Main
//
//      public   int Add(int x, int y)/// removing static keyword will break http://stackoverflow.com/questions/10175357/c-sharp-creating-and-using-functions
//      { 
//         int result = x + y;
//         return result;
//      }//END   Add
//   }//END      Program
// 
// 