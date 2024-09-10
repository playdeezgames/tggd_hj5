Friend Class CharacterStatus
    Inherits CharacterDataClient
    Implements ICharacterStatus

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property IsStarving As Boolean Implements ICharacterStatus.IsStarving
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Statistics.Satiety = 0
        End Get
    End Property

    Public ReadOnly Property IsDead As Boolean Implements ICharacterStatus.IsDead
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Statistics.Health = 0
        End Get
    End Property
End Class
