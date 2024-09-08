Imports Microsoft.Xna.Framework.Input

Public Class ConfirmQuitStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Y
                Return UIStates.Quit
            Case Keys.N
                Return UIStates.MainMenu
            Case Else
                Return UIStates.ConfirmQuit
        End Select
    End Function
    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Are you sure you want to quit?")
        _screen.WriteLine("[Y]es")
        _screen.WriteLine("[N]o")
        Return UIStates.ConfirmQuit
    End Function
End Class
