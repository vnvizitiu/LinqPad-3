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
            Console.WriteLine("View sample code to see MI on interfaces");
        }
    }



    // Multiple inheritance for interface types is a-okay.
    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Note possible name clash here!
    }

    // Multiple interface inheritance. OK!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }



    class Rectangle : IShape
    {
        public int GetNumberOfSides()
        { return 4; }

        public void Draw()
        { Console.WriteLine("Drawing..."); }

        public void Print()
        { Console.WriteLine("Prining..."); }
    }


    class Square : IShape
    {
        // Using explicit implementation to handle member name clash.
        void IPrintable.Draw()
        {
            // Draw to printer ...
        }
        void IDrawable.Draw()
        {
            // Draw to screen ...
        }
        public void Print()
        {
            // Print ...
        }
        public int GetNumberOfSides()
        { return 4; }
    }
