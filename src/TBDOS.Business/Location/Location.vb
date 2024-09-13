Imports TBDOS.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return locationId
        End Get
    End Property
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub
    Public Function Neighbor(direction As String) As ILocation Implements ILocation.Neighbor
        If Not Routes.Has(direction) Then
            Return Nothing
        End If
        Return New Location(WorldData, LocationData.Neighbors(direction))
    End Function

    Public ReadOnly Property Routes As ILocationRoutes Implements ILocation.Routes
        Get
            Return New LocationRoutes(WorldData, locationId)
        End Get
    End Property
End Class
