Imports Microsoft.Xna.Framework.Input

Friend Interface IUIStateController
    Function HandleKeyDown(key As Keys) As String
    Function Update(ticks As Long) As String
End Interface
