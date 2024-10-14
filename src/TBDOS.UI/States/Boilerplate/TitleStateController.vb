Imports Microsoft.Xna.Framework.Input

Friend Class TitleStateController
    Implements IUIStateController
    Private ReadOnly _screen As CoCoScreen
    Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub

    Public Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
        Return UIStates.MainMenu
    End Function
    Public Function Update(ticks As Long) As String Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("TBD of SPLORR!!")
        _screen.WriteLine("A production of TheGrumpyGameDev")
        _screen.GoToXY(0, 15)
        _screen.WriteLine("Press Any Key.")
        Return UIStates.Title
    End Function
End Class
