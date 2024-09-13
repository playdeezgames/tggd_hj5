Public Interface ICharacterNavigationMove
    Sub Left()
    Sub Right()
    Sub Ahead()
    Sub Back()
    ReadOnly Property CanMoveAhead As Boolean
    ReadOnly Property CanMoveRight As Boolean
    ReadOnly Property CanMoveLeft As Boolean
    ReadOnly Property CanMoveBack As Boolean
End Interface
