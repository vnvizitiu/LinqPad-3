<Query Kind="Program" />

void Main()
{//http://stackoverflow.com/questions/3057178/linq-join-two-dictionaries-using-a-common-key
	var idList = new Dictionary<int, int>();
	idList.Add(1, 1);
	idList.Add(3, 3);
	idList.Add(5, 5);

	var lookupList = new Dictionary<int, int>();
	lookupList.Add(1, 1000);
	lookupList.Add(2, 1001);
	lookupList.Add(3, 1002);
	lookupList.Add(4, 1003);
	lookupList.Add(5, 1004);
	lookupList.Add(6, 1005);
	lookupList.Add(7, 1006);
	//I am trying to join two Dictionary collections together based on a common lookup value.
	//The result should be a list of Values from lookupList (1000, 1002, 1004).
	var q = from id in idList.Keys
			where lookupList.ContainsKey(id)
			let value1 = idList[id]
			let value2 = lookupList[id]
			select new { id, value1, value2};
			Console.WriteLine(q);
	 
	var y = from kvp1 in idList
			join kvp2 in lookupList on kvp1.Key equals kvp2.Key
			select new { key = kvp1.Key, value1 = kvp1.Value, value2 = kvp2.Value };
	Console.WriteLine(y);

	var x = from id in idList
			join entry in lookupList
			  on id.Key equals entry.Key
			select entry.Value;
	Console.WriteLine(x);		
	
	var values = idList.Keys.Select(i => lookupList[i]);
	Console.WriteLine(values);
}

// Define other methods and classes here
