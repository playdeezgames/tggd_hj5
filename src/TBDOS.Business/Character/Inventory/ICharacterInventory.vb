Public Interface ICharacterInventory
    Function HasAny() As Boolean
    ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack)
    ReadOnly Property Stack(itemType As String) As ICharacterItemStack
    Sub Take(itemStack As ILocationItemStack, amount As Integer)
    Sub Drop(itemStack As ICharacterItemStack, amount As Integer)
End Interface
