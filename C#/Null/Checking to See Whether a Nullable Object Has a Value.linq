<Query Kind="Program" />

void Main()//http://csharp.2000things.com/2011/01/13/210-checking-to-see-whether-a-nullable-object-has-a-value/
{
	//int? herAge = null;
	int? herAge = 10;
	if (herAge.HasValue)
		Console.WriteLine("She is {0} yrs old", herAge);


//}
//
//// Define other methods and classes here
//Both the built -in nullable types(e.g. int?) and any Nullable<T> types that you use have a HasValue property that lets you determine whether a particular nullable object has a value or not.
//◾HasValue is true if the object has a value of the corresponding type
//◾HasValue is false if the object has a null value
//
//For example, if you are using a nullable int:
//
//
//
//1
//
//int? herAge = null;
//
//
//And you later want to see if this variable has a value(of type int), you can do this:



1
2

if (herAge.HasValue)
	Console.WriteLine("She is {0} yrs old", herAge);


HasValue is useful in cases when you want to perform an operation on an object, where the operation is only valid if the object is non - null.
