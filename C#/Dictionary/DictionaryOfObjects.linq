<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

//using System;
//using System.Collections.Generic;
//http://stackoverflow.com/questions/10930705/creating-objects-dynamically-in-loop 
public class myClass
{
	public string Name { get; set; }
    public myClass(){
    }
}

class MainClass
{
	 public static void Main() 
    {
        string[] array = new string[] { "one", "two", "three" };
        IDictionary<string,myClass> col= new Dictionary<string,myClass>();
        foreach (string name in array)
        {
              col[name] = new myClass { Name = "hahah " + name  + "!"};
        }

        foreach(var x in col.Values)
        {
              Console.WriteLine(x.Name);
        }

        Console.WriteLine("Test");
        Console.WriteLine(col["two"].Name);
    }
}