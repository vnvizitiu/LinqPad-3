<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
	cReport myReport= new cReport();
	 DateTime RDate = DateTime.Parse("10/02/2012");
	List<cReport.Summary> myList= myReport.GetReport(RDate);
	
	foreach (var element in myList)
	{
		Console.WriteLine(element.PasAmt);
	}
	
	
	
	
}


public  class cReport
{
	public List<cReport.Summary> _Summary;
	public List<cReport.Details> _Detail;
	public List<Summary> GetReport(DateTime RDate)
	{
		DataTable dt = new DataTable();
		SqlConnection connection = null;
		connection = new System.Data.SqlClient.SqlConnection(@"Data Source=DESKTOP-E80R7DQ\SQL_MAIN;Integrated Security=true;" +
		   "Initial Catalog=ThreeWayRec; Asynchronous Processing=true");
		try
		{
			using (connection)
			{
				SqlParameter myParam = new SqlParameter();
				myParam.ParameterName = "@rDate";
				//myParam.DbType=DbType.Int16;;
				myParam.SqlDbType = SqlDbType.Date;

				myParam.Value = RDate;
				SqlCommand command = new SqlCommand();
				SqlDataAdapter Adpt = default(SqlDataAdapter); //new
				Adpt = new SqlDataAdapter(command); //new
				command.CommandText = "rec_M_Summary"; //proc name
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(myParam);
				//command.Parameters.AddWithValue(8);
				command.Connection = connection;
				//DataTable dt = new DataTable();
				DataSet ds = new DataSet();

				connection.Open();
				Adpt.Fill(ds);
				#region Summary
				var dtSummary = ds.Tables[0].AsEnumerable().ToList().Select(r => new cReport.Summary
				{
					RunNo = r.Field<int>("Run_No"),
					SystemNo = r.Field<string>("System_Name"),
					DataDate = r.Field<DateTime>("Data_Date"),
					PasAmt = r.Field<decimal>("PAS_Amount"),
					UpAmt = r.Field<decimal>("UP_Amount"),
					DollDiff = r.Field<decimal>("Dollar_Diff"),
					PasUnit = r.Field<decimal>("PAS_Units"),
					UpUnit = r.Field<decimal>("UP_Units"),
					UnitDiff = r.Field<decimal>("Unit_Diff"),
					Comments = r.Field<string>("Total_Comments")
				});
				_Summary = dtSummary.ToList();
				#endregion Summary
				#region Calibre
				var dtDetail_c = ds.Tables[1].AsEnumerable().ToList().Select(r => new cReport.Details
				{
					RunNo = r.Field<int>("Run_No"),
					DataDate = r.Field<DateTime>("Data_Date"),
					SystemNo = r.Field<string>("System"),
					StatFund = r.Field<string>("iFund"),
					SourceDB = r.Field<string>("S_Database"),
					PasAmt = r.Field<double>("PAS_REC"),
					UpAmt = r.Field<double>("UP_Rec"),
					Calc_Diff = r.Field<double>("REC_DIFF"),
					PAS_Adj = r.Field<double>("PAS_ADJUST")
					,
					UP_Adj = r.Field<double>("UP_ADJUST"),
					Adj_Diff = r.Field<double>("ADJUSTED_DIFF")
				});
				var myLDetail = from fd in dtDetail_c select fd;
				_Detail = dtDetail_c.ToList(); //this
				#endregion Calibre
				#region L400
				var dtDetail_l = ds.Tables[2].AsEnumerable().ToList().Select(r => new cReport.Details
				{
					RunNo = r.Field<int>("Run_No"),
					DataDate = r.Field<DateTime>("Data_Date"),
					SystemNo = r.Field<string>("System"),
					StatFund = r.Field<string>("iFund"),
					SourceDB = r.Field<string>("S_Database"),
					PasAmt = r.Field<double>("PAS_REC"),
					UpAmt = r.Field<double>("UP_Rec"),
					Calc_Diff = r.Field<double>("REC_DIFF"),
					PAS_Adj = r.Field<double>("PAS_ADJUST"),
					UP_Adj = r.Field<double>("UP_ADJUST"),
					Adj_Diff = r.Field<double>("ADJUSTED_DIFF")
				});
				var myL400Detail = from fd in dtDetail_l select fd;
				List<cReport.Details> _temp = dtDetail_l.ToList(); //this
				_Detail.AddRange(_temp);
				#endregion
				#region Carole
				var pas = (from l in _Detail where l.StatFund == "UL" select l.PasAmt).Sum();
				var up = (from l in _Detail where l.StatFund == "UL" select l.UpAmt).Sum();
				var pasadj = (from l in _Detail where l.StatFund == "UL" select l.PAS_Adj).Sum();
				var upadj = (from l in _Detail where l.StatFund == "UL" select l.UP_Adj).Sum();
				cReport.Details UL = default(cReport.Details);
				UL = new cReport.Details
				{
					RunNo = 0,
					DataDate = RDate,
					SystemNo = "Calibre/L400",
					SourceDB = "N/A",
					StatFund = "UL Total",
					PasAmt = pas,
					UpAmt = up,
					PAS_Adj = pasadj,
					UP_Adj = upadj,
					Calc_Diff = pas - up,
					Adj_Diff = pasadj - upadj
				};
				_Detail.Add(UL);

				var pascpt = (from l in _Detail where l.StatFund == "CpGt" select l.PasAmt).Sum();
				var upcpt = (from l in _Detail where l.StatFund == "CpGt" select l.UpAmt).Sum();
				var pasadjcpt = (from l in _Detail where l.StatFund == "CpGt" select l.PAS_Adj).Sum();
				var upadjcpt = (from l in _Detail where l.StatFund == "CpGt" select l.UP_Adj).Sum();
				cReport.Details cpgt = default(cReport.Details);
				cpgt = new cReport.Details
				{
					RunNo = 0,
					DataDate = RDate,
					SystemNo = "Calibre/L400",
					SourceDB = "N/A",
					StatFund = "CpGt Total",
					PasAmt = pascpt,
					UpAmt = upcpt,
					PAS_Adj = pasadjcpt,
					UP_Adj = upadjcpt,
					Calc_Diff = pascpt - upcpt,
					Adj_Diff = pasadjcpt - upadjcpt
				};
				_Detail.Add(cpgt);
				#endregion
				Console.WriteLine(ds.Tables.Count.ToString());
				ds.Dispose();
				return _Summary;


			}


		}
		catch (Exception)
		{
			throw;
		}




	}
	public class Summary : IComparable<Summary>, IEquatable<Summary>
	{
		public int RunNo { get; set; }
		public string SystemNo { get; set; }
		public DateTime DataDate { get; set; }
		public decimal PasAmt { get; set; }
		public decimal UpAmt { get; set; }
		public decimal DollDiff { get; set; }
		public decimal PasUnit { get; set; }
		public decimal UpUnit { get; set; }
		public decimal UnitDiff { get; set; }
		public string Comments { get; set; }
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Summary objAsPart = obj as Summary;
			if (objAsPart == null)
			{
				return false;
			}
			else
			{
				return Equals(objAsPart);
			}
		}
		public override int GetHashCode()
		{
			return RunNo;
		}
		public bool Equals(Summary other)
		{
			if (other == null)
			{
				return false;
			}
			return (this.SystemNo.Equals(other.RunNo));
		}
		public override string ToString()
		{
			return Convert.ToString("ID: " + SystemNo + "   Name: ") + SystemNo;
		}
		public int CompareTo(Summary comparePart)
		{
			// A null value means that this object is greater. 
			if (comparePart == null)
			{
				return 1;
			}
			else
			{
				return this.SystemNo.CompareTo(comparePart.RunNo);
			}
		}
		public int SortByNameAscending(string name1, string name2)
		{
			return name1.CompareTo(name2);
		}
	}

	public class Details : Summary
	{
		// public string StatFund { get; set; }
		public double Calc_Diff { get; set; }
		public string StatFund { get; set; }
		public string SourceDB { get; set; }
		public double PAS_Adj { get; set; }
		public double UP_Adj { get; set; }
		public double Adj_Diff { get; set; }
		public new double PasAmt { get; set; }
		public new double UpAmt { get; set; }
		public new double DollDiff { get; set; }

	}
}
