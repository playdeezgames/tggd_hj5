Public Interface IWorld
    ReadOnly Property PlayerCharacter As Character
    ReadOnly Property IsGameOver As Boolean
    Sub Start()
    Sub AbandonGame()
End Interface
