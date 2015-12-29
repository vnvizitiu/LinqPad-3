<Query Kind="Program" />

void Main()
{
	TypeWithField<int>.field = "First";
	TypeWithField<string>.field = "Second";
	TypeWithField<DateTime>.field = "Third";

	TypeWithField<int>.PrintField();
	TypeWithField<string>.PrintField();
	TypeWithField<DateTime>.PrintField();
}

class TypeWithField<T>
{
	public static string field;

	public static void PrintField()
	{
		Console.WriteLine(field + ": " + typeof(T).Name);
	}
}