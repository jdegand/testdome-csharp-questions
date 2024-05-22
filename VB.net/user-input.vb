Imports System

Public Class TextInput
    Private value As String = Nothing

    Public Overridable Sub Add(c As Char)
        Dim val As String
        val = GetValue()
        val += c
        value = val
    End Sub

    Function GetValue() As String
        Return value
    End Function
End Class

Public Class NumericInput
    Inherits TextInput

    Public Overrides Sub Add(c As Char)
        If IsNumeric(c) Then
            MyBase.Add(c)
        End If
    End Sub
End Class

Module Module1
    Public Sub Main()
        Dim input As TextInput = New NumericInput()
        input.Add("1"c)
        input.Add("a"c)
        input.Add("0"c)
        Console.WriteLine(input.GetValue())
    End Sub
End Module
