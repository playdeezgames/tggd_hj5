Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class InPlayStateController
    Inherits MessageStateController
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.InPlay)
    End Sub
    Private Shared Function HandleKeyDownInPlay(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.MainMenu
        End Select
        Return UIStates.InPlay
    End Function
    Private Sub UpdateInPlay()
        _screen.WriteLine("Yer Alive!")
        ShowExits()
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub ShowExits()
        Dim character = _world.Avatar
        Dim directionNames As New List(Of String)
        _screen.WriteLine($"Exits: {String.Join(", ", directionNames)}")
    End Sub

    Protected Overrides Function HandleKeyDownNonMessage(key As Keys) As UIStates
        Return HandleKeyDownInPlay(key)
    End Function

    Protected Overrides Function UpdateNonMessage(ticks As Long) As UIStates
        UpdateInPlay()
        Return _state
    End Function
End Class
