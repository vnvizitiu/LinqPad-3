<Query Kind="Program" />

void Main()
{
 	List<Run> runs=new List<Run>();
		var result =
		from e in Error_logs
		select e; //e. error_date, run_no, e.type ;
	// 
//		foreach (var element in result)
//		{
//			Console.WriteLine(element.RUN_NO);
//
//			
//		}
		
		foreach (var element in result)
		{
			Console.WriteLine(element.TYPE, element.RUN_NO, element.ERROR_DATE);
		}
	
		
			//Select 	e.System_No, e.error_date, run_no, e.type ;
	
	
	
	
	
		 
 

	
//	
//	runs.Add(f);
//	runs.Add(f1);
	
}


 class Run
   
{
 public string FirstName { get; set; }
 public string LastName {get; set;}
 
 public Run(string fname, string lname)
 {
 FirstName=fname;
 LastName=lname;
 
 }
 
 
  public override string ToString()
        {
            return "ID: " + FirstName + "   Name: " + LastName;
        }

}

// Define other methods and classes here

// Define other methods and classes here
