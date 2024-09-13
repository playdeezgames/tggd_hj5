Friend Class CharacterNavigation
    Inherits CharacterDataClient
    Implements ICharacterNavigation

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property Turn As ICharacterNavigationTurn Implements ICharacterNavigation.Turn
        Get
            Return New CharacterNavigationTurn(WorldData, CharacterId)
        End Get
    End Property

    Private ReadOnly Property ICharacterNavigation_Move As ICharacterNavigationMove Implements ICharacterNavigation.Move
        Get
            Return New CharacterNavigationMove(WorldData, CharacterId)
        End Get
    End Property
End Class
