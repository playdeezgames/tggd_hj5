Public Class TitleStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Return UIStates.Title
    End Function

    Public Function HandleKeyUp(key As Keys) As UIStates Implements IUIStateController.HandleKeyUp
        Return UIStates.MainMenu
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("TBD of SPLORR!!")
        _screen.WriteLine("A production of TheGrumpyGameDev")
        _screen.GoToXY(0, 15)
        _screen.WriteLine("Press Any Key.")
        Return UIStates.Title
    End Function
End Class
