Public Interface ICharacterNavigation
    Sub TurnAround()
    Sub TurnLeft()
    Sub TurnRight()

    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveAhead()
    Sub MoveBack()

    ReadOnly Property Direction As String
    ReadOnly Property AheadDirection As String
    ReadOnly Property LeftDirection As String
    ReadOnly Property RightDirection As String
    ReadOnly Property OppositeDirection As String
End Interface
