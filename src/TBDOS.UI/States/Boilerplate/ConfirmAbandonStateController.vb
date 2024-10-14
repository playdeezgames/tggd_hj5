Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class ConfirmAbandonStateController
    Implements IUIStateController

    Private _screen As CoCoScreen
    Private _world As IWorld

    Public Sub New(screen As CoCoScreen, world As IWorld)
        _screen = screen
        _world = world
    End Sub

    Public Function HandleKeyDown(key As Keys) As String Implements IUIStateController.HandleKeyDown
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

    Public Function Update(ticks As Long) As String Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Are you sure you want to abandonthe game?")
        _screen.WriteLine("[Y]es")
        _screen.WriteLine("[N]o")
        Return UIStates.ConfirmAbandon
    End Function
End Class
