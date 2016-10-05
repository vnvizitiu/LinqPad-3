<Query Kind="Program">
  <NuGetReference>R.NET.Community</NuGetReference>
  <Namespace>RDotNet</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{


	//  There are several options to initialize the engine, but by default the following suffice:

	//students < -data.frame(sid = c(1, 1, 2, 2),
	//          exmterm = c(1, 2, 1, 2),
	//          math = c(50, 65, 75, 69),
	//          literature = c(40, 45, 55, 59),
	//          language = c(70, 80, 75, 78))
	//    students



	REngine.SetEnvironmentVariables();
	REngine engine2 = REngine.GetInstance();
	// REngine requires explicit initialization.
	// You can set some parameters.
	engine2.Initialize();

	// .NET Framework array to R vector.
	NumericVector group1 = engine2.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
	engine2.SetSymbol("group1", group1);
	// Direct parsing from R script.
	NumericVector group2 = engine2.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

	// Test difference of mean and get the P-value.
	GenericVector testResult = engine2.Evaluate("t.test(group1, group2)").AsList();
	double p = testResult["p.value"].AsNumeric().First();

	Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
	Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
	Console.WriteLine("P-value = {0:0.000}", p);

	//DataFrame students =
	//    engine2.Evaluate(
	//        "students < -data.frame(sid = c(1, 1, 2, 2),exmterm = c(1, 2, 1, 2),math = c(50, 65, 75, 69),literature = c(40, 45, 55, 59)," +
	//        "language = c(70, 80, 75, 78))").AsDataFrame();

	var createModel = @"
			# different term exam.
            students <- data.frame(sid=c(1,1,2,2),
                       exmterm=c(1,2,1,2),
                       math=c(50,65,75,69),
                       literature=c(40,45,55,59),
                       language=c(70,80,75,78))
                        students";

	engine2.Evaluate(createModel);
	var m = engine2.GetSymbol("students").AsList();
//	m.Dump();
	 var x=engine2.GetSymbol("students").AsDataFrame();
	//	 x.Dump();
	 for (int i = 0; i < x.ColumnCount; i++)
	{
		Console.WriteLine(x.ColumnNames.ElementAt(i));
	 	var y=x.GetRow(i);
//		Console.WriteLine(y.DataFrame.ElementAt(i).ElementAt(i));
		 var yy=y.DataFrame.ElementAt(i).ToArray();
		 foreach (var element in yy)
		{
			Console.WriteLine(element);
		}
	}
	 
	 
}

// Define other methods and classes here

public static class Program
{
 
}
