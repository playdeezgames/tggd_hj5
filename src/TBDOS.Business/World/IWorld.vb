Public Interface IWorld
    ReadOnly Property Avatar As ICharacter
    ReadOnly Property IsGameOver As Boolean
    Sub Start()
    Sub AbandonGame()

    ReadOnly Property AllItemTypes As IEnumerable(Of String)
End Interface
