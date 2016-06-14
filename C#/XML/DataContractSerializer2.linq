<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\SMDiagnostics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
</Query>

void Main()
{
	//http://stackoverflow.com/questions/16943176/how-to-deserialize-xml-using-datacontractserializer--doesnt' work
	string fileName = Path.Combine(@"C:\LinqPad_Queries\C#\TableauAPI\tsResponse.xml");
	//string fileName=Path.Combine(@"C:\LinqPad_Queries\Files\TableauUsersAPI3.xml");
	DataContractSerializer dcs = new DataContractSerializer(typeof(tsResponse));
	FileStream fs = new FileStream(fileName, FileMode.Open);
	XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

	tsResponse games = (tsResponse)dcs.ReadObject(reader);
	reader.Close();
	fs.Close();
}


[DataContract(Name = "tsResponse", Namespace = "http://tableau.com/api")]
public class tsResponse
{
	[DataMember(Name = "users")]
	public string Key { get; set; }

 
}

[DataContract(Name = "users", Namespace = "")]
public class user
{
	[DataMember(Name = "id")]
	public string _ID { get; set; }

	[DataMember(Name = "name")]
	public string _name { get; set; }
}








//
//void Main()
//{
//	//http://stackoverflow.com/questions/16943176/how-to-deserialize-xml-using-datacontractserializer--doesnt' work
//	string fileName = Path.Combine(@"C:\LinqPad_Queries\C#\TableauAPI\tsResponse.xml");
//	DataContractSerializer dcs = new DataContractSerializer(typeof(tsResponse));
//	FileStream fs = new FileStream(fileName, FileMode.Open);
//	XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
//
//	using (reader)
//	{
//		string content = reader.ReadElementContentAsString();
//	}
//
//	tsResponse games = (tsResponse)dcs.ReadObject(reader);
//
//
//
//	reader.Close();
//	fs.Close();
//}
//
//
//[DataContract(Name = "tsResponse", Namespace = "http://tableau.com/api")]
//public class tsResponse
//{
//	[DataMember(Name = "datasource")]
//	public string Key { get; set; }
//
//
//}
//
//[DataContract(Name = "datasource", Namespace = "")]
//public class user
//{
//	[DataMember(Name = "owner")]
//	public string _ID { get; set; }
//
//	[DataMember(Name = "email")]
//	public string _name { get; set; }
//}