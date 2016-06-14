<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/sxw2ez55.aspx
{
//Fully initialize reference types
//--------------------------------------------------------------------------------
//To avoid many NullReferenceExceptions, fully initialize reference types as close to their creation as possible.
//Add full initialization to your own classes
//If you control the class that throws a NullReferenceException, consider fully initializing the
//object in the type’s constructor.For example, here’s a revised version of the example classes that guarantees full initialization:



	var engine = BadGetEngineInfo();
	if (engine != null)
	{
		// modify the info
		engine.Power = "DIESEL";
		engine.Size = 2.4;
	}
	else
	{
		// report the error
		Console.WriteLine("BadGetEngine returned null");
	}

	//another test
	var auto = new Automobile();
	auto.Dump();
	Console.WriteLine(auto.Engine.Power);
	Console.WriteLine(auto.Engine.Size);

	var auto2 = new Automobile();
	auto2.Engine.Power = "Electricity";
	auto2.Engine.Size = 888;
	auto2.Dump();
	Console.WriteLine(auto2.Engine.Power);
	Console.WriteLine(auto2.Engine.Size);
}
public class Automobile
{
	public EngineInfo Engine { get; set; }

	public Automobile()
	{
		this.Engine = new EngineInfo();
	}

	public Automobile(string powerSrc, double engineSize)
	{
		this.Engine = new EngineInfo(powerSrc, engineSize);
	}
}


public class EngineInfo
{
	public double Size { get; set; }
	public string Power { get; set; }

	public EngineInfo()
	{
		// the base engine
		this.Power = "GAS";
		this.Size = 1.5;
	}

	public EngineInfo(string powerSrc, double engineSize)
	{
		this.Power = powerSrc;
		this.Size = engineSize;
	}
}

public EngineInfo BadGetEngineInfo()
{
	EngineInfo engine = null;
	return engine;
}
