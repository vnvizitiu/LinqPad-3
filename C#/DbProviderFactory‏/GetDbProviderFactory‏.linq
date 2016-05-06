<Query Kind="Program">
  <Namespace>System.Data.Common</Namespace>
</Query>

static DataTable GetProviderFactoryClasses()
{
	// Retrieve the installed providers and factories.
	DataTable table = DbProviderFactories.GetFactoryClasses();
	// Display each row and column value.
	foreach (DataRow row in table.Rows)
	{
		foreach (DataColumn column in table.Columns)
		{
			Console.WriteLine(row[column]);
		}
	}
	return table;
}
void Main()
{
	GetProviderFactoryClasses();
	//https://msdn.microsoft.com/en-us/library/dd0w4a2z%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
}
