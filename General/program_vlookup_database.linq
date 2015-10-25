<Query Kind="VBProgram">
  <Connection>
    <ID>700055bf-cade-4221-9ea3-2ee8255fed1a</ID>
    <Persist>true</Persist>
    <Server>WIN-90API3QKTDS</Server>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>StepSample</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Sub Main
	 Dim statusTable = {New With {.Code = "P", .Description = "Active Order"},
            New With {.Code = "C", .Description = "Completed / Shipped"},
            New With {.Code = "X", .Description = "Canceled"}}

        ' ----- Retrieve all customer orders.
        Dim result = From cu In Customers,
                     ord In OrderEntries
                     Where cu.ID = ord.Customer
                     Select CustomerID = cu.ID,
                     CustomerName = cu.FullName,
                     OrderID = ord.ID,
                     OrderDate = ord.OrderDate,
                     OrderTotal = ord.Total,
                     ord.StatusCode
                     Order By CustomerName, OrderID

        ' ----- Add in the status code.
        Dim result2 = From cu In result.ToArray(), sts In statusTable
                      Where cu.StatusCode = sts.Code
                      Select cu.CustomerID, cu.CustomerName, cu.OrderID,
                      OrderStatus = sts.Description, cu.OrderDate, cu.OrderTotal
					  statustable.dump
					  result.dump
					  result2.dump
End Sub

' Define other methods and classes here
