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
	Try 
            Dim dirPath As String = "X:\" 

            Dim dirs As List(Of String) = New List(Of String)(Directory.EnumerateDirectories(dirPath))

            For Each folder In dirs
                Console.WriteLine("{0}", folder.Substring(folder.LastIndexOf("\") + 1))
            Next
            Console.WriteLine("{0} directories found.", dirs.Count)
        Catch UAEx As UnauthorizedAccessException
            Console.WriteLine(UAEx.Message)
        Catch PathEx As PathTooLongException
            Console.WriteLine(PathEx.Message)
        End Try 


End Sub

' Define other methods and classes here
