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
            Console.WriteLine("***** Fun with Custom Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);

            try
            {
                // Trip exception.
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
            Console.ReadLine();
        }

    }


    class Radio
    {
        public void TurnOn( bool on )
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }


 
    class Car
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;

        // Car properties.
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        // Is the car still operational?
        private bool carIsDead;

        // A car has-a radio.
        private Radio theMusicBox = new Radio();

        // Constructors.
        public Car() { }
        public Car( string name, int speed )
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        #region Methods
        public void CrankTunes( bool state )
        {
            // Delegate request to inner object.
            theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        // This time, throw an exception if the user speeds up beyond MaxSpeed.
        public void Accelerate( int delta )
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;

                    // We need to call the HelpLink property, thus we need
                    // to create a local variable before throwing the Exception object.
                    CarIsDeadException ex =
                        new CarIsDeadException(string.Format("{0} has overheated!", PetName),
                                               "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";


                    // Stuff in custom data regarding the error.
                    ex.Data.Add("TimeStamp",
                      string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
    #endregion
	
	
	
    #region Take One
    // This custom exception describes the details of the car-is-dead condition.
    /*
    public class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException( string message,
          string cause, DateTime time )
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        // Override the Exception.Message property.
        public override string Message
        {
            get
            {
                return string.Format("Car Error Message: {0}", messageDetails);
            }
        }
    }
    */
    #endregion

    #region Take Two
    /*
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }

        // Feed message to parent constructor.
        public CarIsDeadException( string message, string cause, DateTime time )
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
    */
    #endregion

    #region Take Three
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }

        // Feed message to parent constructor.
        public CarIsDeadException( string message, string cause, DateTime time )
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public CarIsDeadException( string message ) : base(message) { }
        public CarIsDeadException( string message,
                                  System.Exception inner )
            : base(message, inner) { }
        protected CarIsDeadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context )
            : base(info, context) { }

        // Any additional custom properties, constructors and data members...
    }
    #endregion


