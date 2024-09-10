Friend Class CharacterNavigation
    Inherits CharacterDataClient
    Implements ICharacterNavigation
    Private ReadOnly applyEffects As Action

    Public Sub New(worldData As Data.WorldData, characterId As Integer, applyEffects As Action)
        MyBase.New(worldData, characterId)
        Me.applyEffects = applyEffects
    End Sub

    Public ReadOnly Property Turn As ICharacterNavigationTurn Implements ICharacterNavigation.Turn
        Get
            Return New CharacterNavigationTurn(WorldData, CharacterId)
        End Get
    End Property

    Private ReadOnly Property ICharacterNavigation_Move As ICharacterNavigationMove Implements ICharacterNavigation.Move
        Get
            Return New CharacterNavigationMove(WorldData, CharacterId, applyEffects)
        End Get
    End Property

    Public ReadOnly Property Direction As ICharacterNavigationDirection Implements ICharacterNavigation.Direction
        Get
            Return New CharacterNavigationDirection(WorldData, CharacterId)
        End Get
    End Property
End Class
