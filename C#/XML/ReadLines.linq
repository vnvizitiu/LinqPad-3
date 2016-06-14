<Query Kind="Program" />

//https://support.microsoft.com/en-au/kb/307548
void Main()
 {
 
	XmlTextReader reader = new XmlTextReader(@"C:\LinqPad_Queries\C#\TableauAPI\data.xml");

	while (reader.Read())
	{
		switch (reader.NodeType)
		{
			case XmlNodeType.Element: // The node is an element.
				Console.Write("<" + reader.Name);

				while (reader.MoveToNextAttribute()) // Read the attributes.
					Console.Write(" " + reader.Name + "='" + reader.Value + "'");
				Console.WriteLine(">");
				break;
			case XmlNodeType.Text: //Display the text in each element.
				Console.WriteLine(reader.Value);
				break;
			case XmlNodeType.EndElement: //Display the end of the element.
				Console.Write("</" + reader.Name);
				Console.WriteLine(">");
				break;
		}
	}



}

static DataTable ParseXML(string xmlString)
{
	DataSet ds = new DataSet();
	byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
	Stream memory = new MemoryStream(xmlBytes);
	ds.ReadXml(memory);
	return ds.Tables[0];
}
// Define other methods and classes here
