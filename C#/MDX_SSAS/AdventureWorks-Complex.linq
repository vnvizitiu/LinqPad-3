<Query Kind="Program">
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
</Query>

void Main() //https://msdn.microsoft.com/en-us/library/ms123476.aspx
{

	//Create a new string builder to store the results
	System.Text.StringBuilder result = new System.Text.StringBuilder();

	//Connect to the local server
		using (AdomdConnection conn = new AdomdConnection(@"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;"))
		{
			conn.Open();

			//Create a command, using this connection
			AdomdCommand cmd = conn.CreateCommand();
			cmd.CommandText = @"
                              WITH MEMBER [Measures].[FreightCostPerOrder] AS 
                                    [Measures].[Reseller Freight Cost]/[Measures].[Reseller Order Quantity],  
                                    FORMAT_STRING = 'Currency'
                              SELECT 
                                    [Geography].[Geography].[Country].&[United States].Children ON ROWS, 
                                    [Date].[Calendar].[Calendar Year] ON COLUMNS
                              FROM [Adventure Works]
                              WHERE [Measures].[FreightCostPerOrder]";

			//Execute the query, returning a cellset
			CellSet cs = cmd.ExecuteCellSet();

			//Output the column captions from the first axis
			//Note that this procedure assumes a single member exists per column.
			result.Append("\t");
			TupleCollection tuplesOnColumns = cs.Axes[0].Set.Tuples;
			foreach (Microsoft.AnalysisServices.AdomdClient.Tuple column in tuplesOnColumns)
			{
				result.Append(column.Members[0].Caption + "\t");
			}
			result.AppendLine();

			//Output the row captions from the second axis and cell data
			//Note that this procedure assumes a two-dimensional cellset
			TupleCollection tuplesOnRows = cs.Axes[1].Set.Tuples;
			for (int row = 0; row < tuplesOnRows.Count; row++)
			{
				result.Append(tuplesOnRows[row].Members[0].Caption + "\t");
				for (int col = 0; col < tuplesOnColumns.Count; col++)
				{
					result.Append(cs.Cells[col, row].FormattedValue + "\t");
				}
				result.AppendLine();
			}
			conn.Close();

			result.Dump();
		} // using connection
	}

 