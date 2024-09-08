Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class TurnStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Private _world As World

    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.A
                _world.PlayerCharacter.TurnAround()
                Return UIStates.InPlay
            Case Keys.Escape
                Return UIStates.InPlay
            Case Keys.L
                _world.PlayerCharacter.TurnLeft()
                Return UIStates.InPlay
            Case Keys.R
                _world.PlayerCharacter.TurnRight()
                Return UIStates.InPlay
        End Select
        Return UIStates.Turn
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Turn which way?")
        _screen.WriteLine("[esc] Never Mind")
        _screen.WriteLine("[L]eft")
        _screen.WriteLine("[R]ight")
        _screen.WriteLine("[A]round")
        Return UIStates.Turn
    End Function
End Class
