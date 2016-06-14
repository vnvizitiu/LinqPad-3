<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\SMDiagnostics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

class Program
    {
        static void Main(string[] args)
        {
            string fileName = Path.Combine(@"C:\LinqPad_Queries\C#\TableauAPI\data.xml");
		// read file
		List<Users.user_listUser> users;
		using (var reader = new StreamReader(fileName))
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Users.user_list>), //user_list  Users.user_listUser
				new XmlRootAttribute("ts_Response"));
			users = (List<Users.user_listUser>)deserializer.Deserialize(reader);   //user_list  Users.user_listUser
		}

		users.Dump();
		foreach (var element in users)
		{
			Console.WriteLine(element.name);
		}

		//http://stackoverflow.com/questions/608110/is-it-possible-to-deserialize-xml-into-listt
		//http://stackoverflow.com/questions/608110/is-it-possible-to-deserialize-xml-into-listt

	}
}
[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
public class Users
{
	/// <remarks/>
//	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
///	[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]	
	public partial class user_list
	{

		private user_listUser[] userField;

		/// <remarks/>
	//	[System.Xml.Serialization.XmlElementAttribute("user")]
	[XmlElement("users", Namespace = "http://tableau.com/api")]
		public user_listUser[] user
		{
			get
			{
				return this.userField;
			}
			set
			{
				this.userField = value;
			}
		}
	}

	/// <remarks/>
	[XmlRoot("tsResponse", Namespace = "http://tableau.com/api")]
//	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	
	public partial class user_listUser
	{

		private string idField;

		private string nameField;

		/// <remarks/>
		[XmlElement("id", Namespace = "http://tableau.com/api")]
		[System.Xml.Serialization.XmlAttributeAttribute()] //sam
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
		//	[System.Xml.Serialization.XmlAttributeAttribute()] //sam
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
	}


}