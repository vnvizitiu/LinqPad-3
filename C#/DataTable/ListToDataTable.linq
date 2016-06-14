<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	
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