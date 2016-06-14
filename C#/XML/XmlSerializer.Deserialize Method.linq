<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

// This is the class that will be deserialized.
//https://msdn.microsoft.com/en-us/library/tz8csy73(v=vs.110).aspx
public class OrderedItem
{
	public string ItemName;
	public string Description;
	public decimal UnitPrice;
	public int Quantity;
	public decimal LineTotal;

	// A custom method used to calculate price per item.
	public void Calculate()
	{
		LineTotal = UnitPrice * Quantity;
	}
}
public class Test
{
	public static void Main(string[] args)
	{
		Test t = new Test();
		// Read a purchase order.
		t.DeserializeObject(@"C:\LinqPad_Queries\Files\msdn.xml");
	}

	private void DeserializeObject(string filename)
	{
		Console.WriteLine("Reading with XmlReader");

		// Create an instance of the XmlSerializer specifying type and namespace.
		XmlSerializer serializer = new
		XmlSerializer(typeof(OrderedItem));

		// A FileStream is needed to read the XML document.
		FileStream fs = new FileStream(filename, FileMode.Open);
		XmlReader reader = XmlReader.Create(fs);

		// Declare an object variable of the type to be deserialized.
		OrderedItem i;

		// Use the Deserialize method to restore the object's state.
		i = (OrderedItem)serializer.Deserialize(reader);
		fs.Close();

		// Write out the properties of the object.
		Console.Write(
		i.ItemName + "\t" +
		i.Description + "\t" +
		i.UnitPrice + "\t" +
		i.Quantity + "\t" +
		i.LineTotal);
	}
}