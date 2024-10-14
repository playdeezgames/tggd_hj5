Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend MustInherit Class MessageStateController
    Implements IUIStateController
    Protected _screen As CoCoScreen
    Protected _world As IWorld
    Protected _state As String
    Sub New(screen As CoCoScreen, world As IWorld, state As String)
        _screen = screen
        _world = world
        _state = state
    End Sub

    Public Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
        If _world.Avatar.Messages.HasAny Then
            Return HandleKeyDownMessage(key)
        Else
            Return OnHandleKeyDown(key)
        End If
    End Function

    Protected MustOverride Function OnHandleKeyDown(key As Keys) As String

    Private Function HandleKeyDownMessage(key As Keys) As String
        _world.Avatar.Messages.Dismiss()
        Return _state
    End Function

    Public Function Update(ticks As Long) As String Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        If _world.Avatar.Messages.HasAny Then
            Return UpdateMessage()
        Else
            Return OnUpdate(ticks)
        End If
    End Function
    Protected MustOverride Function OnUpdate(ticks As Long) As String
    Private Function UpdateMessage() As String
        Dim message = _world.Avatar.Messages.Current
        For Each line In message
            _screen.WriteLine(line)
        Next
        _screen.GoToXY(0, 15)
        _screen.WriteLine("Press any key.")
        Return _state
    End Function
End Class
