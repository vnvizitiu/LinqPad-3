<Query Kind="VBStatements">
  <Connection>
    <ID>f8ea445a-40e7-43c8-8ee7-3bad781710c8</ID>
    <Persist>true</Persist>
    <Server>vaunsw302\sqlpro_ciapps2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Dim query = From line In IO.File.ReadAllLines("X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt") _
Let sampleRecord = line.Split(","c) _
Select New With {.column1 = sampleRecord(0), .column2 = sampleRecord(1), .column3 = sampleRecord(2), .column4 = sampleRecord(3), .column5 = sampleRecord(4) _
,.column6 = sampleRecord(5), .column7 = sampleRecord(6), .column8 = sampleRecord(7), .column9 = sampleRecord(10), .column10 = sampleRecord(11) _
,.column11 = sampleRecord(12), .column12 = sampleRecord(13), .column13 = sampleRecord(14), .column14 = sampleRecord(15), .column15 = sampleRecord(16),.column16 = sampleRecord(17)}

'"X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt"


        For Each item In query
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", _
           item.column1, item.column2, item.column3, item.column4, item.column5)
        Next
		'query.dump()
		
'--------------------------------------------------------------------------------
dim query = From line In File.ReadAllLines("\\naunsw002\CIS0_Workteam_sy$\Radar Production\Prudent\pastrans\PR080713.txt") _
Let sampleRecord = line.Split(","c) _
Select sampleRecord


query.dump()

For Each item In query 
  Console.WriteLine(item)

Next


'------------------------------------------------------------------------
dim query = From line In File.ReadAllLines("X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt") _
Let sampleRecord = line.Split(","c) _
Select sampleRecord

For Each item In query 
  Console.WriteLine(item)

Next




