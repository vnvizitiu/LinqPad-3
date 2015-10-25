<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
{
	List<Order> Orders = new List<Order>();
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-01"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-02"), OrderId = 124 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-03"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-02"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-01"), OrderId = 321 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2016-01-01"), OrderId = 123 });

	Orders.Sort();
	foreach (var o in Orders)
	{
		Console.WriteLine(o);
	}


//	List<Order> objListOrder = Orders.OrderBy(order => order.OrderDate).ThenBy(order => order.OrderId).ToList();// using LINQ like above, interface not needed
//	
//		foreach (var element in objListOrder)
//		{
//			Console.WriteLine(element);
//		}

}



public class Order : IComparable
{
	public DateTime OrderDate { get; set; }
	public int OrderId { get; set; }

	public int CompareTo(object obj)// wrong 
	{
		Order orderToCompare = obj as Order;
		if (orderToCompare.OrderDate < OrderDate || orderToCompare.OrderId < OrderId)
		{
			return 1;
		}
		if (orderToCompare.OrderDate > OrderDate || orderToCompare.OrderId < OrderId)
		{
			return -1;
		}

		// The orders are equivalent.
		return 0;
	}
}
