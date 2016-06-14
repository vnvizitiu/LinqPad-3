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
	 string fileName=System.IO.File.ReadAllText(@"C:\LinqPad_Queries\C#\TableauAPI\data.xml");

	var data = new AllUsers();
	XmlSerializer serializer = new XmlSerializer(typeof(AllUsers));
	System.IO.TextReader reader = new System.IO.StringReader(fileName);
 

	try
	{
		object o = serializer.Deserialize(reader);
		data = (AllUsers)o;
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
	[XmlElement("user", Namespace = "http://purl.org/rss/1.0/")]
	public LastChannel channel { get; set; }
}


/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tableau.com/api")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tableau.com/api", IsNullable = false)]
public partial class tsResponse
{

	private tsResponsePagination paginationField;

	private tsResponseUser[] usersField;

	/// <remarks/>
	public tsResponsePagination pagination
	{
		get
		{
			return this.paginationField;
		}
		set
		{
			this.paginationField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlArrayItemAttribute("user", IsNullable = false)]
//	[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
	public tsResponseUser[] users
	{
		get
		{
			return this.usersField;
		}
		set
		{
			this.usersField = value;
		}
	}
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tableau.com/api")]
public partial class tsResponsePagination
{

	private byte pageNumberField;

	private byte pageSizeField;

	private ushort totalAvailableField;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public byte pageNumber
	{
		get
		{
			return this.pageNumberField;
		}
		set
		{
			this.pageNumberField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public byte pageSize
	{
		get
		{
			return this.pageSizeField;
		}
		set
		{
			this.pageSizeField = value;
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
	public ushort totalAvailable
	{
		get
		{
			return this.totalAvailableField;
		}
		set
		{
			this.totalAvailableField = value;
		}
	}
}

[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
public class AllUsers
{
	[XmlElement("users", Namespace = "http://tableau.com/api")]
	public tsResponseUser SamUser { get; set; }
}
/// <remarks/>
//[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tableau.com/api", IsNullable = false)]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tableau.com/api")]
[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
public partial class tsResponseUser
{

	private string idField;

	private string nameField;

	private string siteRoleField;

	private System.DateTime lastLoginField;

	private bool lastLoginFieldSpecified;

	private string externalAuthUserIdField;

	/// <remarks/>
	//	[XmlElement("id", Namespace = "http://tableau.com/api")]
	[System.Xml.Serialization.XmlAttributeAttribute()]
	//[XmlAttribute("id")]
	public string id
	{
		get
		{
			return this.idField;
		}
		set
		{
			this.idField = value;
		}
	}

	/// <remarks/>
	[XmlElement("name", Namespace = "http://tableau.com/api")]
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string name
	{
		get
		{
			return this.nameField;
		}
		set
		{
			this.nameField = value;
		}
	}

	/// <remarks/>
	[XmlElement("siteRole", Namespace = "http://tableau.com/api")]
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
	public string siteRole
	{
		get
		{
			return this.siteRoleField;
		}
		set
		{
			this.siteRoleField = value;
		}
	}

	/// <remarks/>
	//	[System.Xml.Serialization.XmlAttributeAttribute()]
	[XmlElement("lastLogin", Namespace = "http://tableau.com/api")]
	public System.DateTime lastLogin
	{
		get
		{
			return this.lastLoginField;
		}
		set
		{
			this.lastLoginField = value;
		}
	}

	/// <remarks/>
	//	[System.Xml.Serialization.XmlIgnoreAttribute()]
	[XmlElement("lastLoginSpecified", Namespace = "http://tableau.com/api")]
	public bool lastLoginSpecified
	{
		get
		{
			return this.lastLoginFieldSpecified;
		}
		set
		{
			this.lastLoginFieldSpecified = value;
		}
	}

	/// <remarks/>
	//[System.Xml.Serialization.XmlAttributeAttribute()]
	[XmlElement("externalAuthUserId", Namespace = "http://tableau.com/api")]
	public string externalAuthUserId
	{
		get
		{
			return this.externalAuthUserIdField;
		}
		set
		{
			this.externalAuthUserIdField = value;
		}
	}
}