<Query Kind="Program" />

////Encapsulation Using .NET Properties
// Note Visual Studio provides the prop code snippet. If you type “prop” and press the Tab key twice, the IDE will
//generate starter code for a new automatic property! You can then use the Tab key to cycle through each part of
//the definition to fill in the details. Give it a try!
void Main()
{
	Console.WriteLine("***** Fun with Encapsulation *****\n");
Employee emp = new Employee("Marvin", 456, 30000);
 
// Set and get the Name property.
emp.Name = "Marv";
Console.WriteLine("Employee is named: {0}", emp.Name);

}
class Employee
{

public Employee(string name, int id, float pay)
:this(name, 0, id, pay){}
public Employee(string name, int age, int id, float pay)
{
empName = name;
empID = id;
empAge = age;
currPay = pay;
}

// Field data.
private string empName;
private int empID;
private float currPay;
private int empAge;
// Properties!
public string Name
{
get { return empName; }
set
{
if (value.Length > 15)
Console.WriteLine("Error! Name must be less than 16 characters!");
else
empName = value;
}
}
// We could add additional business rules to the sets of these properties;
// however, there is no need to do so for this example.
public int ID
{
get { return empID; }
set { empID = value; }
}
public float Pay
{
get { return currPay; }
set { currPay = value; }
}

}