Imports Microsoft.Xna.Framework.Input

Friend Class OptionsStateController
    Inherits BaseStateController
    Public Sub New(screen As CoCoScreen)
        MyBase.New(screen)
    End Sub

    Public Overrides Function HandleKeyDown(key As Keys) As String
        Select Case key
            Case Keys.Escape
                Return UIStates.MainMenu
            Case Keys.S
                Return UIStates.ScreenSize
            Case Else
                Return UIStates.Options
        End Select
    End Function
    Public Overrides Function Update(ticks As Long) As String
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Options:")
        _screen.WriteLine("[S]creen Size...")
        _screen.WriteLine("[esc] Go Back")
        Return UIStates.Options
    End Function
End Class
