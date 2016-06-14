<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>CommonSerializer.Newtonsoft.Json</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>


    public class Contact
    {
        private Int64 id;
        private String name;
        List<Address> addresses;

        public Int64 Id
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public String Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public List<Address> Addresses
        {
            set { this.addresses = value; }
            get { return this.addresses; }
        }

        public String ToJSONRepresentation()
	{
		StringBuilder sb = new StringBuilder();
		JsonWriter jw = new JsonTextWriter(new StringWriter(sb));

		jw.Formatting = Newtonsoft.Json.Formatting.Indented;
		jw.WriteStartObject();
		jw.WritePropertyName("id");
		jw.WriteValue(this.Id);
		jw.WritePropertyName("name");
		jw.WriteValue(this.Name);

		jw.WritePropertyName("addresses");
		jw.WriteStartArray();

		int i;
		i = 0;

		for (i = 0; i < addresses.Count; i++)
		{
			jw.WriteStartObject();
			jw.WritePropertyName("id");
			jw.WriteValue(addresses[i].ID);
//			jw.WritePropertyName("streetAddress");
//			jw.WriteValue(addresses[i].StreetAddress);
//			jw.WritePropertyName("complement");
//			jw.WriteValue(addresses[i].Complement);
			jw.WritePropertyName("city");
			jw.WriteValue(addresses[i].City);
//			jw.WritePropertyName("province");
//			jw.WriteValue(addresses[i].Province);
			jw.WritePropertyName("country");
			jw.WriteValue(addresses[i].Country);
//			jw.WritePropertyName("postalCode");
//			jw.WriteValue(addresses[i].PostalCode);
			jw.WriteEndObject();
		}

		jw.WriteEndArray();

		jw.WriteEndObject();

		return sb.ToString();
	}

	public Contact()
	{
	}

	public Contact(Int64 id, String personName, List<Address> addresses)
	{
		this.id = id;
		this.name = personName;
		this.addresses = addresses;
	}

	public Contact(String JSONRepresentation)
	{
		//To do
	}
}

public class Address
{
	public int ID { get; set; }	
	public string City { get; set; }
	public string Country { get; set; }

	public Address(int mynumber, string myCity, string myCountry)
	{
		ID=mynumber;
		City=myCity;
		Country=myCountry;
	}
	
	
}
public class Program
{
	static void Main(string[] args)
	{
		List<Address> addresses = new List<Address>();
		addresses.Add(new Address(1, "Sydney", "Australia"));
		addresses.Add(new Address(2, "Melbourne", "Australia"));

		Contact contact = new Contact(1, "Ayrton Senna", addresses);

		Console.WriteLine(contact.ToJSONRepresentation());
		
	}
}
