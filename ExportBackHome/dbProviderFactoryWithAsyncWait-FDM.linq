<Query Kind="Program">
  <Namespace>System.Data.Common</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


class A
{
	static async Task PerformDBOperationsUsingProviderModel(string connectionString, string providerName)
	{
		DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
		using (DbConnection connection = factory.CreateConnection())
		{
			connection.ConnectionString = connectionString;
			await connection.OpenAsync();

			DbCommand command = connection.CreateCommand();
			command.CommandText = MYSQL.sql();

			using (DbDataReader reader = await command.ExecuteReaderAsync())
			{
				while (await reader.ReadAsync())
				{
					for (int i = 0; i < reader.FieldCount; i++)
					{
						// Process each column as appropriate
						object obj = await reader.GetFieldValueAsync<object>(i);
						Console.WriteLine(obj);
					}
				}
			}
		}
	}

	public static void Main()
	{
		string myConn = @"Data Source=DATASTAGE_OXPA;Persist Security Info=True;User ID=FDM_RO;Password=eu2b93pE286hzY";
		string provider = "Oracle.DataAccess.Client";

		Task task = PerformDBOperationsUsingProviderModel(myConn, provider);
		task.Wait();
	}
}




public static class MYSQL
{
	public static string sql()
	{
		return @"select p.PAS_ID, rs.RUN_STRM_X, PAS_PROS_D, PAS_TRAN_EFFT_D, PAS_CLNT_N, PAS_PLCY_N, PAS_PLCY_HOLD_M,PAS_TNNR, p.PAS_USER_C, 
           PAS_TRTP_C, PAS_TRAN_SUB_C, PAS_PDCT_C, GL_A, PAS_BUST_C,GL_ACCT_CALR_ID
		  from FDM_ODS.USER_PAS_TRAN_V p, FDM_CTL.STEP_OCCR st, FDM_CTL.RUN_STRM rs, FDM_ODS.DIMN_PAS_C_BLOK bl
          where GL_ACCT_CALR_ID = '20151215'
          and p.pas_ID in ('17', '18', '31', '33', '24') and p.recd_crat_step_occr_id = st.STEP_OCCR_ID and st.RUN_STRM_C = rs.RUN_STRM_C and
         p.PAS_C_BLOK_ID = bl.PAS_C_BLOK_ID
          and st.RUN_STRM_C in ('CUAUDH5','C2AUDH5','ILAUDH5','STAUDH5','AEAUDH5') and st.STEP_C = 'LD_STD' and bl.PAS_COLM_6_VALU = 'OTHER'
          and((GL_DR_CR_F = 'D' and PAS_A_SIGN = '+') or(GL_DR_CR_F = 'C' and PAS_A_SIGN = '-')) 
          order by p.PAS_ID, PAS_PLCY_N,PAS_CLNT_N, PAS_TNNR";

	}


}
//
//0: System.Data.Odbc
//1: System.Data.OleDb
//2: System.Data.OracleClient
//3: System.Data.SqlClient
//4: Oracle.ManagedDataAccess.Client
//5: Oracle.DataAccess.Client
//6: System.Data.SqlServerCe.3.5
//7: System.Data.SqlServerCe.4.0
//8: Teradata.Client.Provider
//------------------------------------------------------