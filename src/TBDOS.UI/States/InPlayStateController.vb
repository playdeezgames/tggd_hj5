Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class InPlayStateController
    Inherits MessageStateController
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.InPlay)
    End Sub

    Protected Overrides Function OnHandleKeyDown(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.MainMenu
        End Select
        Return UIStates.InPlay
    End Function

    Protected Overrides Function OnUpdate(ticks As Long) As UIStates
        _screen.WriteLine("Yer Alive!")
        _screen.WriteLine("[esc] Main Menu")
        Return _state
    End Function
End Class
