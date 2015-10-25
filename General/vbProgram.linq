<Query Kind="VBProgram">
  <Connection>
    <ID>c4cc9c8e-5843-451b-bc44-752e91606e55</ID>
    <Persist>true</Persist>
    <Server>VAUNSWD044\SQLUAT_CIAPPS2</Server>
    <Database>ThreeWayRec</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

'http://msdn.microsoft.com/en-us/library/vstudio/bb397937.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-2
Sub Main
	    Dim student1 As New Student With {.FirstName = "Svetlana", 
                                     .LastName = "Omelchenko", 
                                     .Scores = New Integer() {98, 92, 81, 60}}
        Dim student2 As New Student With {.FirstName = "Claire", 
                                    .LastName = "O'Donnell", 
                                    .Scores = New Integer() {75, 84, 91, 39}}
        Dim student3 As New Student With {.FirstName = "Cesar", 
                                    .LastName = "Garcia", 
                                    .Scores = New Integer() {97, 89, 85, 82}}
        Dim student4 As New Student With {.FirstName = "Sven", 
                                    .LastName = "Mortensen", 
                                    .Scores = New Integer() {88, 94, 65, 91}}

        Dim arrList As New ArrayList()
        arrList.Add(student1)
        arrList.Add(student2)
        arrList.Add(student3)
        arrList.Add(student4)

        ' Use an explicit type for non-generic collections 
        Dim query = From student As Student In arrList 
                    Where student.Scores(0) > 95 
                    Select student

        For Each student As Student In query
            Console.WriteLine(student.LastName & ": " & student.Scores(0))
        Next 
        ' Keep the console window open in debug mode.
      
	  	query.dump()
	  
    End Sub 

  Public Class Student
        Public Property FirstName As String 
        Public Property LastName As String 
        Public Property Scores As Integer()
    End Class 

' Define other methods and classes here
