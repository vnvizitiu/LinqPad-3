<Query Kind="Program" />

void Main()
{
	//this below is wrong and why interface is needed	
}
public class PersonA { } 
public class EmployeeA : PersonA {   }
public class StampCollectorA : PersonA {   } 
public class EmployeeStampCollectorA : EmployeeA { }
// Define other methods and classes here


//this below is correct way
public interface IEmployee {  } 
public interface IStampCollector {  } 
public class Person { }
public class Employee : Person, IEmployee { }
public class StampCollector : Person, IStampCollector { } 
public class EmployeeStampCollector : Employee, IStampCollector