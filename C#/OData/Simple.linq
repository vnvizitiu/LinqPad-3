<Query Kind="Program">
  <Connection>
    <ID>cdd3a34d-7493-4a77-9af2-a502f8f67465</ID>
    <Persist>true</Persist>
    <Driver Assembly="OData4DynamicDriver" PublicKeyToken="ac4f2d9e4b31c376">OData4.OData4DynamicDriver</Driver>
    <Server>http://services.odata.org/v4/TripPinServiceRW/</Server>
  </Connection>
</Query>

void Main()
{//need to use connection (url is not used)
	var context = new DefaultContainer(new Uri("http://services.odata.org/v4/TripPinServiceRW/"));
	var people = context.People.Execute();
	var a=context.Airlines.ExecuteAsync();
	people.Dump();
	a.Dump();
}
 