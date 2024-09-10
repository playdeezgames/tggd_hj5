Public Interface IWorld
    ReadOnly Property PlayerCharacter As ICharacter
    ReadOnly Property IsGameOver As Boolean
    Sub Start()
    Sub AbandonGame()

    Function ItemTypeName(itemType As String) As String
    Function InventoryName(itemType As String) As String
    Function CanUse(itemType As String) As Boolean
    ReadOnly Property AllItemTypes As IEnumerable(Of String)
End Interface
