Friend Class LocationRoutes
    Inherits LocationDataClient
    Implements ILocationRoutes

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IRoute) Implements ILocationRoutes.All
        Get
            Return LocationData.Neighbors.Select(Function(x) New Route(WorldData, locationId, x.Key))
        End Get
    End Property

    Public Function Has(direction As String) As Boolean Implements ILocationRoutes.Has
        Return LocationData.Neighbors.ContainsKey(direction)
    End Function
End Class
