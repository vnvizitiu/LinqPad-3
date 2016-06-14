<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\SMDiagnostics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Utilities.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

 

    void Main()
	{
//string xml = Path.Combine(@"C:\LinqPad_Queries\C#\TableauAPI\multiHeadXML.xml");

 
//	doc.Load(@"C:\LinqPad_Queries\C#\TableauAPI\multiHeadXML.xml");
	 string fileName=System.IO.File.ReadAllText(@"C:\LinqPad_Queries\C#\TableauAPI\multiHeadXML.xml");

	LastRss data = new LastRss();
	XmlSerializer serializer = new XmlSerializer(typeof(LastRss));
	System.IO.TextReader reader = new System.IO.StringReader(fileName);
	fileName.Dump();

	try
	{
		object o = serializer.Deserialize(reader);
		data = (LastRss)o;
		data.Dump();
		 
	 
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.ToString());
		throw;
	}

}




public class LastChannel
{
	[XmlElement("title")]
	public string title { get; set; }
	[XmlElement("description")]
	public string description { get; set; }
	[XmlElement("date", Namespace = "http://purl.org/dc/elements/1.1/")]
	public string date { get; set; }
	[XmlElement("updateBase", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
	public string updateBase { get; set; }
	[XmlElement("updatePeriod", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
	public string updatePeriod { get; set; }
	[XmlElement("updateFrequency", Namespace = "http://purl.org/rss/1.0/modules/syndication/")]
	public int updateFrequency { get; set; }
}

[XmlRoot("RDF", Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
public class LastRss
{
	[XmlElement("channel", Namespace = "http://purl.org/rss/1.0/")]
	public LastChannel channel { get; set; }
}
//[XmlElement("channel", Namespace = "http://purl.org/rss/1.0/")]
//public LastChannel channel { get; set; }