<Query Kind="Program" />

//http://www.nullskull.com/a/1671/lambda-expressions-func-and-action-delegates.aspx
static void Main()
 {
	int factor = 6;
	Func<int, int> multiplier = n => n * factor;
	Console.WriteLine(multiplier(3));           // 18
}
