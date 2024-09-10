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

    Public Sub Left() Implements ICharacterNavigationMove.Left
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.Current).LeftDirection, "to the left")
    End Sub

    Public Sub Right() Implements ICharacterNavigationMove.Right
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.Current).RightDirection, "to the right")
    End Sub

    Public Sub Ahead() Implements ICharacterNavigationMove.Ahead
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.Current).AheadDirection, Nothing)
    End Sub

    Public Sub Back() Implements ICharacterNavigationMove.Back
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(character.Navigation.Direction.Current).OppositeDirection, "back")
    End Sub
End Class
