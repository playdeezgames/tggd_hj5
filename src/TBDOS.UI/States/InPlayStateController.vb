Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class InPlayStateController
    Inherits MessageStateController
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.InPlay)
    End Sub
    Private Function HandleKeyDownIsDead(key As Keys) As UIStates
        Return If(key = Keys.Escape, UIStates.MainMenu, UIStates.InPlay)
    End Function
    Private Shared Function HandleKeyDownInPlay(key As Keys) As UIStates
        Select Case key
            Case Keys.M
                Return UIStates.Move
            Case Keys.T
                Return UIStates.Turn
            Case Keys.Escape
                Return UIStates.MainMenu
        End Select
        Return UIStates.InPlay
    End Function
    Private Sub UpdateIsDead()
        _screen.WriteLine("Yer dead!")
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub UpdateInPlay()
        _screen.WriteLine("Yer Alive!")
        ShowExits()
        _screen.WriteLine("[T]urn")
        _screen.WriteLine("[M]ove")
        _screen.WriteLine("[S]tatus")
        _screen.WriteLine("[esc] Main Menu")
    End Sub

    Private Sub ShowExits()
        Dim character = _world.Avatar
        Dim routes = character.Location.Routes.All
        Dim directionNames As New List(Of String)
        If character.Navigation.Move.CanMoveAhead Then
            directionNames.Add("ahead")
        End If
        If character.Navigation.Move.CanMoveRight Then
            directionNames.Add("right")
        End If
        If character.Navigation.Move.CanMoveLeft Then
            directionNames.Add("left")
        End If
        If character.Navigation.Move.CanMoveBack Then
            directionNames.Add("behind")
        End If
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
