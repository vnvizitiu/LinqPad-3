<Query Kind="Program" />

///http://csharp.2000things.com/2014/07/31/1150-generic-delegate-type-as-parameter/
public delegate T Merger<T>(T thing1, T thing2);


static int MergeInts(Merger<int> intMerger, int n1, int n2)
{
	int result = intMerger(n1, n2);
	return result;
}

public static int Add(int n1, int n2)
{
	return n1 + n2;
}

static void Main(string[] args)
{
	//MergeInts(Add, 5, 6);
	
	int res=MergeInts(Add, 5, 6);
	Console.WriteLine(res);
}

