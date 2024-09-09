Imports TBDOS.Data

Friend MustInherit Class WorldDataClient
    Protected ReadOnly Property WorldData As WorldData
    Sub New(worldData As WorldData)
        Me.WorldData = worldData
    End Sub
End Class
