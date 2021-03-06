<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Activities.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.DurableInstancing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.Activities.Compiler.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

//using System;
//using System.Collections.Generic;
//https://msdn.microsoft.com/en-us/library/x0b5b5bc%28v=vs.110%29.aspx

// Simple business object. A PartId is used to identify a part  
// but the part name can change.  
public class Part : IEquatable<Part>
{
    public string PartName { get; set; }
    public int PartId { get; set; }

    public override string ToString()
    {
        return "ID: " + PartId + "   Name: " + PartName;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Part objAsPart = obj as Part;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return PartId;
    }
    public bool Equals(Part other)
    {
        if (other == null) return false;
        return (this.PartId.Equals(other.PartId));
    }
    // Should also override == and != operators.
}
public class Example
{
    public static void Main()
    {
        // Create a list of parts.
        List<Part> parts = new List<Part>();

        // Add parts to the list.
        parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
        parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
        parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
        parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

        // Write out the parts in the list. This will call the overridden ToString method 
        // in the Part class.
        Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }
		
	
		

        // Check the list for part #1734. This calls the IEquitable.Equals method 
        // of the Part class, which checks the PartId for equality.
        Console.WriteLine("\nContains: Part with Id=1734: {0}",
            parts.Contains(new Part { PartId = 1734, PartName = "" }));

        // Find items where name contains "seat".
        Console.WriteLine("\nFind: Part where name contains \"seat\": {0}", 
            parts.Find(x => x.PartName.Contains("seat")));

        // Check if an item with Id 1444 exists.
        Console.WriteLine("\nExists: Part with Id=1444: {0}", 
            parts.Exists(x => x.PartId == 1444));

        /*This code example produces the following output:

        ID: 1234   Name: crank arm
        ID: 1334   Name: chain ring
        ID: 1434   Name: regular seat
        ID: 1444   Name: banana seat
        ID: 1534   Name: cassette
        ID: 1634   Name: shift lever

        Contains: Part with Id=1734: False

        Find: Part where name contains "seat": ID: 1434   Name: regular seat

        Exists: Part with Id=1444: True 
         */
		 Console.WriteLine("Lamda begings.....................................................................");
		 Action<Part> print= part=>Console.WriteLine("PartName={0}, ID={1}",part.PartName, part.PartId);
		 parts.ForEach(print);
		
	   Console.WriteLine("Lamda end.");


		Console.WriteLine("Oldies");
		 parts.FindAll(film => film.PartId < 1400)
			.ForEach(print);
			
		Console.WriteLine();



		Console.WriteLine("Sorted");
		parts.Sort((f1, f2) => f1.PartName.CompareTo(f2.PartName));
		parts.ForEach(print);

	}
}