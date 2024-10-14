﻿Imports Microsoft.Xna.Framework.Input

Friend Class ScreenSizeStateController
    Inherits BaseStateController
    Private ReadOnly _screenSizer As Action(Of Integer)
    Public Sub New(screen As CoCoScreen, screenSizer As Action(Of Integer))
        MyBase.New(screen)
        _screenSizer = screenSizer
    End Sub

    Public Overrides Function HandleKeyDown(key As Keys) As String
        Select Case key
            Case Keys.D1 To Keys.D9
                _screenSizer(CInt(key - Keys.D0))
                Return UIStates.ScreenSize
            Case Keys.Escape
                Return UIStates.Options
            Case Else
                Return UIStates.ScreenSize
        End Select
    End Function
    Public Overrides Function Update(ticks As Long) As String
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Screen Size:")
        For index = 1 To 9
            _screen.WriteLine($"[{index}] {index * 320} x {index * 240}")
        Next
        _screen.WriteLine("[Esc] Go Back")
        Return UIStates.ScreenSize
    End Function
End Class
