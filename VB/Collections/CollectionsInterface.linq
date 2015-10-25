<Query Kind="VBProgram" />

'\\http://www.codeproject.com/Articles/265692/Having-fun-with-custom-collections
'C:\Users\Sam\SkyDrive\Documents\vb_docs\Collections\Having fun with custom collections! - CodeProject.mht

Sub Main
	
	dim wa as new WesternAlphabet
	wa.doSomething()
   
End Sub
Public Class WesternAlphabet

    Implements IEnumerable(Of String)

    Public _alphabet As IEnumerable(Of String)
	
Public Sub doSomething()
 Dim count As Integer = _alphabet.Count
    For i As Integer = 0 To count - 2
       console.writeline(_alphabet(i).tostring())
    Next
    ' Omit the comma after the last character.
'    txtAlphabet.Text += _alphabet(count - 1)
	
end sub 

    Public Sub New()
        _alphabet = {"Aa", "B", "C", "D", "E", _
           "F", "G", "H", "I", "J", _
           "K", "L", "M", "N", "O", _
           "P", "Q", "R", "S", "T", _
           "U", "V", "W", "X", "Y", "Z"}
    End Sub

    Public Function GetEnumerator() As _
           System.Collections.Generic.IEnumerator(Of String) _
           Implements System.Collections.Generic.IEnumerable(Of String).GetEnumerator
        Return New AlphabetEnumerator({})
    End Function

    Private Function GetEnumeratorNonGeneric() As _
            System.Collections.IEnumerator Implements _
            System.Collections.IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

End Class

Friend Class AlphabetEnumerator
    Implements IEnumerator(Of String)

    Private _alphabet As IEnumerable(Of String)
    Private _position As Integer
    Private _max As Integer

    Public Sub New(ByVal alphabet As IEnumerable(Of String))
        _alphabet = alphabet
        _position = -1
        _max = _alphabet.Count - 1
    End Sub

    Public ReadOnly Property Current As String Implements _
           System.Collections.Generic.IEnumerator(Of String).Current
        Get
            Return _alphabet(_position)
        End Get
    End Property

    Private ReadOnly Property Current1 As Object _
            Implements System.Collections.IEnumerator.Current
        Get
            Return Me.Current
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements _
           System.Collections.IEnumerator.MoveNext
        If _position < _max Then
            _position += 1
            Return True
        End If
        Return False
    End Function

    Private Sub Reset() Implements System.Collections.IEnumerator.Reset
        Throw New NotImplementedException
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

End Class

' Define other methods and classes here
