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

Sub Main 
'http://msdn.microsoft.com/en-us/library/system.io.streamreader.peek.aspx
 Dim path As String = "X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt"
 Dim sr As StreamReader = New StreamReader(path)

            Do While sr.Peek() > -1
                Console.WriteLine(sr.ReadLine())
            Loop
            sr.Close()

End Sub
