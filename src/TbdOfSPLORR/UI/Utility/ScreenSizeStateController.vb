Imports System.ComponentModel.Design

Friend Class ScreenSizeStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Public Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Escape
                Return UIStates.Options
            Case Else
                Return UIStates.ScreenSize
        End Select
    End Function
    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Screen Size:")
        _screen.WriteLine("[Esc] Go Back")
        Return UIStates.ScreenSize
    End Function
End Class
