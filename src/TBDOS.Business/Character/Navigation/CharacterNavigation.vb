Friend Class CharacterNavigation
    Inherits CharacterDataClient
    Implements ICharacterNavigation
    Private ReadOnly applyEffects As Action

    Public Sub New(worldData As Data.WorldData, characterId As Integer, applyEffects As Action)
        MyBase.New(worldData, characterId)
        Me.applyEffects = applyEffects
    End Sub

    Public ReadOnly Property CurrentDirection As String Implements ICharacterNavigation.CurrentDirection
        Get
            Return CharacterData.Direction
        End Get
    End Property

    Public ReadOnly Property AheadDirection As String Implements ICharacterNavigation.AheadDirection
        Get
            Return Directions.Descriptors(CurrentDirection).AheadDirection
        End Get
    End Property

    Public ReadOnly Property LeftDirection As String Implements ICharacterNavigation.LeftDirection
        Get
            Return Directions.Descriptors(CurrentDirection).LeftDirection
        End Get
    End Property

    Public ReadOnly Property RightDirection As String Implements ICharacterNavigation.RightDirection
        Get
            Return Directions.Descriptors(CurrentDirection).RightDirection
        End Get
    End Property

    Public ReadOnly Property OppositeDirection As String Implements ICharacterNavigation.OppositeDirection
        Get
            Return Directions.Descriptors(CurrentDirection).OppositeDirection
        End Get
    End Property

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

    Public ReadOnly Property Direction As ICharacterNavigationDirection Implements ICharacterNavigation.Direction
        Get
            Return New CharacterNavigationDirection(WorldData, CharacterId)
        End Get
    End Property

    Public Sub TurnAround() Implements ICharacterNavigation.TurnAround
        CharacterData.Direction = OppositeDirection
    End Sub

    Public Sub TurnLeft() Implements ICharacterNavigation.TurnLeft
        CharacterData.Direction = LeftDirection
    End Sub

    Public Sub TurnRight() Implements ICharacterNavigation.TurnRight
        CharacterData.Direction = RightDirection
    End Sub

    Public Sub MoveLeft() Implements ICharacterNavigation.MoveLeft
        Move(Directions.Descriptors(CurrentDirection).LeftDirection, "to the left")
    End Sub

    Private Sub Move(direction As String, text As String)
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        If Not character.Location.HasRoute(direction) Then
            character.Messages.Add("You cannot go that way!")
            Return
        End If
        character.Messages.Add($"You move {text}.")
        CharacterData.LocationId = character.Location.Neighbor(direction).Id
        ApplyEffects()
    End Sub

    Public Sub MoveRight() Implements ICharacterNavigation.MoveRight
        Move(Directions.Descriptors(CurrentDirection).RightDirection, " to the right")
    End Sub

    Public Sub MoveAhead() Implements ICharacterNavigation.MoveAhead
        Move(Directions.Descriptors(CurrentDirection).AheadDirection, "")
    End Sub

    Public Sub MoveBack() Implements ICharacterNavigation.MoveBack
        Move(Directions.Descriptors(CurrentDirection).OppositeDirection, " back")
    End Sub
End Class
