Friend Class CharacterNavigationMove
    Inherits CharacterDataClient
    Implements ICharacterNavigationMove

    Public ReadOnly Property CanMoveAhead As Boolean Implements ICharacterNavigationMove.CanMoveAhead
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Location.Routes.All.Any(Function(x) x.Direction = Directions.Descriptors(CharacterData.Direction).AheadDirection)
        End Get
    End Property

    Public ReadOnly Property CanMoveRight As Boolean Implements ICharacterNavigationMove.CanMoveRight
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Location.Routes.All.Any(Function(x) x.Direction = Directions.Descriptors(CharacterData.Direction).RightDirection)
        End Get
    End Property

    Public ReadOnly Property CanMoveLeft As Boolean Implements ICharacterNavigationMove.CanMoveLeft
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Location.Routes.All.Any(Function(x) x.Direction = Directions.Descriptors(CharacterData.Direction).LeftDirection)
        End Get
    End Property

    Public ReadOnly Property CanMoveBack As Boolean Implements ICharacterNavigationMove.CanMoveBack
        Get
            Dim character As ICharacter = New Character(WorldData, CharacterId)
            Return character.Location.Routes.All.Any(Function(x) x.Direction = Directions.Descriptors(CharacterData.Direction).OppositeDirection)
        End Get
    End Property

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Private Sub Move(direction As String, text As String)
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        If Not character.Location.Routes.Has(direction) Then
            character.Messages.Add("You cannot go that way!")
            Return
        End If
        character.Messages.Add($"You move {text}.")
        CharacterData.LocationId = character.Location.Neighbor(direction).Id
        CharacterTypes.Descriptors(CharacterData.CharacterType).ApplyEffects(New Character(WorldData, CharacterId))
    End Sub

    Public Sub Left() Implements ICharacterNavigationMove.Left
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(CharacterData.Direction).LeftDirection, "to the left")
    End Sub

    Public Sub Right() Implements ICharacterNavigationMove.Right
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(CharacterData.Direction).RightDirection, "to the right")
    End Sub

    Public Sub Ahead() Implements ICharacterNavigationMove.Ahead
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(CharacterData.Direction).AheadDirection, Nothing)
    End Sub

    Public Sub Back() Implements ICharacterNavigationMove.Back
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        Move(Directions.Descriptors(CharacterData.Direction).OppositeDirection, "back")
    End Sub
End Class
