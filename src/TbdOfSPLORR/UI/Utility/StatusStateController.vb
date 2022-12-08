Friend Class StatusStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Private _world As World
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Return If(key = Keys.Escape, UIStates.InPlay, UIStates.Status)
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Status:")
        _screen.WriteLine($"Health: {_world.PlayerCharacter.Health}/{_world.PlayerCharacter.MaximumHealth}")
        _screen.WriteLine($"Satiety: {_world.PlayerCharacter.Satiety}/{_world.PlayerCharacter.MaximumSatiety}")
        _screen.WriteLine("[esc] Go Back")
        Return UIStates.Status
    End Function
End Class
