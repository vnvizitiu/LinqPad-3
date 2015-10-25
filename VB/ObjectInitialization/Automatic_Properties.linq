<Query Kind="VBProgram" />

'Pro VB2010 and the >NET4 Platform p213
'Automatic Properties CHAPTER 5 ■ DEFINING ENCAPSULATED CLASS TYPES
Sub Main

Console.WriteLine("** Fun with Automatic Properties **"  )
Dim ct As New Carts()
ct.PetName = "Frank"
ct.Speed = 55
ct.Color = "Red"
Console.WriteLine("Your car is named {0}? That's odd...", ct.PetName)
ct.DisplayStats()
console.writeline("********************************************************************")
console.writeline("********************************************************************")

''''''''''''''''''bit below is for gagarage

Console.WriteLine("**Fun with Automatic Properties***" )
'Make a car.
Dim cc As New Carts()
cc.PetName = "Frank"
cc.Speed = 55
cc.Color = "Red"
cc.DisplayStats()
'Put car in the garage.
Dim g As New Garage()
g.MyAuto = cc
Console.WriteLine("Number of Cars in garage: {0}", g.NumberOfCars)
Console.WriteLine("Your car is named: {0}", g.MyAuto.PetName)
'Runtime error! Backing field is currently Nothing
Console.WriteLine(g.MyAuto.PetName)
End Sub

'A Car type using standard property
'syntax.
Public Class Car
Private carName As String = ""
Public Property PetName() As String
Get
Return carName
End Get
Set(ByVal value As String)
carName = value
End Set
End Property
End Class

'Cart does the same thing using automatic properties
Public Class Carts
'Automatic properties!
Public Property PetName() As String 
Public Property Speed() As Integer
Public Property Color() As String

Public Sub DisplayStats()
Console.WriteLine("Cart Name: {0}", PetName)
Console.WriteLine("Speed: {0}", Speed)
Console.WriteLine("Color: {0}", Color)
End Sub
End Class


Public Class Garage
'The hidden backing field is set to zero!
Public Property NumberOfCars() As Integer
'The hidden backing field is set to Nothing
Public Property MyAuto() As Carts
'Must use constructors to override default
'values assigned to hidden backing fields.
Public Sub New()
MyAuto = New Carts()
NumberOfCars = 1
End Sub
Public Sub New(ByVal carts As Carts,ByVal number As Integer)
MyAuto = carts
NumberOfCars = number
End Sub
End Class
 

 














'
'Unlike traditional VB 2010 properties, however, it is not possible to build read-only or write-only
'automatic properties. While you might think you can just omit the Get or Set within your property
'declaration as follows:
''Read-only property? Error!
'Public ReadOnly Property MyReadOnlyProp() As Integer
''Write only property? Error!
'Public WriteOnly Property MyWriteOnlyProp() As Integer