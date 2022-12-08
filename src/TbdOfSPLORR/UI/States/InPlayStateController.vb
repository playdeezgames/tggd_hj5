Friend Class InPlayStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Private ReadOnly _world As World
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.T
                Return UIStates.Turn
            Case Keys.Escape
                Return UIStates.MainMenu
            Case Else
                Return UIStates.InPlay
        End Select
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Yer Alive!")
        ShowExits()
        _screen.WriteLine("[T]urn")
        _screen.WriteLine("[esc] Main Menu")
        Return UIStates.InPlay
    End Function

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
