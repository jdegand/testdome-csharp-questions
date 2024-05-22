Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Module1
    Public Class Folders
        
    Public Shared Function FolderNames(ByVal xml As String, ByVal startingLetter As Char) As IEnumerable(Of String)
        Return XDocument.Parse(xml).Descendants().Where(Function(x) x.Attribute("name").Value.StartsWith(Char.ToString(startingLetter))).[Select](Function(x) x.Attribute("name").Value)
    End Function

    Public Shared Sub Main(ByVal args As String())
        Dim xml As String = "<?xml version=""1.0"" encoding=""UTF-8""?>" & "<folder name=""c"">" & "<folder name=""program files"">" & "<folder name=""uninstall information"" />" & "</folder>" & "<folder name=""users"" />" & "</folder>"

        For Each name As String In Folders.FolderNames(xml, "u"c)
            Console.WriteLine(name)
        Next
    End Sub
    End Class
End Module
