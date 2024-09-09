Friend Class CharacterMessages
    Inherits CharacterDataClient
    Implements ICharacterMessages

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub
End Class
