Imports TBDOS.Data

Friend Class Route
    Implements IRoute
    Private ReadOnly _worldData As WorldData
    ReadOnly Property LocationId As Integer
    ReadOnly Property Direction As Directions Implements IRoute.Direction
    Sub New(worldData As WorldData, locationId As Integer, direction As Directions)
        _worldData = worldData
        Me.LocationId = locationId
        Me.Direction = direction
    End Sub
End Class
