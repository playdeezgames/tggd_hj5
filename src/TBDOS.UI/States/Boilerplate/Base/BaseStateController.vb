Imports Microsoft.Xna.Framework.Input

Friend MustInherit Class BaseStateController
    Implements IUIStateController
    Protected ReadOnly _screen As CoCoScreen
    Protected Sub New(screen As CoCoScreen)
        _screen = screen
    End Sub
    Public MustOverride Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
    Public MustOverride Function Update(ticks As Long) As String Implements IUIStateController.Update
End Class
