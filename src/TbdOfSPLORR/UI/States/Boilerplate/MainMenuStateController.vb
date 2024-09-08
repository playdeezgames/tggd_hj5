Imports TBDOS.Business

Public Class MainMenuStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Private _world As World
    Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
    End Sub
    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        Select Case key
            Case Keys.A
                If Not _world.IsGameOver Then
                    Return UIStates.ConfirmAbandon
                End If
            Case Keys.C
                If Not _world.IsGameOver Then
                    Return UIStates.InPlay
                End If
            Case Keys.O
                Return UIStates.Options
            Case Keys.Q
                If _world.IsGameOver Then
                    Return UIStates.ConfirmQuit
                End If
            Case Keys.S
                If _world.IsGameOver Then
                    _world.Start()
                    Return UIStates.InPlay
                End If
            Case Else
        End Select
        Return UIStates.MainMenu
    End Function
    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        _screen.WriteLine("Main Menu:")
        If _world.IsGameOver Then
            _screen.WriteLine("[S]tart!")
        Else
            _screen.WriteLine("[C]ontinue!")
        End If
        _screen.WriteLine("[O]ptions...")
        If _world.IsGameOver Then
            _screen.WriteLine("[Q]uit")
        Else
            _screen.WriteLine("[A]bandon Game")
        End If
        Return UIStates.MainMenu
    End Function
End Class
