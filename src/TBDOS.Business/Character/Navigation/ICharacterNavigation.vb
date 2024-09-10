Public Interface ICharacterNavigation
    ReadOnly Property Turn As ICharacterNavigationTurn
    ReadOnly Property Move As ICharacterNavigationMove
    ReadOnly Property Direction As ICharacterNavigationDirection
    Sub TurnAround()
    Sub TurnLeft()
    Sub TurnRight()

    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveAhead()
    Sub MoveBack()

    ReadOnly Property CurrentDirection As String
    ReadOnly Property AheadDirection As String
    ReadOnly Property LeftDirection As String
    ReadOnly Property RightDirection As String
    ReadOnly Property OppositeDirection As String
End Interface
