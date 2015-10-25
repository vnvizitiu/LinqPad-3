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

Sub Main 'http://msdn.microsoft.com/en-us/library/system.io.filestream.read.aspx
'http://msdn.microsoft.com/en-us/library/system.io.stream.read.aspx
	' Specify a file to read from and to create. 
    Dim pathSource As String = "\\naunsw002\CIS0_Workteam_sy$\Radar Production\Invest Linked\pastrans\IL280613.txt" 
    Dim pathNew As String = "c:\newfile.txt" 
    Try  
        Using fsSource As FileStream = New FileStream(pathSource, _
            FileMode.Open, FileAccess.Read)
            ' Read the source file into a byte array. 
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length,Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead. 
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached. 
                    If (n = 0) Then 
                        Exit While 
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
            numBytesToRead = bytes.Length
			
			

            ' Write the byte array to the other FileStream. 
            Using fsNew As FileStream = New FileStream(pathNew, _
                FileMode.Create, FileAccess.Write)
                fsNew.Write(bytes, 0, numBytesToRead)
            End Using 
        End Using 
    Catch ioEx As FileNotFoundException
        Console.WriteLine(ioEx.Message)
    End Try 

End Sub

' Define other methods and classes here
