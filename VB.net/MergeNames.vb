Imports System

Public Class MergeNames
    Public Shared Function UniqueNames(ByVal names1 As String(), ByVal names2 As String()) As String()
        Return names1.Union(names2).ToArray()
    End Function

    Public Shared Sub Main(ByVal args As String())
        Dim names1 As String() = New String() {"Ava", "Emma", "Olivia"}
        Dim names2 As String() = New String() {"Olivia", "Sophia", "Emma"}
        Console.WriteLine(String.Join(", ", MergeNames.UniqueNames(names1, names2)))
    End Sub
End Class
