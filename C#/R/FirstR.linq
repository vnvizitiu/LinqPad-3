<Query Kind="Program">
  <NuGetReference>R.NET</NuGetReference>
  <NuGetReference>R.NET.Community</NuGetReference>
  <Namespace>RDotNet</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
	Program.Main();
}

// Define other methods and classes here
public class Program
{
	public static void Main()
	{
		// Set the folder in which R.dll locates.
		var envPath = Environment.GetEnvironmentVariable("PATH");
		var rBinPath = @"C:\Program Files (x86)\R\R-2.11.1\bin";
		//var rBinPath = @"C:\Program Files\R\R-2.11.1-x64\bin"; // Doesn't work ("DLL was not found.")
		Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
		using (REngine engine = REngine.CreateInstance("RDotNet"))
		{
			// Initializes settings.
			engine.Initialize();

			// .NET Framework array to R vector.
			NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
			engine.SetSymbol("group1", group1);
			// Direct parsing from R script.
			NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

			// Test difference of mean and get the P-value.
			GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
			double p = testResult["p.value"].AsNumeric().First();

			Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
			Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
			Console.WriteLine("P-value = {0:0.000}", p);
		}
	}
}