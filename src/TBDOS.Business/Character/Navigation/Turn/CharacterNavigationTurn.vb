Friend Class CharacterNavigationTurn
    Inherits CharacterDataClient
    Implements ICharacterNavigationTurn

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Sub TurnAround() Implements ICharacterNavigationTurn.TurnAround
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction = Directions.Descriptors(character.Navigation.Direction).OppositeDirection
    End Sub

    Public Sub TurnLeft() Implements ICharacterNavigationTurn.TurnLeft
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction = Directions.Descriptors(character.Navigation.Direction).LeftDirection
    End Sub

    Public Sub TurnRight() Implements ICharacterNavigationTurn.TurnRight
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Navigation.Direction = Directions.Descriptors(character.Navigation.Direction).RightDirection
    End Sub
End Class
