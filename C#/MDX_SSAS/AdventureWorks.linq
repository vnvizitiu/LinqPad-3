<Query Kind="Program">
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
</Query>

void Main()
{
	DataTable dt = new DataTable();
	using (AdomdConnection con = new AdomdConnection())
	{
		con.ConnectionString = @"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Initial Catalog=AdventureWorksDW2014Multidimensional-EE;";
		con.Open();
		AdomdCommand cmd = new AdomdCommand();
		cmd = con.CreateCommand();
		cmd.CommandText = @"SELECT NON EMPTY { [Measures].[Internet Average Unit Price], [Measures].[Internet Gross Profit Margin], 
		[Measures].[Internet Gross Profit], [Measures].[Internet Ratio to Parent Product], [Measures].[Internet Ratio to All Products], 
		[Measures].[Internet Average Sales Amount], [Measures].[End of Day Rate], [Measures].[Order Count], [Measures].[Freight Cost],
		[Measures].[Tax Amount], [Measures].[Average Rate], [Measures].[Amount], [Measures].[Sales Amount Quota], 
		[Measures].[Growth in Customer Base], [Measures].[Gross Profit], [Measures].[Average Sales Amount], [Measures].[Average Unit Price], 
		[Measures].[Ratio to All Products], [Measures].[Expense to Revenue Ratio], [Measures].[Gross Profit Margin], [Measures].[Discount Percentage],
		[Measures].[Reseller Average Unit Price], [Measures].[Reseller Gross Profit Margin], [Measures].[Reseller Gross Profit], 
		[Measures].[Reseller Ratio to Parent Product], [Measures].[Reseller Ratio to All Products], [Measures].[Reseller Average Sales Amount], 
		[Measures].[Ratio to Parent Product], [Measures].[Internet Standard Product Cost], [Measures].[Internet Total Product Cost], 
		[Measures].[Internet Order Count], [Measures].[Reseller Sales Amount], [Measures].[Customer Count], [Measures].[Internet Freight Cost], 
		[Measures].[Internet Sales Amount], [Measures].[Sales Amount], [Measures].[Internet Order Quantity], [Measures].[Internet Tax Amount], 
		[Measures].[Internet Extended Amount], [Measures].[Reseller Order Quantity], [Measures].[Order Quantity], [Measures].[Reseller Order Count], 
		[Measures].[Extended Amount], [Measures].[Total Product Cost], [Measures].[Standard Product Cost], [Measures].[Reseller Standard Product Cost], 
		[Measures].[Reseller Tax Amount], [Measures].[Reseller Extended Amount], [Measures].[Reseller Freight Cost], [Measures].[Reseller Total Product Cost], 
		[Measures].[Discount Amount] } ON COLUMNS, NON EMPTY { ([Customer].[Customer Geography].[Customer].ALLMEMBERS) }
		DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS
		FROM[Adventure Works] CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";
using (AdomdDataAdapter adt = new AdomdDataAdapter(cmd))
{
	adt.Fill(dt);
}
dt.Dump();
	}
}