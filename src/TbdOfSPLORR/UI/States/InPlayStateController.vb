Friend Class InPlayStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Private ReadOnly _world As World
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        If _world.PlayerCharacter.HasMessages Then
            HandleKeyDownMessage()
            Return UIStates.InPlay
        Else
            Return HandleKeyDownInPlay(key)
        End If
    End Function

    Private Shared Function HandleKeyDownInPlay(key As Keys) As UIStates
        Select Case key
            Case Keys.M
                Return UIStates.Move
            Case Keys.T
                Return UIStates.Turn
            Case Keys.Escape
                Return UIStates.MainMenu
            Case Else
                Return UIStates.InPlay
        End Select
    End Function

    Private Sub HandleKeyDownMessage()
        _world.PlayerCharacter.DismissMessage()
    End Sub

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        If _world.PlayerCharacter.HasMessages Then
            UpdateMessage()
        Else
            UpdateInPlay()
        End If
        Return UIStates.InPlay
    End Function

    Private Sub UpdateInPlay()
        _screen.WriteLine("Yer Alive!")
        ShowExits()
        _screen.WriteLine("[T]urn")
        _screen.WriteLine("[M]ove")
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub UpdateMessage()
        Dim message = _world.PlayerCharacter.NextMessage
        For Each line In message
            _screen.WriteLine(line)
        Next
        _screen.WriteLine("Press any key.")
    End Sub

    Private Sub ShowExits()
        Dim character = _world.PlayerCharacter
        Dim routes = character.Location.Routes
        Dim directionNames As New List(Of String)
        If routes.Any(Function(x) x.Direction = character.Direction.AheadDirection) Then
            directionNames.Add("ahead")
        End If
        If routes.Any(Function(x) x.Direction = character.Direction.RightDirection) Then
            directionNames.Add("right")
        End If
        If routes.Any(Function(x) x.Direction = character.Direction.LeftDirection) Then
            directionNames.Add("left")
        End If
        If routes.Any(Function(x) x.Direction = character.Direction.OppositeDirection) Then
            directionNames.Add("behind")
        End If
        _screen.WriteLine($"Exits: {String.Join(", ", directionNames)}")
    End Sub
End Class
