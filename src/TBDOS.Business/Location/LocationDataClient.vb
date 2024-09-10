Imports TBDOS.Data

Friend Class LocationDataClient
    Inherits WorldDataClient

    Protected ReadOnly Property locationId As Integer
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(locationId)
        End Get
    End Property

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData)
        Me.locationId = locationId
    End Sub
End Class
