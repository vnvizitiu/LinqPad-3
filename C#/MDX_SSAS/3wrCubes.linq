<Query Kind="Program">
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
</Query>

void Main()
{
	DataTable dt = new DataTable();
	using (AdomdConnection con = new AdomdConnection())
	{
		con.ConnectionString = @"Data Source=L000139\SQL2014;Initial Catalog=BIDA_3WR;";
		con.Open();
		AdomdCommand cmd = new AdomdCommand();
		cmd = con.CreateCommand();
		cmd.CommandText = @" SELECT NON EMPTY { [Measures].[PAS_Count], [Measures].[PAS_Amt], [Measures].[GL_Amt], [Measures].[Cal_Diff], [Measures].[GL_Count] } 
              ON COLUMNS, NON EMPTY { ([System].[SYSTEM NAME].[SYSTEM NAME].ALLMEMBERS * [Time].[Year -  Quarter -  Month -  Date].[Date].ALLMEMBERS 
              * [PF KEY].[PF__KEY].[PF__KEY].ALLMEMBERS * [std_comment].[STD COMMENT].[STD COMMENT].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION,
              MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Reconciled].[Reconciled].&[Not Reconciled] } ) ON COLUMNS FROM [vrtPASGL]) WHERE
              ( [Reconciled].[Reconciled].&[Not Reconciled] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";
		using (AdomdDataAdapter adt = new AdomdDataAdapter(cmd))
		{
			adt.Fill(dt);
		}
		dt.Dump();
	}
}
