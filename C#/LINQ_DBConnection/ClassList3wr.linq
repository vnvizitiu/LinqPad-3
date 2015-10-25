<Query Kind="Program">
  <Connection>
    <ID>700055bf-cade-4221-9ea3-2ee8255fed1a</ID>
    <Persist>true</Persist>
    <Server>WIN-90API3QKTDS</Server>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
 		var result =
		from e in Error_logs
		select e; //e. error_date, run_no, e.type ;
 		
		List<Run> _runs=new List<Run>();
		foreach (var element in result)
		{
			//Console.WriteLine(element.TYPE, element.RUN_NO, element.ERROR_DATE);
			Run r =new Run{Type=element.TYPE, RunNo=element.RUN_NO.Value, ErrorDate=element.ERROR_DATE.Value};
			_runs.Add(r);
		}
		
		foreach (Run x in _runs)
		{
			Console.WriteLine(x.Type+"_"+x.RunNo+"_"+x.ErrorDate);
		}
 	 	
		
}


public class Run
{
public string Type { get; set; }
public int  RunNo { get; set; }
public DateTime   ErrorDate { get; set; }
}