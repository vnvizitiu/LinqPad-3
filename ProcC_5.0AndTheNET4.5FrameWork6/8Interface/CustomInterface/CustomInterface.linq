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
            Console.WriteLine("***** Fun with Interfaces *****\n");

            // Make an array of Shapes.
            Shape[] myShapes = { new Hexagon(), new Circle(), 
                       new Triangle("Joe"), new Circle("JoJo")};

            for (int i = 0; i < myShapes.Length; i++)
            {
                // Recall the Shape base class defines an abstract Draw()
                // member, so all shapes know how to draw themselves.
                myShapes[i].Draw();

                // Who's pointy?
                if (myShapes[i] is IPointy)
                    Console.WriteLine("-> Points: {0}", ((IPointy)myShapes[i]).Points);
                else
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);
                Console.WriteLine();

                // Can I draw you in 3D?
                if (myShapes[i] is IDraw3D)
                    DrawIn3D((IDraw3D)myShapes[i]);

            }

            // Get first pointy item.
            // To be safe, you'd want to check firstPointyItem for null before proceeding. 
            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            Console.WriteLine("The item has {0} points", firstPointyItem.Points);

            // This array can only contain types that
            // implement the IPointy interface.
            IPointy[] myPointyObjects = {new Hexagon(), new Knife(),
                                         new Triangle(), new Fork(), new PitchFork()};

            foreach (IPointy i in myPointyObjects)
                Console.WriteLine("Object has {0} points.", i.Points);


            //Console.ReadLine();
        }

        static void DrawIn3D( IDraw3D itf3d )
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        // This method returns the first object in the
        // array that implements IPointy.
        static IPointy FindFirstPointyShape( Shape[] shapes )
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy)
                    return s as IPointy;
            }
            return null;
        }

    }


    // The abstract base class of the hierarchy.
    abstract class Shape
    {
        public Shape( string name = "NoName" )
        { PetName = name; }
        public Shape() {}

        public string PetName { get; set; }

        // A single virtual method.
        // Force all child classes to define how to be rendered.
        public abstract void Draw();

    }



    class PointyTestClass : IPointy
    {
        public byte Points
        {
            get { throw new NotImplementedException(); }
        }
    }



    class Fork : IPointy
    {
        public byte Points
        {
            get { return 4; }
        }
    }

    class Knife : IPointy
    {
        public byte Points
        {
            get { return 1; }
        }
    }

    class PitchFork : IPointy
    {
        public byte Points
        {
            get { return 3; }
        }
    }



    // This interface defines the behavior of "having points."
    /*
    public interface IPointy
    {
        // Implicitly public and abstract.
        byte GetNumberOfPoints();
    }
    */

    // The pointy behavior as a read-only property.
    public interface IPointy
    {
        // A read-write property in an interface would look like:
        // retType PropName { get; set; }
        // while a write-only property in an interface would be:
        // retType PropName { set; }

        byte Points { get; }
    }


    // Models the ability to render a type in stunning 3D.
    public interface IDraw3D
    {
        void Draw3D();
    }


//sam

    // New Shape derived class named Triangle.
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle( string name ) : base(name) { }
        public override void Draw()
        { Console.WriteLine("Drawing {0} the Triangle", PetName); }

        // IPointy Implementation.
        public byte Points
        {
            get { return 3; }
        }
    }

    // Circle DOES NOT override Draw().
    // If we did not implement the abstract Draw() method, Circle would also be
    // considered abstract, and would have to be marked abstract!
    class Circle : Shape
    {
        public Circle() { }
        public Circle( string name ) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }


    // Hexagon now implements IPointy.
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon( string name ) : base(name) { }
        public override void Draw()
        { Console.WriteLine("Drawing {0}  the Hexagon", PetName); }

        // IPointy Implementation.
        public byte Points
        {
            get { return 6; }
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Hexagon in 3D!"); 
        }
    }


    // This class extends Circle and hides the inherited Draw() method.
    class ThreeDCircle : Circle, IDraw3D
    {
        // Hide the PetName property above me.
        public new string PetName { get; set; }

        // Hide any Draw() implementation above me.
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }

        public void Draw3D()
        { Console.WriteLine("Drawing Circle in 3D!"); }

    }


