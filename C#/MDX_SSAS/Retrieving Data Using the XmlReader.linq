<Query Kind="Program">
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
</Query>

void Main()
{
	//Open a connection to the local server.
	AdomdConnection conn = new AdomdConnection(@"Data Source=DESKTOP-E80R7DQ\SQL_MAIN");
	conn.Open();

	//Create a command to retrieve the data.
	AdomdCommand cmd = new AdomdCommand(@"WITH MEMBER [Measures].[FreightCostPerOrder] AS 
[Measures].[Reseller Freight Cost]/[Measures].[Reseller Order Quantity],  
FORMAT_STRING = 'Currency'

SELECT [Geography].[Geography].[Country].&[United States].Children ON ROWS, 
[Date].[Calendar].[Calendar Year] ON COLUMNS
FROM [Adventure Works]
WHERE [Measures].[FreightCostPerOrder]", conn);

	//Execute the command, retrieving an XmlReader.
	System.Xml.XmlReader reader = cmd.ExecuteXmlReader();

	//Do something with the reader: Parse data, Parse metadata,
	//                              Save for later loading into CellSet, etc.
	Console.WriteLine(reader.ReadOuterXml());

	//Close the reader, then the connection
	reader.Close();
	conn.Close();

	//Await user input.
 

}