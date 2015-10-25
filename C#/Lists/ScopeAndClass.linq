<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
</Query>

// A variable of type x can refer to an object that subclasses x.
//using System.Collections.Generic
 


static void Main()
{
 
	// The Display method below accepts an Asset. This means means we can pass it any subtype:
	Display (new Stock { Name="MSFT", SharesOwned=1000 });
	Display (new House { Name="Mansion", Mortgage=100000 });
	
	Psam ps= new Psam();
	ps.CreateList(new Stock { Name="Sam", SharesOwned=1000 });
	ps.CreateList(new Stock { Name="Tran", SharesOwned=1000 });
	
	
	foreach (Asset xAsset in ps.assets)
	{
	Console.WriteLine(xAsset);
	}
	 
	  List<Asset> newAssetList = new List<Asset>(ps.assets); //create new list
	  
	  	foreach (Asset x in newAssetList)
		{
		Console.WriteLine(x);
		}
}

public static void Display (Asset asset)
{
	//Console.WriteLine (asset.Name);
  List<Asset> assets =new List<Asset>();
	assets.Add(asset);
//	assets.Add(House);
	foreach (Asset Asset in assets)
	{
	Console.WriteLine(Asset);
	}
	
}

public class Asset
{
	public string Name;
}

public class Stock : Asset   // inherits from Asset
{
	public long SharesOwned;
}

public class House : Asset   // inherits from Asset
{
	public decimal Mortgage;
}


public class Psam
{
	 public List<Asset> assets= new List<Asset>();
	 public string FirstChild="Raymond";
	 public string LastChild= "Krystal";
	 
	 public void CreateList(Asset asset)
	 {
	 	assets.Add(asset);
		Console.WriteLine(asset);
	 
	 }
	 
	
//	 foreach (Asset x in newassetList)
//	{
//	Console.WriteLine(Asset);
//	}
 
	 
}


 