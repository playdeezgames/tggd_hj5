Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class ConfirmAbandonStateController
    Inherits WorldStateController

    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world)
    End Sub

    Public Overrides Function HandleKeyDown(key As Keys) As String
        Select Case key
            Case Keys.Y
                _world.Abandon()
                Return UIStates.MainMenu
            Case Keys.N
                Return UIStates.MainMenu
            Case Else
                Return UIStates.ConfirmAbandon
        End Select
    End Function

    Public Overrides Function Update(ticks As Long) As String
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Are you sure you want to abandonthe game?")
        _screen.WriteLine("[Y]es")
        _screen.WriteLine("[N]o")
        Return UIStates.ConfirmAbandon
    End Function
End Class
