<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/670563/linq-to-read-xml
{
	 
 
	XDocument xdoc=XDocument.Load(@"C:\LinqPad_Queries\Files\TableauUsersAPI3.xml");
	//xdoc.Dump();
	var lv1s = xdoc.Root.Descendants();
	var lvs = lv1s.SelectMany(l =>
		 new string[] { l.Attribute("id").Value ,l.Attribute("name").Value, l.Attribute("siteRole").Value}
 
		);
foreach (var lv in lvs)
	{
		Console.WriteLine(lv);
	}

}

// Define other methods and classes here