<Query Kind="Program">
  <Namespace>System.Data</Namespace>
</Query>

void Main()
{//https://msdn.microsoft.com/en-us/library/bb669096.aspx
 //https://msdn.microsoft.com/en-us/library/bb386921.aspx

	// NOTE: helper class ObjectShredder<T> is needed here-see link. Helper not necessary if from SQL datatables.


	DataSet myDS = new DataSet();


	// Create a sequence. 
	Item[] items = new Item[]
	{ new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
  new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
  new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
  new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

	// Query for items with price greater than 9.99.
	var query = from i in items
				where i.Price > 9.99
				orderby i.Price
				select i;

	// Load the query results into new DataTable.
	DataTable table1 = query.CopyToDataTable();
	
	myDS.Tables.Add(table1);





	// Create a sequence. 
	Item[] items2 = new Item[]
	{ new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
  new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
  new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
  new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

	// Load into an existing DataTable, expand the schema and
	// autogenerate a new Id.
	DataTable table2 = new DataTable();
	table2.TableName="myTable2";
	DataColumn dc = table2.Columns.Add("NewId", typeof(int));
	dc.AutoIncrement = true;
	table2.Columns.Add("ExtraColumn", typeof(string));

	var query2 = from i in items
				where i.Price > 9.99
				orderby i.Price
				select new { i.Price, i.Genre };

	query.CopyToDataTable(table2, LoadOption.PreserveChanges);
	myDS.Tables.Add(table2);
	Console.WriteLine("Finished");
	
	
}

public class Item
{
	public int Id { get; set; }
	public double Price { get; set; }
	public string Genre { get; set; }
}

public class Book : Item
{
	public string Author { get; set; }
}

public class Movie : Item
{
	public string Director { get; set; }
}

// Define other methods and classes here
public class ObjectShredder<T>
{
	private System.Reflection.FieldInfo[] _fi;
	private System.Reflection.PropertyInfo[] _pi;
	private System.Collections.Generic.Dictionary<string, int> _ordinalMap;
	private System.Type _type;

	// ObjectShredder constructor.
	public ObjectShredder()
	{
		_type = typeof(T);
		_fi = _type.GetFields();
		_pi = _type.GetProperties();
		_ordinalMap = new Dictionary<string, int>();
	}

	/// <summary>
	/// Loads a DataTable from a sequence of objects.
	/// </summary>
	/// <param name="source">The sequence of objects to load into the DataTable.</param>
	/// <param name="table">The input table. The schema of the table must match that 
	/// the type T.  If the table is null, a new table is created with a schema 
	/// created from the public properties and fields of the type T.</param>
	/// <param name="options">Specifies how values from the source sequence will be applied to 
	/// existing rows in the table.</param>
	/// <returns>A DataTable created from the source sequence.</returns>
	public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
	{
		// Load the table from the scalar sequence if T is a primitive type.
		if (typeof(T).IsPrimitive)
		{
			return ShredPrimitive(source, table, options);
		}

		// Create a new table if the input table is null.
		if (table == null)
		{
			table = new DataTable(typeof(T).Name);
		}

		// Initialize the ordinal map and extend the table schema based on type T.
		table = ExtendTable(table, typeof(T));

		// Enumerate the source sequence and load the object values into rows.
		table.BeginLoadData();
		using (IEnumerator<T> e = source.GetEnumerator())
		{
			while (e.MoveNext())
			{
				if (options != null)
				{
					table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
				}
				else
				{
					table.LoadDataRow(ShredObject(table, e.Current), true);
				}
			}
		}
		table.EndLoadData();

		// Return the table.
		return table;
	}

	public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
	{
		// Create a new table if the input table is null.
		if (table == null)
		{
			table = new DataTable(typeof(T).Name);
		}

		if (!table.Columns.Contains("Value"))
		{
			table.Columns.Add("Value", typeof(T));
		}

		// Enumerate the source sequence and load the scalar values into rows.
		table.BeginLoadData();
		using (IEnumerator<T> e = source.GetEnumerator())
		{
			Object[] values = new object[table.Columns.Count];
			while (e.MoveNext())
			{
				values[table.Columns["Value"].Ordinal] = e.Current;

				if (options != null)
				{
					table.LoadDataRow(values, (LoadOption)options);
				}
				else
				{
					table.LoadDataRow(values, true);
				}
			}
		}
		table.EndLoadData();

		// Return the table.
		return table;
	}

	public object[] ShredObject(DataTable table, T instance)
	{

		FieldInfo[] fi = _fi;
		PropertyInfo[] pi = _pi;

		if (instance.GetType() != typeof(T))
		{
			// If the instance is derived from T, extend the table schema
			// and get the properties and fields.
			ExtendTable(table, instance.GetType());
			fi = instance.GetType().GetFields();
			pi = instance.GetType().GetProperties();
		}

		// Add the property and field values of the instance to an array.
		Object[] values = new object[table.Columns.Count];
		foreach (FieldInfo f in fi)
		{
			values[_ordinalMap[f.Name]] = f.GetValue(instance);
		}

		foreach (PropertyInfo p in pi)
		{
			values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
		}

		// Return the property and field values of the instance.
		return values;
	}

	public DataTable ExtendTable(DataTable table, Type type)
	{
		// Extend the table schema if the input table was null or if the value 
		// in the sequence is derived from type T.            
		foreach (FieldInfo f in type.GetFields())
		{
			if (!_ordinalMap.ContainsKey(f.Name))
			{
				// Add the field as a column in the table if it doesn't exist
				// already.
				DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
					: table.Columns.Add(f.Name, f.FieldType);

				// Add the field to the ordinal map.
				_ordinalMap.Add(f.Name, dc.Ordinal);
			}
		}
		foreach (PropertyInfo p in type.GetProperties())
		{
			if (!_ordinalMap.ContainsKey(p.Name))
			{
				// Add the property as a column in the table if it doesn't exist
				// already.
				DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
					: table.Columns.Add(p.Name, p.PropertyType);

				// Add the property to the ordinal map.
				_ordinalMap.Add(p.Name, dc.Ordinal);
			}
		}

		// Return the table.
		return table;
	}
}
public static class CustomLINQtoDataSetMethods
{
	public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
	{
		return new ObjectShredder<T>().Shred(source, null, null);
	}

	public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
												DataTable table, LoadOption? options)
	{
		return new ObjectShredder<T>().Shred(source, table, options);
	}

}
