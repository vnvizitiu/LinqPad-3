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
	string fileName = Path.Combine(@"C:\LinqPad_Queries\C#\TableauAPI\data.xml");
	// read file
	List<tsResponseUser> users;
	using (var reader = new StreamReader(fileName))
	{
		XmlSerializer deserializer = new XmlSerializer(typeof(List<tsResponseUser>), //user_list  Users.user_listUser
			new XmlRootAttribute("ts_Response"));
		users = (List<tsResponseUser>)deserializer.Deserialize(reader);   //user_list  Users.user_listUser
	}

	users.Dump();
	foreach (var element in users)
	{
		Console.WriteLine(element.name);
	}


}

[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
public class AllUsers
{
	[XmlArrayItem("user", Namespace = "http://tableau.com/api")]
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
//[XmlElement("id", Namespace = "http://tableau.com/api")]
//[XmlArrayItem("id", Namespace = "http://tableau.com/api")]
[XmlArrayItem("id")]
	 [System.Xml.Serialization.XmlAttributeAttribute()]
//	[XmlAttribute("id")]
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
	[XmlArrayItem("name", Namespace = "http://tableau.com/api")]
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
	[XmlArrayItem("siteRole", Namespace = "http://tableau.com/api")]
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
	[XmlArrayItem("lastLogin", Namespace = "http://tableau.com/api")]
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
	[XmlArrayItem("lastLoginSpecified", Namespace = "http://tableau.com/api")]
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
	[XmlArrayItem("externalAuthUserId", Namespace = "http://tableau.com/api")]
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