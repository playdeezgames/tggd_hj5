Friend Class OptionsStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Public Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Escape
                Return UIStates.MainMenu
            Case Else
                Return UIStates.Options
        End Select
    End Function

    Public Function HandleKeyUp(key As Keys) As UIStates Implements IUIStateController.HandleKeyUp
        Return UIStates.Options
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Options:")
        _screen.WriteLine("[esc] Go Back")
        Return UIStates.Options
    End Function
End Class
