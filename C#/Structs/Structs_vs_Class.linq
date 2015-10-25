<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/13049/whats-the-difference-between-struct-and-class-in-net
{

// Create value type
MyStruct testStruct = new MyStruct { MyProperty = "Struct initial value" }; 
Console.WriteLine(testStruct.MyProperty);
ChangeMyStruct(testStruct);
Console.WriteLine(testStruct.MyProperty);
// Value of testStruct.MyProperty is still "initial value"
// - the method changed a new copy of the structure.
Console.WriteLine();



// Create reference type
MyClass testClass = new MyClass { MyProperty = "Class initial value" };
Console.WriteLine(testClass.MyProperty); 
ChangeMyClass(testClass);
Console.WriteLine(testClass.MyProperty); 

// Value of testClass.MyProperty is now "new value" 
// - the method changed the instance passed.
//http://stackoverflow.com/questions/13049/whats-the-difference-between-struct-and-class-in-net

}

// Define other methods and classes here
public struct MyStruct 
{
   public string MyProperty { get; set; }
}

void ChangeMyStruct(MyStruct input) 
{ 

	Console.WriteLine("Within Method ChangeMyStruct: "  +input.MyProperty);
   input.MyProperty = "Struct new value";
   Console.WriteLine("Within Method ChangeMyStruct: " +input.MyProperty);
}

 
public class MyClass 
{
    public string MyProperty { get; set; }
}

void ChangeMyClass(MyClass input) 
{ 
		Console.WriteLine("Within Method ChangeMClass: "  +input.MyProperty);
   input.MyProperty = "Class new value";
   	Console.WriteLine("Within Method ChangeMyClass: "  +input.MyProperty);
}

 

