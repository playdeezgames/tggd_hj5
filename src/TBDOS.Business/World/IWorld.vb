Public Interface IWorld
    ReadOnly Property Avatar As ICharacter
    ReadOnly Property IsGameOver As Boolean
    Sub Start()
    Sub Abandon()
End Interface
