Public Interface IWorld
    ReadOnly Property PlayerCharacter As ICharacter
    ReadOnly Property IsGameOver As Boolean
    Sub Start()
    Sub AbandonGame()
End Interface
