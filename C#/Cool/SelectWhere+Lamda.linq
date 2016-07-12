<Query Kind="Program" />

void Main()
{	
	string cccSprint = null;
	string sprintA="com.atlassian.greenhopper.service.sprint.Sprint@65b73226[rapidViewId=625,state=CLOSED,name=BIDA 2016 - 06,startDate=2016-06-01T16:43:22.100+10:00,endDate=2016-06-29T16:43:00.000+10:00,completeDate=2016-06-29T10:17:03.404+10:00,sequence=1476,id=1476]";
	string[] ccSprint = sprintA.Split(',');
	
	
		cccSprint = ccSprint.Where(part => part.Contains("state") | part.Contains("name"))
			.Aggregate<string, string>(null, (current, part) => part + " ,  " + current );
	
	Console.Write(cccSprint);
	Console.Write(">>>>>>>>>>>>>>>>>");
	Console.WriteLine(cccSprint.Remove(cccSprint.Length - 3));
	Console.WriteLine(cccSprint.Remove(cccSprint.Length - 3).Replace("name=",""));

	foreach (string part in ccSprint)
	{
		if (part.Contains("state") | part.Contains("name"))
		{
			cccSprint = part + " _ " + cccSprint;
		}
	}

//	Console.Write(cccSprint);
//	Console.Write(">>>>>>>>>>>>>>>>>");
//	Console.WriteLine(cccSprint.Remove(cccSprint.Length - 3));

	foreach (string part in ccSprint.Where(part => part.Contains("state") | part.Contains("name"))) //test 
	{
		cccSprint = part + "    " + cccSprint + " , ";
	}
}

// Define other methods and classes here
