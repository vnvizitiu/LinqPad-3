<Query Kind="Program" />

void Main() //http://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
{
	List<Order> Orders = new List<Order>();
	Orders.Add(new Order() { OrderName = "sam", OrderId = 123 });
	Orders.Add(new Order() { OrderName = "ray", OrderId = 124 });
	Orders.Add(new Order() { OrderName = "sandy", OrderId = 321 });
	Orders.Add(new Order() { OrderName = "sandy", OrderId = 123 });
	Orders.Add(new Order() { OrderName = "krystal", OrderId = 321 });
	Orders.Add(new Order() { OrderName = "bob", OrderId = 123 });
 	Orders.Add(new Order() { OrderName = "sandy", OrderId = 11 });


	List<Order> objListOrder = Orders.OrderBy(order => order.OrderName).ThenBy(order => order.OrderId).ToList();// using LINQ like above, interface not needed
	
		foreach (var element in objListOrder)
		{
			Console.WriteLine(element);
		}

}
public class Order  
{
	public string OrderName { get; set; }
	public int OrderId { get; set; }
 
}
