Public Class LocationData
    Public Property Neighbors As Dictionary(Of Integer, Integer)
    Public Property Items As Dictionary(Of Integer, Integer)
    Public Property VisitedBy As HashSet(Of Integer)
End Class
