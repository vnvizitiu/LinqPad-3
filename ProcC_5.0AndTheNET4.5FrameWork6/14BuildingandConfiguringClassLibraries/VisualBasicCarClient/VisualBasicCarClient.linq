<Query Kind="Program" />

Imports CarLibrary

Module Module1
    Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App *****")

        ' Local variables are declared using the Dim keyword.
        Dim myMiniVan As New MiniVan()
        myMiniVan.TurboBoost()

        Dim mySportsCar As New SportsCar()
        mySportsCar.TurboBoost()

        Dim dreamCar As New PerformanceCar()

        ' Use Inherited property.
        dreamCar.PetName = "Hank"
        dreamCar.TurboBoost()
        Console.ReadLine()
    End Sub

End Module


Imports CarLibrary

' This VB class is deriving from the C# SportsCar.
Public Class PerformanceCar
    Inherits SportsCar

    Public Overrides Sub TurboBoost()
        Console.WriteLine("Zero to 60 in a cool 4.8 seconds...")
    End Sub

End Class