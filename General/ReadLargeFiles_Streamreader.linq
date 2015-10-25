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

 Dim stpw As New Stopwatch 'http://stackoverflow.com/questions/16105586/a-faster-way-to-read-lines-in-text-files-quickly
    Dim path As String = "X:\Finance\Systems Accounting\Daily Validations\Toad Queries\Monthly Queries\X.txt"
    Dim sr As New IO.StreamReader(path)
    Dim linect As Integer = 0
    stpw.Restart()

	'for i as integer=0 to 100
    Do While Not sr.EndOfStream and linect<10
        Dim s As String = sr.ReadLine
		console.writeline(sr.Readline)
        linect += 1
    Loop
	'i=i+1
	'next 
    stpw.Stop()
    sr.Close()
    Console.WriteLine(stpw.Elapsed.ToString)
    Console.WriteLine(linect)
