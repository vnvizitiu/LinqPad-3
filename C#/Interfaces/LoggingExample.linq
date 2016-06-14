<Query Kind="Program" />

class Program 
{
static void Main(string[] args)
{ 
	List<ILogger> loggers = new List<ILogger>(); 
	loggers.Add(new ConsoleLogger()); 
	loggers.Add(new WindowsLogLogger()); 
	loggers.Add(new DatabaseLogger()); 
	
	foreach (ILogger logger in loggers)
	{ 
		logger.LogError("Some error occurred."); 
		logger.LogInfo("All's well!");
	} 
	  Console.WriteLine("...................................."); 
} 
} 
public interface ILogger
{ 
	void LogError(string error); 
	void LogInfo(string info); 
}
	
	
public class ConsoleLogger : ILogger
{
	public void LogError(string error)
	{
		Console.WriteLine("ConsoleLogger: " + error);
	}
	public void LogInfo(string info) 
	{ 
	Console.WriteLine("ConsoleLogger " + info);
	} 
}

public class WindowsLogLogger : ILogger
{
	public void LogError(string error) 
	{
		Console.WriteLine("Logging error to Windows Event log: " + error);
	}
	public void LogInfo(string info) 
	{
		Console.WriteLine("Logging info to Windows Event log: " + info);
	} 
} 
public class DatabaseLogger : ILogger 
{
	public void LogError(string error) 
	{
		Console.WriteLine("Logging error to database: " + error);
	} 
	public void LogInfo(string info)
	{
		Console.WriteLine("Logging info to database: " + info);
	}
}