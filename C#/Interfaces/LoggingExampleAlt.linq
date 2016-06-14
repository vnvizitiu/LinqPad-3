<Query Kind="Program" />

class Program 
{
static void Main(string[] args)
{ 
	List<IErrorLogger> e_loggers = new List<IErrorLogger>(); 
	  
	e_loggers.Add(new ErrorLogger()); 
	//loggers.Add(new InformationLogger()); 
	
	foreach (IErrorLogger logger in e_loggers)
	{ 
		logger.TextLogger("Some error occurred-Null exception"); 
	 	logger.DBLogger("Some error occurred-Null exception"); 
	} 
	  Console.WriteLine("...................................."); 
	  var e=new ErrorLogger();
	  e.DBLogger("xx");
	  e.TextLogger("yy");
		Console.WriteLine("================================");
		string method = string.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
		Console.WriteLine(method);
	}
}
public interface IErrorLogger
{
	void TextLogger(string error);
	void DBLogger(string info);
}



public class ErrorLogger : IErrorLogger
{
	public void TextLogger(string error) 
	{
		Console.WriteLine("Writting to text file: " + error);
	}
	public void DBLogger(string error) 
	{
		Console.WriteLine("Writing to database: " + error);
	} 
} 
 