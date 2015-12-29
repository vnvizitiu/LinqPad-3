<Query Kind="Program" />

void Main() //http://csharp.2000things.com/2014/07/31/1150-generic-delegate-type-as-parameter/
{
	MergeSomething(Add, 5, 6);
	 
	Dog dog1 = new Dog("Lassie");
	Dog dog2 = new Dog("Spuds");
	MergeSomething(Breed, dog1, dog2);
}
public delegate T Merger<T>(T thing1, T thing2);

// Define other methods and classes here
static void MergeInts(Merger<int> intMerger, int n1, int n2)
{
	int result = intMerger(n1, n2);
}

public static int Add(int n1, int n2)
{
	return n1 + n2;
}

//static void Main(string[] args)
//{
//	MergeInts(Add, 5, 6);
//}
public static Dog Breed(Dog mama, Dog papa)
{
	return new Dog(mama.Name + papa.Name);
}

 
static void  MergeSomething<T>(Merger<T> someMerger, T thing1, T thing2)
{
	T result = someMerger(thing1, thing2);
	result.Dump();
}
public class Dog
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Dog(string name, int age)
	{
		Name = name;
		Age = age;
	}
	public Dog(string name)	{ Name=name; }
	
}