Imports Microsoft.Xna.Framework.Input

Friend Class QuitStateController
    Implements IUIStateController
    Public Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
        Return UIStates.Quit
    End Function
    Public Function Update(ticks As Long) As String Implements IUIStateController.Update
        Return UIStates.Quit
    End Function
End Class
