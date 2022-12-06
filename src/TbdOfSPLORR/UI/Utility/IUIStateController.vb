Public Interface IUIStateController
    Function HandleKeyDown(key As Keys) As UIStates
    Function Update(ticks As Long) As UIStates
End Interface
