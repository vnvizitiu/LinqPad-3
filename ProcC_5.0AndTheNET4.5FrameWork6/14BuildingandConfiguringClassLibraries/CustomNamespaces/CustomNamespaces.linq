<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>MyShapes</Namespace>
</Query>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyShapes;
using threeD = Chapter14.My3DShapes;

using bfHome = System.Runtime.Serialization.Formatters.Binary;

namespace CustomNamespaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is no output to show here....");
            Console.WriteLine("This project just illustrates how to package");
            Console.WriteLine("up custom types in namespaces.\n");
            /*
            Hexagon h = new Hexagon();
            Circle c = new Circle();
            Square s = new Square();
            */

            /*
            MyShapes.Hexagon h = new MyShapes.Hexagon();
            MyShapes.Circle c = new MyShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();
            */

            threeD.Hexagon h = new threeD.Hexagon();
            threeD.Circle c = new threeD.Circle();
            MyShapes.Square s = new MyShapes.Square();

            bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShapes
{
    // Circle class
    public class Circle { /* Interesting members... */ }

    // Hexagon class
    public class Hexagon { /* More interesting members... */ }

    // Square class
    public class Square { /* Even more interesting members... */ }
}

// Nesting a namespace.
namespace Chapter14
{
    namespace My3DShapes
    {
        // 3D Circle class
        class Circle { }
        // 3D Hexagon class
        class Hexagon { }
        // 3D Square class
        class Square { }
    }
}



