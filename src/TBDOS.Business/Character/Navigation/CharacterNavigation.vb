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

    Public ReadOnly Property LegacyDirection As ICharacterNavigationDirection Implements ICharacterNavigation.LegacyDirection
        Get
            Return New CharacterNavigationDirection(WorldData, CharacterId)
        End Get
    End Property

    Public Property Direction As String Implements ICharacterNavigation.Direction
        Get
            Return CharacterData.Direction
        End Get
        Set(value As String)
            CharacterData.Direction = value
        End Set
    End Property
End Class
