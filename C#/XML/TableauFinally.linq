<Query Kind="Program" />

void Main()
{
	//http://stackoverflow.com/questions/2340411/use-linq-to-xml-with-xml-namespaces

	string theXml = System.IO.File.ReadAllText(@"C:\LinqPad_Queries\C#\TableauAPI\data.xml");

//	XDocument xDoc = XDocument.Parse(theXml);

	XNamespace ns = "http://tableau.com/api";

	//http://stackoverflow.com/questions/7227193/xelement-descendants-doesnt-work-with-namespace
	XElement xxElement = XElement.Parse(theXml);
	xxElement.Dump();
	var h = xxElement.Descendants().Where(e => e.Name.LocalName == "user"); //http://stackoverflow.com/questions/7227193/xelement-descendants-doesnt-work-with-namespace
	h.Dump();
	
	foreach (var element in h)
	{
		Console.WriteLine(element.Attribute("id").Value +"__"+ element.Attribute("name").Value);
	}
	


}

// Define other methods and classes here