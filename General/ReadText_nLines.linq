<Query Kind="VBProgram">
  <Connection>
    <ID>f8ea445a-40e7-43c8-8ee7-3bad781710c8</ID>
    <Persist>true</Persist>
    <Server>vaunsw302\sqlpro_ciapps2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

Sub Main 'http://social.msdn.microsoft.com/Forums/en-US/4d5be656-0dff-4be1-a2a0-64fa01df2b8d/reading-a-text-file-from-linq
' We need to read into this List.
Dim list As New List(Of String)
' Open file.txt with the Using statement.
Using r As StreamReader = New StreamReader("\\naunsw002\CIS0_Workteam_sy$\Radar Production\Life 400\pastrans\Lf280613.txt")
' Store contents in this String.
Dim line As String
' Read first line.
line = r.ReadLine
' Loop over each line in file, While list is Not Nothing.
dim c as integer=0
Do While (Not line Is Nothing) and c<200
' Add this line to list.
list.Add(line)
' Display to console.
Console.WriteLine(line)
' Read in the next line.
line = r.ReadLine
c=c+1
Loop
End Using

Dim query = from n In list 
' Let sampleRecord = line.Split(","c)
'Select n
query.dump()
 
End Sub
