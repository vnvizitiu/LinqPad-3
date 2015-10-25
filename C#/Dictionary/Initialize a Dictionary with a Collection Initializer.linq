<Query Kind="Program" />

void Main() //https://msdn.microsoft.com/en-us/library/bb531208.aspx
{
	CollInit c=new CollInit();
 
	
	
 
	
}
class StudentName
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int ID { get; set; }
}

class CollInit
{	
	public string name="sam";
	 Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
	{
		{ 111, new StudentName {FirstName="Sachin", LastName="Karnik", ID=211}},
		{ 112, new StudentName {FirstName="Dina", LastName="Salimzianova", ID=317}},
		{ 113, new StudentName {FirstName="Andy", LastName="Ruth", ID=198}}
	};

}
// Define other methods and classes here
