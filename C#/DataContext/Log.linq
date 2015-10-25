<Query Kind="Statements">
  <Connection>
    <ID>6182bf0a-901a-4a95-8a3b-8ae625cb7908</ID>
    <Persist>true</Persist>
    <Server>SAMMYPRO</Server>
    <Database>AdventureWorksDW2008R2</Database>
  </Connection>
</Query>

//DataContext dataContext=this;
string connstring ="Data Source=SAMMYPRO;Integrated Security=SSPI;Initial Catalog=AdventureWorksDW2008R2;app=LINQPad [Query 1]";
DataContext dataContext= new DataContext(connstring);

Table<DimReseller> reseller= dataContext.GetTable<DimReseller>();
 


var query=
	from res in DimResellers
	select new {
				 res.OrderMonth
				};
//Console.WriteLine(dataContext.GetCommand(query).CommandText );
dataContext.Log = Console.Out;///get SQL sent to Server 

//query.Dump();