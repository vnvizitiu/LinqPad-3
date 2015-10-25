<Query Kind="VBProgram">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
</Query>

'Imports System
'Imports System.Collections.Generic
Sub Main
dim E as Example
e.Main()
end sub

Public Class Example

    Public Shared Sub Main()
        Dim dinosaurs As New List(Of String)

        Console.WriteLine(  "Capacity: {0}", dinosaurs.Capacity)

        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine( "Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)

        Console.WriteLine( "Contains(""Deinonychus""): {0}", _
            dinosaurs.Contains("Deinonychus"))

        Console.WriteLine( "Insert(2, ""Compsognathus"")")
        dinosaurs.Insert(2, "Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next 
        ' Shows how to access the list using the Item property.
        Console.WriteLine( "dinosaurs(3): {0}", dinosaurs(3))
        Console.WriteLine( "Remove(""Compsognathus"")")
        dinosaurs.Remove("Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        dinosaurs.TrimExcess()
        Console.WriteLine( "TrimExcess()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)

        dinosaurs.Clear()
        Console.WriteLine( "Clear()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)
    End Sub 
End Class 

' This code example produces the following output: 
' 
'Capacity: 0 
' 
'Tyrannosaurus 
'Amargasaurus 
'Mamenchisaurus 
'Deinonychus 
'Compsognathus 
' 
'Capacity: 8 
'Count: 5 
' 
'Contains("Deinonychus"): True 
' 
'Insert(2, "Compsognathus") 
' 
'Tyrannosaurus 
'Amargasaurus 
'Compsognathus 
'Mamenchisaurus 
'Deinonychus 
'Compsognathus 
' 
'dinosaurs(3): Mamenchisaurus 
' 
'Remove("Compsognathus") 
' 
'Tyrannosaurus 
'Amargasaurus 
'Mamenchisaurus 
'Deinonychus 
'Compsognathus 
' 
'TrimExcess() 
'Capacity: 5 
'Count: 5 
' 
'Clear() 
'Capacity: 5 
'Count: 0
