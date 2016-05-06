<Query Kind="Program" />

void Main()
{
//	DateTime dt = DateTime.Parse("23/12/2010");
//	Console.WriteLine(dt);
//	string s2 = dt.ToString("dd-MM-yyyy");

	DateTime RDate = DateTime.Parse("23/03/2016");
	Console.WriteLine(RDate);

	DateTime xDate = GetDate();
	Console.WriteLine(xDate);
	//string cxDate=xDate.ToShortDateString();
	string cxDate=xDate.ToString("yyyy-MM-dd");
	Console.WriteLine(cxDate);
}

private static DateTime GetDate()
{
	////Console.WriteLine(MyCalendar.DisplayDate);
	//MyCalendar.DisplayMode = CalendarMode.Month;
	DateTime today = System.DateTime.Today;
	int iday = (int)DateTime.Now.DayOfWeek;
	DateTime yesterday = today.AddDays(-1);
	//  MyCalendar.DisplayDate  = yesterday;
	//MyCalendar.SelectedDate = yesterday;
	//MyCalendar.IsTodayHighlighted = false;

	switch (iday)
	{
		case 0:
			//MyCalendar.SelectedDate = today.AddDays(-2);
			return today.AddDays(-2);
		case 1:
			//MyCalendar.SelectedDate = today.AddDays(-3);
			return today.AddDays(-3);
		case 2:
			//MyCalendar.SelectedDate = today.AddDays(-1);
			return today.AddDays(-1);
		case 3:
			//MyCalendar.SelectedDate = today.AddDays(-1);
			return today.AddDays(-1);
		case 4:
			//MyCalendar.SelectedDate = today.AddDays(-1);
			return today.AddDays(-1);
		case 5:
			//MyCalendar.SelectedDate = today.AddDays(-1);
			return today.AddDays(-1);
		case 6:
			//MyCalendar.SelectedDate = today.AddDays(-1);
			return today.AddDays(-1);
		default:
			return today.AddDays(-1);
	}
	// DateTimePicker1.Value.ToString("yyyy/MM/dd").Replace("/", "-")
}
