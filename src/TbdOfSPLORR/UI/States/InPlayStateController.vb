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
        _screen.WriteLine("[esc] Main Menu")
        Return UIStates.InPlay
    End Function
End Class
