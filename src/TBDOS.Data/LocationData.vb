Public Class LocationData
    Public Property Neighbors As Dictionary(Of String, Integer)
    Public Property Items As Dictionary(Of String, Integer)
    Public Property VisitedBy As HashSet(Of Integer)
End Class
