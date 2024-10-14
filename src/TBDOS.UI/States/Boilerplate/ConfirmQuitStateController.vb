Imports Microsoft.Xna.Framework.Input

Friend Class ConfirmQuitStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Y
                Return UIStates.Quit
            Case Keys.N
                Return UIStates.MainMenu
            Case Else
                Return UIStates.ConfirmQuit
        End Select
    End Function
    Public Function Update(ticks As Long) As String Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Are you sure you want to quit?")
        _screen.WriteLine("[Y]es")
        _screen.WriteLine("[N]o")
        Return UIStates.ConfirmQuit
    End Function
End Class
