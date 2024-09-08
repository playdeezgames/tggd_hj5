Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Public MustInherit Class MessageStateController
    Implements IUIStateController
    Protected _screen As CoCoScreen
    Protected _world As World
    Protected _state As UIStates
    Sub New(screen As CoCoScreen, world As World, state As UIStates)
        _screen = screen
        _world = world
        _state = state
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        If _world.PlayerCharacter.HasMessages Then
            Return HandleKeyDownMessage(key)
        Else
            Return HandleKeyDownNonMessage(key)
        End If
    End Function

    Protected MustOverride Function HandleKeyDownNonMessage(key As Keys) As UIStates

    Private Function HandleKeyDownMessage(key As Keys) As UIStates
        _world.PlayerCharacter.DismissMessage()
        Return _state
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        If _world.PlayerCharacter.HasMessages Then
            Return UpdateMessage()
        Else
            Return UpdateNonMessage(ticks)
        End If
    End Function
    Protected MustOverride Function UpdateNonMessage(ticks As Long) As UIStates
    Private Function UpdateMessage() As UIStates
        Dim message = _world.PlayerCharacter.NextMessage
        For Each line In message
            _screen.WriteLine(line)
        Next
        _screen.GoToXY(0, 15)
        _screen.WriteLine("Press any key.")
        Return _state
    End Function
End Class
