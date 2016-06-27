<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

//http://csharp.net-tutorials.com/reflection/instantiating-a-class/
    class Program
{
	static void Main(string[] args)
	{
		Type testType = typeof(TestClass);
		ConstructorInfo ctor = testType.GetConstructor(System.Type.EmptyTypes);
		if (ctor != null)
		{
			object instance = ctor.Invoke(null);
			MethodInfo methodInfo = testType.GetMethod("TestMethod");
			Console.WriteLine(methodInfo.Invoke(instance, new object[] { 1000 }));
		}
		
	}
}

public class TestClass
{
	private int testValue = 42;

	public int TestMethod(int numberToAdd)
	{
		return this.testValue + numberToAdd;
	}
}