<Query Kind="Program" />

class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
      
            #region Make some cars!
            // Make a Car called Chuck going 10 MPH.
            Car chuck = new Car();
            chuck.PrintState();
				
			//chuck.PrintStateTwo(); 'UserQuery.Car.PrintStateTwo()' is inaccessible due to its protection level /// can only be accessed within Car because PRIVATE
			//chuck.PrintStatic() //is inaccessible due to its protection level///STATIC method can only be accessed within class  
										///static   void PrintStatic()
										
			Car.PrintStaticPublic(); //this can be accessed this way, public method and no instance-NOT STATIC
			//static public void PrintStaticPublic()
			String[] foos = new String[] { "Foo1", "Foo2", "Foo3" };
			ProgramMath.MainEntryMethod(foos);
			
			 
	 
		
			
			

            // Make a Car called Mary going 0 MPH.
            Car mary = new Car("Mary");
            mary.PrintState();

            // Make a Car called Daisy going 75 MPH.
            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();

            Console.WriteLine();
			
			

            // Allocate and configure a Car object.
            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            // Speed up the car a few times and print out the
            // new state.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.WriteLine();
            #endregion
          

            
        }

        
    }


    class Car
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;
	 

	#region Constructors
	// A custom default constructor.
	public Car()
	{
		petName = "Chuck";
		currSpeed = 10;
		PrintStatic();/// only accessible within Car property and cannot be called from outside this (car) class
	}

	// Here, currSpeed will receive the
	// default value of an int (zero).
	public Car(string pn)
	{
		petName = pn;
		PrintStaticProperty(pn);
	}

	// Let caller set the full state of the Car.
	public Car(string pn, int cs)
	{
		petName = pn;
		currSpeed = cs;
	}
	#endregion

	// The functionality of the Car.
	public void PrintState() /////////////////////////////////////////////////////////////////////////////////////////////////////////public
	{
		Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
		Console.WriteLine("Printing: public void PrintState().. in Car...then calling another");
		PrintStateTwo();
	}

	void PrintStateTwo()/////////////////////////////////////////////////////////////////////////////////////////////////////////private
	{
		Console.WriteLine("Printing: Void PrintStateTwo().. in Car");
	}

	static void PrintStatic() ///////////////////////////////////////////////////////////////////////////////////////////////////static void
	{
		Console.WriteLine("Printing: static void PrintStatic()...in Car");
	}

	static public void PrintStaticPublic() ///////////////////////////////////////////////////////////////////////////////////////////////////static void
	{
		Console.WriteLine("Printing: static public void PrintStaticPublic(), note no instance ....");
	}


	static void PrintStaticProperty(string var)///////////////////////////////////////////////////////////////////////////static void with paramter
	{
		Console.WriteLine("Printing:static void PrintStaticProperty(string var)..."+ var);
	}

	public void SpeedUp(int delta)
	{
		currSpeed += delta;
	}
}

class MyMathClass
{
	// public const double PI = 3.14;
	public static readonly double PI;

	static MyMathClass()
	{ PI = 3.14; }
}

class ProgramMath
{
	public static void MainEntryMethod(string[] args)
	{
		Console.WriteLine("***** Fun with Const *****\n");
		Console.WriteLine("The value of PI is: {0}", MyMathClass.PI);
		// Error! Can't change a constant!
		// MyMathClass.PI = 3.1444;

		for (int i = 0; i < args.Count(); i++)
		{
			Console.WriteLine(args.ElementAt(i));
		}
	}
}
