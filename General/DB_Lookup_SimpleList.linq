<Query Kind="VBProgram">
  <Connection>
    <ID>37f30f2b-7522-4a17-a059-b417e9358a57</ID>
    <Persist>true</Persist>
    <Server>L50045421\MSSQLSERVER2008</Server>
    <Database>StepSample</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Sub Main 'use L50045421\StepSample
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
