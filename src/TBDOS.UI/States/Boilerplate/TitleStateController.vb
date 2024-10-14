Imports Microsoft.Xna.Framework.Input

Friend Class TitleStateController
    Inherits BaseStateController
    Sub New(screen As CoCoScreen)
        MyBase.New(screen)
    End Sub

    Public Overrides Function HandleKeyDown(key As Keys) As String
        Return UIStates.MainMenu
    End Function
    Public Overrides Function Update(ticks As Long) As String
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("TBD of SPLORR!!")
        _screen.WriteLine("A production of TheGrumpyGameDev")
        _screen.GoToXY(0, 15)
        _screen.WriteLine("Press Any Key.")
        Return UIStates.Title
    End Function
End Class
