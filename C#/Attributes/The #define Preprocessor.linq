<Query Kind="Program" />

#define PI  
//try removing PI and see
class Program
   {
      static void Main(string[] args)
      {
#if (PI)
            Console.WriteLine("PI is defined");
#else
		Console.WriteLine("PI is not defined");
#endif
	 
	}
}
//http://www.tutorialspoint.com/csharp/csharp_preprocessor_directives.htm