<Query Kind="Program" />

void Main() //http://csharp.2000things.com/2013/09/30/941-checking-to-see-if-objects-are-disposable/
//http://csharp.2000things.com/2012/09/18/673-types-used-in-using-statement-must-implement-idisposable/
{
	Dog bob = new Dog("Bob", 5);
	bob.Bark();
	if (bob is IDisposable)
		((IDisposable)bob).Dispose();
		else
		{
			Console.WriteLine("Dog is not disposable");
			
		}
	
	StreamWriter sw= new StreamWriter(@"C:\Users\samtran\Documents\gitignore_global.txt");
    if (sw is IDisposable)
 		((IDisposable)sw).Dispose();
	//	Console.WriteLine("StreamWriter is disposable");
		
	else
	{
		Console.WriteLine("sw is not disposable");

	}

}
class Dog
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Dog(string name, int age) {}

	public   void Bark()
	{
		Console.WriteLine("Hello");
	}

}
// Define other methods and classes here
