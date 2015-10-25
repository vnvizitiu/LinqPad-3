<Query Kind="Program" />

void Main()
{
	List<Order> Orders = new List<Order>();
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-01"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-02"), OrderId = 124 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-03"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-02"), OrderId = 123 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2015-01-01"), OrderId = 321 });
	Orders.Add(new Order() { OrderDate = DateTime.Parse("2016-01-01"), OrderId = 123 });
	//	Orders.Sort();

	//	foreach (var element in Orders)
	//	{
	//		Console.WriteLine(element);
	//	}


	List<Order> objListOrder = Orders.OrderBy(order => order.OrderDate).ThenBy(order => order.OrderId).ToList();
		foreach (var element in objListOrder)
		{
			Console.WriteLine(element);
		}

}
public class Order : IComparable<Order>
{
	public DateTime OrderDate { get; set; }
	public int OrderId { get; set; }
		public int CompareTo(Order that)
		{
			if (that == null) return 1;
		if (this.OrderDate > that.OrderDate) return 1;
		if (this.OrderDate < that.OrderDate) return -1;
		return 0;
	}
}
