<Query Kind="Program" />

void Main()
{
	DataTable dt= System.Data.Common.DbProviderFactories.GetFactoryClasses();
	Console.WriteLine(dt.TableName);

	//http://blogs.msdn.com/b/dataaccesstechnologies/archive/2009/11/09/ssis-error-code-dts-e-oledberror-an-ole-db-error-has-occurred-reasons-and-troubleshooting.aspx
	
}

// Define other methods and classes here