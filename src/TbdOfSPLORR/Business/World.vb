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
        _worldData = New WorldData With
            {
                .Characters = New List(Of CharacterData),
                .Locations = New List(Of LocationData),
                .PlayerCharacterId = 0
            }
    End Sub

    Friend Sub AbandonGame()
        _worldData = Nothing
    End Sub
End Class
