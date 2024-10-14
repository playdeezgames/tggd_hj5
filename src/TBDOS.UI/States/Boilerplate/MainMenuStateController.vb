Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class MainMenuStateController
    Inherits WorldStateController
    Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world)
    End Sub
    Public Overrides Function HandleKeyDown(key As Keys) As String
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
    Public Overrides Function Update(ticks As Long) As String
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
