Friend Class CharacterNavigationMove
    Inherits CharacterDataClient
    Implements ICharacterNavigationMove

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
End Class
