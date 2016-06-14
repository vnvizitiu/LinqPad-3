<Query Kind="Program" />

void Main()
{
//http://stackoverflow.com/questions/2340411/use-linq-to-xml-with-xml-namespaces
	string theXml =  @"<Response xmlns=""http://myvalue.com""><Result xmlns:a=""http://schemas.datacontract.org/2004/07/My.Namespace"" 
	xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><a:TheBool>true</a:TheBool><a:TheId>1</a:TheId></Result></Response>";
					 
	
	theXml.Dump();
	//string theXml = @"true1";

	XDocument xmlElements = XDocument.Parse(theXml);
	XNamespace ns = "http://myvalue.com";
	XNamespace nsa = "http://schemas.datacontract.org/2004/07/My.Namespace";
	var elements = from data in xmlElements.Descendants(ns + "Result")
				   select new
				   {
					   TheBool = (bool)data.Element(nsa + "TheBool"),
					   TheId = (int)data.Element(nsa + "TheId"),
				   };

	foreach (var element in elements)
	{
		Console.WriteLine(element.TheBool);
		Console.WriteLine(element.TheId);
	}
}

// Define other methods and classes here