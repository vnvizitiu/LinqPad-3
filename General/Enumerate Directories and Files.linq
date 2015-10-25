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

    Sub Main() 'http://msdn.microsoft.com/en-us/library/dd997370.aspx
        Try 
            Dim files = From chkFile In Directory.EnumerateFiles("X:\Finance\Systems Accounting\Daily Validations\Mapping Templates\Mapping Template Documentation\", "*.msg", SearchOption.AllDirectories)
                        From line In File.ReadLines(chkFile)
                        Where line.Contains("Mapping")
                        Select New With {.curFile = chkFile, .curLine = line}

            For Each f In files
                Console.WriteLine("{0}\t{1}", f.curFile, f.curLine)
            Next
            Console.WriteLine("{0} files found.", files.Count.ToString())
			
			files.dump()
			
        Catch UAEx As UnauthorizedAccessException
            Console.WriteLine(UAEx.Message)
        Catch PathEx As PathTooLongException
            Console.WriteLine(PathEx.Message)
        End Try 
    End Sub 
	
	
	
	
	

