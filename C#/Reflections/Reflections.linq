<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : System.Attribute
{
	public readonly string Url;

	public string Topic   // Topic is a named parameter
	{
		get
		{
			return topic;
		}
		set
		{
			topic = value;
		}
	}

	public HelpAttribute(string url)   // url is a positional parameter
	{
		this.Url = url;
	}
	private string topic;
}

[HelpAttribute("Information on the class MyClass-sam")]
class MyClass
{
	public object Foo { get; set; }
	public string doo { get; set; }
	public int shoo { get; set; }
	string Do()
	{
		return "hello";
		
	}
}


class Program
{
		static void Main(string[] args)
		{
			System.Reflection.MemberInfo info = typeof(MyClass);
			object[] attributes = info.GetCustomAttributes(true);
			for (int i = 0; i < attributes.Length; i++)
			{
				System.Console.WriteLine(attributes[i]);
			}

			
		}
}
//Reflection objects are used for obtaining type information at runtime.The classes that give access to the metadata of a running program are in the System.Reflection namespace.
//
//The System.Reflection namespace contains classes that allow you to obtain information about the application and to dynamically add types, values, and objects to the application.
//
//Applications of Reflection
//
//Reflection has the following applications:
//
//It allows view attribute information at runtime.
//
//
//It allows examining various types in an assembly and instantiate these types.
//
//
//It allows late binding to methods and properties
//
//
//It allows creating new types at runtime and then performs some tasks using those types.

