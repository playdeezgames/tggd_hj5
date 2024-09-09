Imports TBDOS.Data

Friend Class Route
    Inherits WorldDataClient
    Implements IRoute
    Private ReadOnly _worldData As WorldData
    ReadOnly Property LocationId As Integer
    ReadOnly Property Direction As String Implements IRoute.Direction
    Sub New(worldData As WorldData, locationId As Integer, direction As String)
        _worldData = worldData
        Me.LocationId = locationId
        Me.Direction = direction
    End Sub
End Class
