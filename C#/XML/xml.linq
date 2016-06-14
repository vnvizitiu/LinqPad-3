<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Linq</Namespace>
</Query>

public static class MyExtensions //https://blogs.msdn.microsoft.com/ericwhite/2008/12/22/convert-xelement-to-xmlnode-and-convert-xmlnode-to-xelement/
{
	public static XElement GetXElement(this XmlNode node)
	{
		XDocument xDoc = new XDocument();
		using (XmlWriter xmlWriter = xDoc.CreateWriter())
			node.WriteTo(xmlWriter);
		return xDoc.Root;
	}

	public static XmlNode GetXmlNode(this XElement element)
	{
		using (XmlReader xmlReader = element.CreateReader())
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlReader);
			return xmlDoc;
		}
	}
}

class Program
{
	static void Main(string[] args)
	{
		XElement e = new XElement("Root",
			new XElement("Child",
				new XAttribute("Att", "1")
			)
		);

		XmlNode xmlNode = e.GetXmlNode();
		Console.WriteLine(xmlNode.OuterXml);

		XElement newElement = xmlNode.GetXElement();
		Console.WriteLine(newElement);
	}
}
