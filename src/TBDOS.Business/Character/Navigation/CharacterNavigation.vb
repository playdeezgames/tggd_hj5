Friend Class CharacterNavigation
    Inherits CharacterDataClient
    Implements ICharacterNavigation
    Private ReadOnly applyEffects As Action

    Public Sub New(worldData As Data.WorldData, characterId As Integer, applyEffects As Action)
        MyBase.New(worldData, characterId)
        Me.applyEffects = applyEffects
    End Sub

    Public ReadOnly Property Direction As String Implements ICharacterNavigation.Direction
        Get
            Return CharacterData.Direction
        End Get
    End Property

    Public ReadOnly Property AheadDirection As String Implements ICharacterNavigation.AheadDirection
        Get
            Return Directions.Descriptors(Direction).AheadDirection
        End Get
    End Property

    Public ReadOnly Property LeftDirection As String Implements ICharacterNavigation.LeftDirection
        Get
            Return Directions.Descriptors(Direction).LeftDirection
        End Get
    End Property

    Public ReadOnly Property RightDirection As String Implements ICharacterNavigation.RightDirection
        Get
            Return Directions.Descriptors(Direction).RightDirection
        End Get
    End Property

    Public ReadOnly Property OppositeDirection As String Implements ICharacterNavigation.OppositeDirection
        Get
            Return Directions.Descriptors(Direction).OppositeDirection
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
        Move(Directions.Descriptors(Direction).LeftDirection, "to the left")
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
        Throw New NotImplementedException()
    End Sub

    Public Sub MoveAhead() Implements ICharacterNavigation.MoveAhead
        Throw New NotImplementedException()
    End Sub

    Public Sub MoveBack() Implements ICharacterNavigation.MoveBack
        Throw New NotImplementedException()
    End Sub
End Class
