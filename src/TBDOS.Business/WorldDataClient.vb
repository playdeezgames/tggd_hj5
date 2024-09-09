Imports TBDOS.Data

Public Class WorldDataClient
    Protected ReadOnly Property _worldData As WorldData
    Sub New(worldData As WorldData)
        Me._worldData = worldData
    End Sub
End Class
