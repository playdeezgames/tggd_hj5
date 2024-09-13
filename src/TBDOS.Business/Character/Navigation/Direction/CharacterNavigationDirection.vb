Friend Class CharacterNavigationDirection
    Inherits CharacterDataClient
    Implements ICharacterNavigationDirection

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
End Class
