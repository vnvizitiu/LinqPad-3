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
	string fileName = Path.Combine(@"C:\LinqPad_Queries\Files\doc2.xml");
	DataContractSerializer dcs = new DataContractSerializer(typeof(Games));
	FileStream fs = new FileStream(fileName, FileMode.Open);
	XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

	Games games = (Games)dcs.ReadObject(reader);
	reader.Close();
	fs.Close();
}


[DataContract(Name = "game", Namespace = "")]
public class Game
{
	[DataMember(Name = "name", Order = 0)]
	public string Name { get; private set; }

	[DataMember(Name = "code", Order = 1)]
	public string Code { get; private set; }

	[DataMember(Name = "ugn", Order = 2)]
	public string Ugn { get; private set; }

	[DataMember(Name = "bets", Order = 3)]
	public Bets Bets { get; private set; }
}

[CollectionDataContract(Name = "bets", ItemName = "bet", Namespace = "")]
public class Bets : List<string>
{
	public List<decimal> BetList
	{
		get
		{
			return ConvertAll(y => decimal.Parse(y, NumberStyles.Currency));
		}
	}
}

[CollectionDataContract(Name = "games", Namespace = "")]
public class Games : List<Game>
{
}

