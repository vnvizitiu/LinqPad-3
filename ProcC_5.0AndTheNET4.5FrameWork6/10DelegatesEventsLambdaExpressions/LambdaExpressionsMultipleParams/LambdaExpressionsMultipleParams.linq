<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>



    #region SimpleMath (with delegates)
    public class SimpleMath
    {
        public delegate void MathMessage( string msg, int result );
        private MathMessage mmDelegate;

        public void SetMathHandler( MathMessage target )
        { mmDelegate = target; }

        public void Add( int x, int y )
        {
            if (mmDelegate != null)
                mmDelegate.Invoke("Adding has completed!", x + y);
        }
    }
    #endregion

    class Program
    {
        static void Main( string[] args )
        {
            // Register w/ delegate as a lambda expression.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler(( msg, result ) =>
            { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });

            // This will execute the lambda expression.
            m.Add(10, 10);
          //  Console.ReadLine();
        }
    }
