<Query Kind="VBProgram">
  <Connection>
    <ID>37f30f2b-7522-4a17-a059-b417e9358a57</ID>
    <Persist>true</Persist>
    <Server>L50045421\MSSQLSERVER2008</Server>
    <Database>BreakAway</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

  'QueryContents http://msdn.microsoft.com/en-us/library/bb882649.aspx
    Public Sub Main()

        ' Modify this path as necessary. 
        Dim startFolder = "Z:\Finance\Systems Accounting\Daily Validations\Mapping Templates\Mapping Template Documentation" 

        'Take a snapshot of the folder contents 
        Dim dir As New System.IO.DirectoryInfo(startFolder)
        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        'Dim searchTerm = "Visual Studio" 

        ' Search the contents of each file. 
        ' A regular expression created with the RegEx class 
        ' could be used instead of the Contains method. 
        Dim queryMatchingFiles = From file In fileList _
                                 Where file.Extension = ".msg" _
                                 Let fileText = GetFileText(file.FullName) _ 
								 Select file
                                'Select file.FullName,file
								 
								queryMatchingFiles.dump()

        'Console.WriteLine("The term " & searchTerm & " was found in:")

        ' Execute the query. 
       ' For Each filename In queryMatchingFiles
       '     Console.WriteLine(queryMatchingFiles)
			'Console.writeline(filetext)
      '  Next 

        ' Keep the console window open in debug mode.
     '   Console.WriteLine("Press any key to exit")
      '  Console.ReadKey()

    End Sub 

    ' Read the contents of the file. This is done in a separate 
    ' function in order to handle potential file system errors. 
    Function GetFileText(ByVal name As String) As String 

        ' If the file has been deleted, the right thing 
        ' to do in this case is return an empty string. 
        Dim fileContents = String.Empty

        ' If the file has been deleted since we took  
        ' the snapshot, ignore it and return the empty string. 
        If System.IO.File.Exists(name) Then
            fileContents = System.IO.File.ReadAllText(name)
        End If 

        Return fileContents

    End Function 