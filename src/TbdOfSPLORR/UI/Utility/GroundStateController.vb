Friend Class GroundStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Private _world As World
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
        End Select
        Return UIStates.Ground
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("On the ground:")
        _screen.WriteLine(String.Join(", ", _world.PlayerCharacter.Location.Items.Select(Function(x) $"{x.Key.InventoryName}(x{x.Value})")))
        _screen.WriteLine("[esc] Go Back")
        Return UIStates.Ground
    End Function
End Class
