<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/670563/linq-to-read-xml
{
	//Create XML payload for the api call.  
	using (XmlWriter loginxml = XmlWriter.Create("login.xml"))
	{
		loginxml.WriteStartDocument();
		loginxml.WriteStartElement("tsRequest");
		loginxml.WriteStartElement("credentials");
		loginxml.WriteAttributeString("name", "samtran");
		loginxml.WriteAttributeString("password", "Raymond123");
		loginxml.WriteStartElement("site");
		//                loginxml.WriteAttributeString("contentUrl", "t/smg-poc");  
		loginxml.WriteAttributeString("contentUrl", "WMFinCentre");
		loginxml.WriteEndElement();
		loginxml.WriteEndElement();
		loginxml.WriteEndElement();
		loginxml.WriteEndDocument();
	}
	XElement myxml = XElement.Load("login.xml"); // not  needed, just alternative
	//myxml.Dump();
	XDocument xdoc=XDocument.Load("login.xml");
	xdoc.Dump();
	var lv1s = xdoc.Root.Descendants("credentials");
	var lvs = lv1s.SelectMany(l =>
		 new string[] { l.Attribute("name").Value ,l.Attribute("password").Value}
		 .Union(
			 l.Descendants("site")
			 .Select(l2 => l2.Attribute("contentUrl").Value)
		  )
		);
	foreach (var lv in lvs)
	{
		Console.WriteLine(lv);
	}

}

// Define other methods and classes here