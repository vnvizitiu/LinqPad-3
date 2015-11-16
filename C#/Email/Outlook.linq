<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Outlook.dll</Reference>
  <Namespace>Microsoft.CSharp</Namespace>
  <Namespace>Microsoft.Office.Interop.Outlook</Namespace>
  <Namespace>outlook = Microsoft.Office.Interop.Outlook</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

//using outlook = Microsoft.Office.Interop.Outlook;
//using System.Data.SqlClient;
//using Microsoft.CSharp;
public static class EmailServices
{
	public static void RunEmail()
	{
		outlook.MailItem OutlookMessage = default(outlook.MailItem);
			outlook.Application AppOutlook = new outlook.Application();
			//  Globals.ThisAddIn.Application
			// Globals.ThisAddIn.Application
			outlook._NameSpace objNS = AppOutlook.Session;
			outlook.MAPIFolder objFolder = default(outlook.MAPIFolder);
			objFolder = objNS.GetDefaultFolder(outlook.OlDefaultFolders.olFolderDrafts);

			//System.Data.SqlClient.SqlConnection(MyConfigurations.GetConnectionString());

			try
			{
				StringBuilder sb = new StringBuilder();
				//  this.ToolStripStatusLabel1.Text = "Preparing Email";
				sb.AppendLine("Hi All,");
				sb.AppendLine("Please find attached the 3WayRec Management Summary for: "); //+ DateTimePicker1.Value.ToLongDateString);
				sb.AppendLine("");
				sb.AppendLine("Systems Accounting Team");
				OutlookMessage = AppOutlook.CreateItem(outlook.OlItemType.olMailItem);


				outlook.Recipients Recipents = OutlookMessage.Recipients;
				// Recipents.Type = CInt(outlook.OlMailRecipientType.olTo)
				//   Dim ccrep As outlook.Recipients = OutlookMessage.Recipients
				//  ccrep.Type = CInt(outlook.OlMailRecipientType.olCC)
				try
				{
					SqlConnection connection = new SqlConnection(MyConfigurations.GetConnectionString());
					using (connection)
					{
						//  command() = new SqlCommand("Select Email_Address,CC from [vaunsw302\\sqlpro_ciapps2].ThreeWayRec.dbo.lookup_email_recipients_detail", connection);
						SqlCommand command = new SqlCommand(MyConfigurations.MyEmailSQL(), connection);
						connection.Open();
						SqlDataReader reader = command.ExecuteReader();
						while (reader.Read())
						{
							if (reader.HasRows)
							{
								if (!reader.IsDBNull(1))
								{
									outlook.Recipient ccrep = OutlookMessage.Recipients.Add(reader.GetString(0));
									//  ccrep.Add(reader(0))
									ccrep.Type = Convert.ToInt32(outlook.OlMailRecipientType.olCC);
								}

								else
								{
									Recipents.Add(reader.GetString(0));
								}


							}


						}

						reader.Close();
					}
				}
				catch (SystemException ex)
				{
					Console.WriteLine(ex.ToString());

				}
				OutlookMessage.Subject = "Control Point 13(i,ii) for Date(s): "; //+ DateTimePicker1.Value.ToLongDateString;
																				 //   OutlookMessage.Body = sb.ToString;
				OutlookMessage.BodyFormat = outlook.OlBodyFormat.olFormatHTML;
				//OutlookMessage.Attachments.Add("\\sydiis01\data\Finance\Systems Accounting\3WR\sam\ManagmentSumm\ss.xls")
				//if (!System.IO.File.Exists(grep))
				//{
				//    Interaction.MsgBox("Attempts to attach the file " + "'" + grep + "' failed as it does not exists");
				//}
				//else
				//{
				//    OutlookMessage.Attachments.Add(grep);
				//}
				//if (!System.IO.File.Exists(gstrFileNamex))
				//{
				//    Interaction.MsgBox("Attempts to attach the file " + "'" + gstrFileNamex + "' failed as it does not exists");
				//}
				//else
				//{
				//    OutlookMessage.Attachments.Add(gstrFileNamex);
				//}

				OutlookMessage.Save();

				//   OutlookMessage.Move(objFolder)

				//OutlookMessage.Send()
				OutlookMessage.Display();
				// this.ToolStripStatusLabel1.Text = "Email ready!!";
			}
			catch (SystemException ex)
			{
				// Interaction.MsgBox(ex.ToString());
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				OutlookMessage = null;
				AppOutlook = null;
			}
		}



	}

