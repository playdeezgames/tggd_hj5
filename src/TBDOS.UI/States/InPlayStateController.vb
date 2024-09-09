Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class InPlayStateController
    Inherits MessageStateController
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.InPlay)
    End Sub
    Private Function HandleKeyDownIsDead(key As Keys) As UIStates
        Return If(key = Keys.Escape, UIStates.MainMenu, UIStates.InPlay)
    End Function
    Private Shared Function HandleKeyDownInPlay(key As Keys) As UIStates
        Select Case key
            Case Keys.G
                Return UIStates.Ground
            Case Keys.I
                Return UIStates.Inventory
            Case Keys.M
                Return UIStates.Move
            Case Keys.S
                Return UIStates.Status
            Case Keys.T
                Return UIStates.Turn
            Case Keys.Escape
                Return UIStates.MainMenu
        End Select
        Return UIStates.InPlay
    End Function
    Private Sub UpdateIsDead()
        _screen.WriteLine("Yer dead!")
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub UpdateInPlay()
        _screen.WriteLine("Yer Alive!")
        If _world.PlayerCharacter.IsStarving Then
            _screen.WriteLine("Yer starving!")
        End If
        ShowExits()
        _screen.WriteLine("[T]urn")
        _screen.WriteLine("[M]ove")
        _screen.WriteLine("[S]tatus")
        If _world.PlayerCharacter.Location.HasItems Then
            _screen.WriteLine("[G]round")
        End If
        If _world.PlayerCharacter.Items.HasItems Then
            _screen.WriteLine("[I]nventory")
        End If
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub ShowExits()
        Dim character = _world.PlayerCharacter
        Dim routes = character.Location.Routes
        Dim directionNames As New List(Of String)
        If routes.Any(Function(x) x.Direction = character.AheadDirection) Then
            directionNames.Add("ahead")
        End If
        If routes.Any(Function(x) x.Direction = character.RightDirection) Then
            directionNames.Add("right")
        End If
        If routes.Any(Function(x) x.Direction = character.LeftDirection) Then
            directionNames.Add("left")
        End If
        If routes.Any(Function(x) x.Direction = character.OppositeDirection) Then
            directionNames.Add("behind")
        End If
        _screen.WriteLine($"Exits: {String.Join(", ", directionNames)}")
    End Sub

    Protected Overrides Function HandleKeyDownNonMessage(key As Keys) As UIStates
        If _world.PlayerCharacter.IsDead Then
            Return HandleKeyDownIsDead(key)
        Else
            Return HandleKeyDownInPlay(key)
        End If
    End Function

    Protected Overrides Function UpdateNonMessage(ticks As Long) As UIStates
        If _world.PlayerCharacter.IsDead Then
            UpdateIsDead()
        Else
            UpdateInPlay()
        End If
        Return _state
    End Function
End Class
