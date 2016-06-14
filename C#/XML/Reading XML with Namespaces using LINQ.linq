<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
  <Namespace>System.Xml.XPath</Namespace>
</Query>

//http://lakenine.com/reading-xml-with-namespaces-using-linq/ 
	class GetNamesWithXElement
	{

		static void Main(string[] args)
		{

			// The sample XML
			string sampleXML = String.Concat(
				"<env:Envelope xmlns:env=\"http://schemas.xmlSOAP.org/SOAP/envelope/\"",
				"     xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"",
				"     xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">",
				" <env:Body>",
				"  <aaa:PlayerList xmlns:aaa=\"http://lakenine.com/playerInfo\">",
				"   <Player id=\"778-2\">",
				"    <Name>Fred Jones</Name>",
				"   </Player>",
				"   <Player id=\"463-9\">",
				"    <Name>David Arias</Name>",
				"   </Player>",
				"  </aaa:PlayerList>",
				" </env:Body>",
				"</env:Envelope>");
			
			sampleXML.Dump();
			// Open an XML reader and populate with the sample XML. The
			// sample XML is in a string, and XmlReader.Create requires a
			// stream, so wrap the string with a StringReader.
			XmlReader reader = XmlReader.Create(new StringReader(sampleXML));

			// Create a XML Name Table. The easiest way is start with the one
			// the XmlReader gives us.
			System.Xml.XmlNameTable nameTable = reader.NameTable;

			// Create an XML Namespace Manager. It needs a name table.
			System.Xml.XmlNamespaceManager namespaceManager = new System.Xml.XmlNamespaceManager(nameTable);

			// Add the "env" and "aaa" namespaces to the XML Namespace Manager.
			namespaceManager.AddNamespace("env", "http://schemas.xmlSOAP.org/SOAP/envelope/");
			namespaceManager.AddNamespace("aaa", "http://lakenine.com/playerInfo");

			// Pull the default XElement from the XML Reader; this gives us
			// the root document element (env:Envelope).
			XElement doc = XElement.Load(reader);

			// Finally, we're ready to select the player names.
			var playerNames = from pn
							  in doc.XPathSelectElements("env:Body/aaa:PlayerList/Player/Name", namespaceManager)
							  select (string)pn;
			foreach (string pn in playerNames)
			{
				Console.WriteLine("Player name: " + pn);
			}
		}
	}