public static class MyConfigurations
{
	public static string FirstSQL()
	{
		string mysql = @"SELECT RUN_NO, DATA_DATE, LOAD_STATUS, PAS_AMOUNT, UP_AMOUNT, DOLLAR_DIFF, PAS_UNITS, 
            UP_UNITS, UNIT_DIFF, SYSTEM_NAME,TOTAL_COMMENTS FROM ThreeWayRec.dbo.vw_Summary
            WHERE DATA_DATE = '2015-10-28'  ; With P as (SELECT a.RUN_NO, a.DATA_DATE, SUM(t.AMOUNT) AS PAS_Amount,
            COUNT(*) AS UP_Count, a.SYSTEM, g.[Stat Fund], CASE WHEN g.[Stat Fund] = 'CpGt' THEN 'CpGt' ELSE 'UL' END AS iFund, 
            tt.Product, t.INV_OPTION,TT.TN_TYPE FROM ThreeWayRec.dbo.app_run_no AS 
            a INNER JOIN ThreeWayRec.dbo.transref_pas AS t ON a.RUN_NO = t.RUN_NO INNER JOIN UnitLinked.dbo.system
        AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN UnitLinked.dbo.lookup_investment_option AS l ON l.OPTION_CODE = CASE WHEN LEFT(t .INV_OPTION, 1)
        = 'F' AND LEN(t .INV_OPTION)= 7 THEN SUBSTRING(t .INV_OPTION, 2, 6) ELSE LEFT(t .INV_OPTION, 6) END INNER JOIN UnitLinked.dbo.lookup_hiport2psoft
            AS h ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger INNER JOIN
        ThreeWayRec.dbo.transaction_calibre_pas tt ON t.TRANSACTION_REF = tt.REC_TRANSACTION_ID WHERE (a.DATA_DATE = '2015-10-28') AND (t.UP_KEY IS NOT NULL) 
        AND (t.EXCLUDED = 0) AND (l.SOURCE=10) GROUP BY a.RUN_NO, a.DATA_DATE, a.SYSTEM, g.[Stat Fund], tt.Product,t.INV_OPTION, TT.TN_TYPE ) ,U as (SELECT a.RUN_NO, a.DATA_DATE, SUM(t.AMOUNT) 
        AS UP_Amount, COUNT(*) AS PAS_Count, a.SYSTEM, g.[Stat Fund], CASE WHEN g.[Stat Fund] = 'CpGt' THEN 'CpGt' ELSE 'UL' END AS iFund, tt.Product_Code, t.INV_OPTION,TT.TRANS_CODE FROM
        ThreeWayRec.dbo.app_run_no AS a INNER JOIN ThreeWayRec.dbo.transref_updata AS t ON a.RUN_NO = t.RUN_NO INNER JOIN 
        UnitLinked.dbo.system AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN UnitLinked.dbo.lookup_investment_option AS l ON l.OPTION_CODE = CASE WHEN LEFT(t .INV_OPTION, 1) = 'F' AND LEN(t .INV_OPTION)= 7 THEN SUBSTRING(t .INV_OPTION, 2, 6) ELSE LEFT(t .INV_OPTION, 6) END INNER JOIN UnitLinked.dbo.lookup_hiport2psoft AS h ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger INNER JOIN ThreeWayRec.dbo.transaction_calibre_up tt ON t.TRANSACTION_REF = tt.REC_TRANSACTION_ID WHERE (a.DATA_DATE = '2015-10-28') AND (t.PAS_KEY IS NOT NULL) AND (t.EXCLUDED = 0) AND (l.SOURCE =10) GROUP BY a.RUN_NO, a.DATA_DATE, a.SYSTEM, g.[Stat Fund], tt.Product_Code,t.INV_OPTION, TT.TRANS_CODE ) , pp as (Select P.RUN_NO,P.DATA_DATE,'Calibre' as SYSTEM,P.IFUND,GL_EQAL_PAS_C AS S_DATABASE ,SUM(P.PAS_AMOUNT) AS PAS_REC, SUM(CASE WHEN TN_TYPE='SWT'THEN PAS_AMOUNT*-1 ELSE PAS_AMOUNT END)AS PAS_ADJUSTED FROM P INNER JOIN ThreeWayRec.dbo.CalibreMap B ON P.PRODUCT=B.PRODUCT AND P.INV_OPTION=B.INVESTMENT_OPTION GROUP BY P.RUN_NO,P.DATA_DATE,P.SYSTEM,GL_EQAL_PAS_C,P.IFUND ),uu as (Select U.RUN_NO,U.DATA_DATE,U.SYSTEM,U.IFUND,GL_EQAL_PAS_C AS S_DATABASE, SUM(U.UP_AMOUNT)AS UP_REC,SUM(CASE WHEN TRANS_CODE='SWT'THEN UP_AMOUNT*-1 ELSE UP_AMOUNT END)AS UP_ADJUSTED FROM U INNER JOIN ThreeWayRec.dbo.CalibreMap B ON U.PRODUCT_CODE=B.PRODUCT AND U.INV_OPTION=B.INVESTMENT_OPTION GROUP BY U.RUN_NO,U.DATA_DATE,U.SYSTEM,GL_EQAL_PAS_C,U.IFUND )Select  PP.RUN_NO,PP.DATA_DATE,PP.SYSTEM,PP.IFUND,PP.S_DATABASE,ROUND(PP.PAS_REC,2)AS PAS_REC,ROUND(UU.UP_REC,2)AS UP_REC, ROUND(PP.PAS_REC-UU.UP_REC,2) AS REC_DIFF,ROUND(PP.PAS_ADJUSTED,2)AS PAS_ADJUST,ROUND(UU.UP_ADJUSTED,2)AS UP_ADJUST,ROUND(PP.PAS_ADJUSTED-UU.UP_ADJUSTED,2) AS ADJUSTED_DIFF from uu inner join pp on uu.ifund=pp.ifund and uu.s_database=pp.s_database ; With u as (SELECT a.RUN_NO, a.DATA_DATE, SUM(t.AMOUNT) AS UP_Amount, COUNT(*) AS UP_Count, a.SYSTEM ,g.[Stat Fund], CASE WHEN g.[Stat Fund]='CpGt' THEN 'CpGt' else 'UL' END as iFund FROM ThreeWayRec.dbo.app_run_no AS a INNER JOIN   ThreeWayRec.dbo.transref_UPDATA   AS t ON a.RUN_NO = t.RUN_NO INNER JOIN  UnitLinked.dbo.system AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN   UnitLinked.dbo.lookup_investment_option AS l ON L.OPTION_CODE=  CASE WHEN LEFT(t.INV_OPTION,1)='F' AND LEN(t.INV_OPTION)=7   THEN  SUBSTRING(t.INV_OPTION,2,6) ELSE  LEFT(t.INV_OPTION, 6) END INNER JOIN  UnitLinked.dbo.lookup_hiport2psoft   AS h ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN  UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger  WHERE (a.DATA_DATE = '2015-10-28')  AND (t.PAS_KEY IS NOT NULL) AND (t.EXCLUDED = 0) AND (L.SOURCE IS NOT NULL)  GROUP BY a.RUN_NO, a.DATA_DATE,A.SYSTEM,g.[Stat Fund] ) ,  p as (SELECT a.RUN_NO, a.DATA_DATE, SUM(t.AMOUNT) AS PAS_Amount, COUNT(*) AS PAS_Count, a.SYSTEM, g.[Stat Fund],  CASE WHEN g.[Stat Fund]='CpGt' THEN 'CpGt' else 'UL'END as iFund FROM ThreeWayRec.dbo.app_run_no AS a INNER JOIN  ThreeWayRec.dbo.transref_pas  AS t ON a.RUN_NO = t.RUN_NO INNER JOIN  UnitLinked.dbo.system AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN  UnitLinked.dbo.lookup_investment_option AS l ON l.OPTION_CODE=CASE WHEN LEFT(t.INV_OPTION,1)='F' AND LEN(t.INV_OPTION)=7   THEN SUBSTRING(t.INV_OPTION,2,6) ELSE  LEFT(t.INV_OPTION, 6) END INNER JOIN  UnitLinked.dbo.lookup_hiport2psoft AS h   ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN  UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger  WHERE (a.DATA_DATE =  '2015-10-28') AND (t.UP_KEY IS NOT NULL) AND (t.EXCLUDED = 0) AND (L.SOURCE IS NOT NULL)   GROUP BY a.RUN_NO, a.DATA_DATE,A.SYSTEM, g.[Stat Fund] )  Select u.RUN_NO,u.DATA_DATE,CASE WHEN u.SYSTEM=8 THEN 'Life 400' WHEN U.SYSTEM=10 THEN 'Calibre' else 'Paxus'END   as SYSTEM, u.iFund,'L400'AS S_DATABASE,sum(round(p.PAS_Amount,2))as PAS_REC,sum(round(U.UP_Amount,2))as UP_REC,  SUM(ROUND(p.PAS_Amount-U.UP_Amount,2)) AS REC_DIFF,  sum(round(p.PAS_Amount,2))as PAS_ADJUST,  sum(round(U.UP_Amount,2))as UP_ADJUST,  SUM(ROUND(p.PAS_Amount-U.UP_Amount,2)) AS ADJUSTED_DIFF  from u inner join p on u.run_no=p.run_no and u.[Stat Fund]=p.[Stat Fund]  group by u.SYSTEM,u.data_date,u.run_no, 
            u.iFund having u.system in('8')order by u.system,u.ifund ";
		return mysql;

	}
	public static string SecondSQL()////sql needs to be updated
	{
		string mysql = @"With C as (SELECT a.RUN_NO, CONVERT(VARCHAR(11),a.DATA_DATE,106) AS DATA_DATE, 'Calibre' as System, 
            g.[Stat Fund], tt.Product_Code, t.INV_OPTION,TT.TRANS_CODE,tt.POLICY_REFERENCE,T.PAS_KEY,ROUND(t.AMOUNT,2) AS UP_Amount,CASE WHEN TRANS_CODE='SWT' THEN ROUND(t.AMOUNT * -1,2) WHEN TRANS_CODE='CSWT'THEN ROUND(t.AMOUNT * -1,2) ELSE ROUND(t.AMOUNT,2) END AS Adj_UP_Amount FROM ThreeWayRec.dbo.app_run_no AS a INNER JOIN ThreeWayRec.dbo.transref_updata AS t ON a.RUN_NO = t.RUN_NO INNER JOIN UnitLinked.dbo.system AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN UnitLinked.dbo.lookup_investment_option AS l ON l.OPTION_CODE = CASE WHEN LEFT(t .INV_OPTION, 1) = 'F' AND LEN(t .INV_OPTION)= 7 THEN SUBSTRING(t .INV_OPTION, 2, 6) ELSE LEFT(t .INV_OPTION, 6) END INNER JOIN UnitLinked.dbo.lookup_hiport2psoft AS h ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger INNER JOIN ThreeWayRec.dbo.transaction_calibre_up tt ON t.TRANSACTION_REF = tt.REC_TRANSACTION_ID WHERE (a.DATA_DATE = '2015-10-28') AND (t.PAS_KEY IS NOT NULL) AND (t.EXCLUDED = 0) AND (l.SOURCE =10)and [STAT FUND]<>'CpGT' ) Select RUN_NO,DATA_DATE,SYSTEM,[STAT FUND],GL_EQAL_PAS_C,PRODUCT_CODE,TRANS_CODE,INV_OPTION,POLICY_REFERENCE,PAS_KEY,UP_AMOUNT,Adj_UP_Amount FROM C INNER JOIN ThreeWayRec.dbo.CalibreMap B ON C.PRODUCT_CODE=B.PRODUCT AND C.INV_OPTION=B.INVESTMENT_OPTION ORDER BY GL_EQAL_PAS_C,PRODUCT_CODE,TRANS_CODE;SELECT a.RUN_NO, CONVERT(VARCHAR(11),a.DATA_DATE,106) AS DATA_DATE, 'L400' as System, g.[Stat Fund],  t.INV_OPTION,T.PAS_KEY,ROUND(t.AMOUNT,2) AS UP_Amount FROM ThreeWayRec.dbo.app_run_no AS a INNER JOIN ThreeWayRec.dbo.transref_updata AS t ON a.RUN_NO = t.RUN_NO INNER JOIN UnitLinked.dbo.system AS s ON t.SOURCE_SYSTEM = s.sysSystemNo INNER JOIN UnitLinked.dbo.lookup_investment_option AS l ON l.OPTION_CODE =  CASE WHEN LEFT(t .INV_OPTION, 1) = 'F' AND LEN(t .INV_OPTION)= 7 THEN SUBSTRING(t .INV_OPTION, 2, 6) ELSE LEFT(t .INV_OPTION, 6) END INNER JOIN UnitLinked.dbo.lookup_hiport2psoft AS h ON l.HIPORT_PORTFOLIO = h.Hiport_Portfolio INNER JOIN UnitLinked.dbo.lookup_gl_ledger AS g ON h.Psoft_BusUnit = g.Ledger WHERE (a.DATA_DATE = '2015-10-28') AND (t.PAS_KEY IS NOT NULL) AND (t.EXCLUDED = 0) 
            AND (t.SOURCE_system =8)AND (l.SOURCE is not null) and [STAT FUND]<>'CpGT'order by [stat fund]";
		return mysql;
	}

	public static string GetConnectionString()
	{
		return @"Data Source=vaunsw302\sqlpro_ciapps2;Integrated Security=true;" +
			"Initial Catalog=ThreeWayRec; Asynchronous Processing=true";
	}//DESKTOP-E80R7DQ\SQL_MAIN

	public static string MyExportDir()
	{
		string cwd = System.Reflection.Assembly.GetExecutingAssembly().Location;
		string projectName = "Wpf_ManagementSummary";  //YOUR PROJECT NAME HERE
		string solutionPath = cwd.Replace(projectName + "\\bin\\Debug", "");
		//    return solutionPath;

		//return @"C:\Users\samtran\Downloads\Delete\ExcelWPF.xlsx";
		return @"T:\delete\bb\ExcelWPF.xlsx";

	}

	public static string MyEmailSQL()
	{
		return @"Select Email_Address,CC from [vaunsw302\sqlpro_ciapps2].ThreeWayRec.dbo.lookup_email_recipients_detail";
	}

}

