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

Sub Main 'http://msdn.microsoft.com/en-us/library/system.io.streamreader.peek.aspx
        Dim path As String = "c:\MyTest.txt" 

        Try 
            If File.Exists(path) Then
                File.Delete(path)
            End If 

            Dim sw As StreamWriter = New StreamWriter(path)
            sw.WriteLine("This")
            sw.WriteLine("is some text")
            sw.WriteLine("to test")
            sw.WriteLine("Reading")
            sw.Close()

            Dim sr As StreamReader = New StreamReader(path)

            Do While sr.Peek() > -1
                Console.WriteLine(sr.ReadLine())
            Loop
            sr.Close()
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try 


End Sub

' Define other methods and classes here
