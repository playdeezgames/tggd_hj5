Friend Class CharacterNavigationTurn
    Inherits CharacterDataClient
    Implements ICharacterNavigationTurn

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Sub TurnAround() Implements ICharacterNavigationTurn.TurnAround
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction.Current = character.Navigation.Direction.Opposite
    End Sub

    Public Sub TurnLeft() Implements ICharacterNavigationTurn.TurnLeft
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction.Current = character.Navigation.Direction.Left
    End Sub

    Public Sub TurnRight() Implements ICharacterNavigationTurn.TurnRight
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction.Current = character.Navigation.Direction.Right
    End Sub
End Class
