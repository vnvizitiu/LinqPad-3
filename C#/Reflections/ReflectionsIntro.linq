<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

//http://csharp.net-tutorials.com/reflection/introduction/
    class Program
{
	private static int a = 5, b = 10, c = 20;

	static void Main(string[] args)
	{
		Console.WriteLine("a + b + c = " + (a + b + c));
		Console.WriteLine("Please enter the name of the variable that you wish to change: B (here in Linqpad");
		string varName = "b";
		Type t = typeof(Program);
		FieldInfo fieldInfo = t.GetField(varName, BindingFlags.NonPublic | BindingFlags.Static);
		if (fieldInfo != null)
		{
			Console.WriteLine("The current value of " + fieldInfo.Name + " is " + fieldInfo.GetValue(null) + ". You may enter a new value now: 100 in Linqpad");
			string newValue ="100";
			int newInt;
			if (int.TryParse(newValue, out newInt))
			{
				fieldInfo.SetValue(null, newInt);
				Console.WriteLine("a + b + c = " + (a + b + c));
			}
			Console.WriteLine("Finished");
		
		}
	}
}
