Friend Class MoveStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Private ReadOnly _world As World
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
            Case Keys.A
                _world.PlayerCharacter.MoveAhead()
                Return UIStates.InPlay
            Case Keys.B
                _world.PlayerCharacter.MoveBack()
                Return UIStates.InPlay
            Case Keys.L
                _world.PlayerCharacter.MoveLeft()
                Return UIStates.InPlay
            Case Keys.R
                _world.PlayerCharacter.MoveRight()
                Return UIStates.InPlay
        End Select
        Return UIStates.Move
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Move which way?")
        _screen.WriteLine("[esc] Never mind")
        _screen.WriteLine("[A]head")
        _screen.WriteLine("[L]eft")
        _screen.WriteLine("[R]ight")
        _screen.WriteLine("[B]ack")
        Return UIStates.Move
    End Function
End Class
