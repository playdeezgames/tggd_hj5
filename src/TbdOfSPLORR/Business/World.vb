Public Class World
    Private _worldData As WorldData
    Sub New()

    End Sub
    Public ReadOnly Property IsGameOver As Boolean
        Get
            Return _worldData Is Nothing
        End Get
    End Property

    Friend Sub Start()
        _worldData = New WorldData
    End Sub

    Friend Sub AbandonGame()
        _worldData = Nothing
    End Sub
End Class
