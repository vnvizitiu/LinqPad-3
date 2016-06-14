<Query Kind="Program">
  <GACReference>Microsoft.AnalysisServices.AdomdClient, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.AnalysisServices.AdomdClient</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	PASGL x=new PASGL();
	

	DataTable dt=x.GetData();
}
 
	public class PASGL
	{
		public string System { get; set; }
		public DateTime Year { get; set; }
		public DateTime Month { get; set; }
		public DateTime Date { get; set; }
		public string PF_KEY { get; set; }
		public double PAS_Amt { get; set; }
		public int PAS_cnt { get; set; }
		public double GL_Amt { get; set; }
		public int GL_cnt { get; set; }
		public double Calc_Diff { get; set; }


		public DataTable GetData()
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
					var myresults=dt.AsEnumerable().ToList();
				 
					dt.Dump();
					return dt;
					
				 

				}

			}
		}
	}
 
// Define other methods and classes here