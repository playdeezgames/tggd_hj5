Friend Class CharacterNavigationTurn
    Inherits CharacterDataClient
    Implements ICharacterNavigationTurn

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
End Class
