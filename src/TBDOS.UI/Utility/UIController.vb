Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class UIController
    Private _screenBuffer As New List(Of Byte)
    Private _screen As CoCoScreen
    Private _uiState As UIStates
    Private _world As IWorld
    Private ReadOnly _states As New Dictionary(Of UIStates, IUIStateController)
    Public ReadOnly Property UIState As UIStates
        Get
            Return _uiState
        End Get
    End Property
    Friend ReadOnly Property ScreenBuffer As Byte()
        Get
            Return _screenBuffer.ToArray
        End Get
    End Property
    Sub New(uiScaler As Action(Of Integer))
        While _screenBuffer.Count < 512
            _screenBuffer.Add(96)
        End While
        _screen = New CoCoScreen(_screenBuffer, 32, 96)
        _states.Add(UIStates.Title, New TitleStateController(_screen))
        _states.Add(UIStates.MainMenu, New MainMenuStateController(_screen, _world))
        _states.Add(UIStates.Quit, New QuitStateController())
        _states.Add(UIStates.ConfirmQuit, New ConfirmQuitStateController(_screen))
        _states.Add(UIStates.ConfirmAbandon, New ConfirmAbandonStateController(_screen, _world))
        _states.Add(UIStates.Options, New OptionsStateController(_screen))
        _states.Add(UIStates.InPlay, New InPlayStateController(_screen, _world))
        _states.Add(UIStates.ScreenSize, New ScreenSizeStateController(_screen, uiScaler))
        _states.Add(UIStates.Turn, New TurnStateController(_screen, _world))
        _states.Add(UIStates.Move, New MoveStateController(_screen, _world))
        _states.Add(UIStates.Status, New StatusStateController(_screen, _world))
        _states.Add(UIStates.Ground, New GroundStateController(_screen, _world))
        _states.Add(UIStates.Inventory, New InventoryStateController(_screen, _world))
    End Sub
    Friend Sub HandleKeyDown(key As Keys)
        _uiState = _states(_uiState).HandleKeyDown(key)
    End Sub
    Friend Sub Update(ticks As Long)
        _uiState = _states(_uiState).Update(ticks)
    End Sub
End Class
