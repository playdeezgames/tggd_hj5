Public Class Location
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub
    Public ReadOnly Property Routes As IEnumerable(Of Route)
        Get
            Return _worldData.Locations(Id).Neighbors.Select(Function(x) New Route(_worldData, Id, CType(x.Key, Directions)))
        End Get
    End Property
End Class
