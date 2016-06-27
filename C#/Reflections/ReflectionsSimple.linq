<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
</Query>


    class Program
{
	static void Main(string[] args)
	{
		string test = "test";
		Console.WriteLine(test.GetType().FullName);
		Console.WriteLine(typeof(Int32).FullName);

		Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>");
		Assembly assembly = Assembly.GetExecutingAssembly();
		Type[] assemblyTypes = assembly.GetTypes();
		foreach (Type t in assemblyTypes)
			Console.WriteLine(t.Name);
		

	}
}
class DummyClass
{
	//Just here to make the output a tad less boring :)
}