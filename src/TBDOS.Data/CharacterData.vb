Public Class CharacterData
    Public Property LocationId As Integer
    Public Property Direction As String
    Public Property Messages As List(Of String())
    Public Property Statistics As Dictionary(Of String, Integer)
    Public Property Items As Dictionary(Of Integer, Integer)
End Class
