Imports TBDOS.Data

Friend Class Route
    Inherits WorldDataClient
    Implements IRoute
    ReadOnly Property LocationId As Integer
    ReadOnly Property Direction As String Implements IRoute.Direction
    Sub New(worldData As WorldData, locationId As Integer, direction As String)
        MyBase.New(worldData)
        Me.LocationId = locationId
        Me.Direction = direction
    End Sub
End Class
