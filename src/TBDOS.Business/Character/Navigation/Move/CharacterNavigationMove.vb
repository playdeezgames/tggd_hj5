Friend Class CharacterNavigationMove
    Inherits CharacterDataClient
    Implements ICharacterNavigationMove

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Private Sub Move(direction As String, text As String)
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        If Not character.Location.HasRoute(direction) Then
            character.Messages.Add("You cannot go that way!")
            Return
        End If
        character.Messages.Add($"You move {text}.")
        CharacterData.LocationId = character.Location.Neighbor(direction).Id
        CharacterTypes.Descriptors(CharacterData.CharacterType).ApplyEffects(New Character(WorldData, CharacterId))
    End Sub

    Public Sub MoveLeft() Implements ICharacterNavigationMove.MoveLeft
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.CurrentDirection).LeftDirection, "to the left")
    End Sub

    Public Sub MoveRight() Implements ICharacterNavigationMove.MoveRight
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.CurrentDirection).RightDirection, "to the right")
    End Sub

    Public Sub MoveAhead() Implements ICharacterNavigationMove.MoveAhead
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.CurrentDirection).AheadDirection, Nothing)
    End Sub

    Public Sub MoveBack() Implements ICharacterNavigationMove.MoveBack
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.CurrentDirection).OppositeDirection, "back")
    End Sub
End Class
