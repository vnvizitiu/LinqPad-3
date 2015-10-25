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
            Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
            Octagon oct = new Octagon();

            // We now must use casting to access the Draw()
            // members.
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            // Shorthand notation if you don't need
            // the interface variable for later use.
            ((IDrawToPrinter)oct).Draw();

            // Could also use the "as" keyword.
            if (oct is IDrawToMemory)
                ((IDrawToMemory)oct).Draw();

           // Console.ReadLine();
        }
    }
	
	
	
    //class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    //{
    //    public void Draw()
    //    {
    //        // Shared drawing logic.
    //        Console.WriteLine("Drawing the Octagon...");
    //    }
    //}

    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // Explicitly bind Draw() implementations
        // to a given interface.
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to a printer...");
        }
    }





    // Draw image to a Form.
    public interface IDrawToForm
    {
        void Draw();
    }

    // Draw to buffer in memory.
    public interface IDrawToMemory
    {
        void Draw();
    }

    // Render to the printer.
    public interface IDrawToPrinter
    {
        void Draw();
    }
