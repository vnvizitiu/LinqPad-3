<Query Kind="Program" />

//(ClassIWantToCastTo)referenceIHave
// Catch a possible invalid cast.

//try
//{
//Hexagon hex = (Hexagon)frank;
//}
//catch (InvalidCastException ex)
//{
//Console.WriteLine(ex.Message);---page 286
//}
class csrefKeywordsOperators
{
	class Base
	{
		public override string ToString()
		{
			return "Base_value";
		}
	}
	class Derived : Base
	{ }
	
	class Program
	{
		static void Main()
		{

			Derived d = new Derived();

			Base b = d as Base;
	 
			if (b != null)
			{
				Console.WriteLine(b.ToString());
			}
						
			
			

		}
	}
}
class Foo  
{ }