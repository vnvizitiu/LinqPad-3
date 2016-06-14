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
            string fileName = Path.Combine(@"C:\Stash\XMLserialization_console\XMLserialization_console\userXML.xml");

		//		var dcs = new XmlSerializer(typeof(Users.user_listUser));
		//		FileStream fs = new FileStream(fileName, FileMode.Open);
		//		XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
		//
		//		Users.user_listUser _users = (Users.user_listUser)dcs.Deserialize(reader);//.ReadObject(reader);
		//		reader.Close();
		//		fs.Close();


		// read file
		List<Users.user_listUser> users;
		using (var reader = new StreamReader(fileName))
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Users.user_listUser>),
				new XmlRootAttribute("user_list"));
			users = (List<Users.user_listUser>)deserializer.Deserialize(reader);
		}

		users.Dump();
		foreach (var element in users)
		{
			Console.WriteLine(element.name);
		}

		//http://stackoverflow.com/questions/608110/is-it-possible-to-deserialize-xml-into-listt
		//http://stackoverflow.com/questions/608110/is-it-possible-to-deserialize-xml-into-listt

		using (var writer = new FileStream(fileName, FileMode.Create))
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<Users.user_listUser>),
				new XmlRootAttribute("user_list"));
			List<Users.user_listUser> list = new List<Users.user_listUser>();
			list.Add(new Users.user_listUser { id = 1, name = "Joe" });
			list.Add(new Users.user_listUser { id = 2, name = "John" });
			list.Add(new Users.user_listUser { id = 3, name = "SamTran" });
			list.Add(new Users.user_listUser { id = 8, name = "RaymondTran" });
			ser.Serialize(writer, list);
			Console.WriteLine(ser.ToString());
		}
	}
}

public class Users
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class user_list
	{

		private user_listUser[] userField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("user")]
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
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class user_listUser
	{

		private byte idField;

		private string nameField;

		/// <remarks/>
		public byte id
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