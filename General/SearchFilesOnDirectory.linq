<Query Kind="VBProgram">
  <Output>DataGrids</Output>
</Query>

Module Module1
    'QueryContents http://msdn.microsoft.com/en-us/library/bb882649.aspx
    Public Sub Main()

        ' Modify this path as necessary. 
        Dim startFolder = "c:\program files\Microsoft Visual Studio 9.0\VB\" 

        'Take a snapshot of the folder contents 
        Dim dir As New System.IO.DirectoryInfo(startFolder)
        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        Dim searchTerm = "Visual Studio" 

        ' Search the contents of each file. 
        ' A regular expression created with the RegEx class 
        ' could be used instead of the Contains method. 
        Dim queryMatchingFiles = From file In fileList _
                                 Where file.Extension = ".htm" _
                                 Let fileText = GetFileText(file.FullName) _
                                 Where fileText.Contains(searchTerm) _
                                 Select file.FullName

        Console.WriteLine("The term " & searchTerm & " was found in:")

        ' Execute the query. 
        For Each filename In queryMatchingFiles
            Console.WriteLine(filename)
        Next 

        ' Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()

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
End Module
