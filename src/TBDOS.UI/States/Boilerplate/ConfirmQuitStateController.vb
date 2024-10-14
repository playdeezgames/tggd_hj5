Imports Microsoft.Xna.Framework.Input

Friend Class ConfirmQuitStateController
    Inherits BaseStateController
    Sub New(screen As CoCoScreen)
        MyBase.New(screen)
    End Sub
    Public Overrides Function HandleKeyDown(key As Keys) As String
        Select Case key
            Case Keys.Y
                Return UIStates.Quit
            Case Keys.N
                Return UIStates.MainMenu
            Case Else
                Return UIStates.ConfirmQuit
        End Select
    End Function
    Public Overrides Function Update(ticks As Long) As String
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Are you sure you want to quit?")
        _screen.WriteLine("[Y]es")
        _screen.WriteLine("[N]o")
        Return UIStates.ConfirmQuit
    End Function
End Class
