Public Class MainMenuStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub
    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Q
                Return UIStates.ConfirmQuit
            Case Else
                Return UIStates.MainMenu
        End Select
    End Function
    Public Function HandleKeyUp(key As Keys) As UIStates Implements IUIStateController.HandleKeyUp
        Return UIStates.MainMenu
    End Function
    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Main Menu:")
        _screen.WriteLine("[Q]uit")
        Return UIStates.MainMenu
    End Function
End Class
