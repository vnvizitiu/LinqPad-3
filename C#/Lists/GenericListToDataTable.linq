<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{

	List<Book> Books = new List<Book>() {
	new Book { Title = "LINQ in Action", Cost = 10, Publisher = "Sam" },
	new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymond" },
  new Book { Title = "LINQ for Fun", Cost = 12, Publisher = "Raymondx" },
  new Book { Title = "Extreme LINQ", Cost = 1, Publisher = "Krystal" }};
  
 
  DataTable dt=DTX.ToDataTable(Books);
  dt.Dump();
  
  
  
  
}
public class Book  
{
	public string Title { get; set; }
	public int Cost { get; set; }
	public string Publisher { get; set; }
}


	public static class DTX
	{
		public static DataTable ToDataTable<T>(this IList<T> list)
		{
			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
		DataTable table = new DataTable();
		for (int i = 0; i < props.Count; i++)
		{
			PropertyDescriptor prop = props[i];
			table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
		}
		object[] values = new object[props.Count];
		foreach (T item in list)
		{
			for (int i = 0; i < values.Length; i++)
				values[i] = props[i].GetValue(item) ?? DBNull.Value;
			table.Rows.Add(values);
		}
		return table;
	}
}
// Define other methods and classes here