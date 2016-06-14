<Query Kind="Program" />

void Main()
{
//C:\LinqPad_Queries\C#\TableauAPI\data.xml

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

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tableau.com/api")]
public partial class tsResponseUser
{

	private string idField;

	private string nameField;

	private string siteRoleField;

	private System.DateTime lastLoginField;

	private bool lastLoginFieldSpecified;

	private string externalAuthUserIdField;

	/// <remarks/>
	[System.Xml.Serialization.XmlAttributeAttribute()]
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
	[System.Xml.Serialization.XmlAttributeAttribute()]
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
	[System.Xml.Serialization.XmlAttributeAttribute()]
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
	[System.Xml.Serialization.XmlAttributeAttribute()]
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
	[System.Xml.Serialization.XmlIgnoreAttribute()]
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
	[System.Xml.Serialization.XmlAttributeAttribute()]
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
// Define other methods and classes here
