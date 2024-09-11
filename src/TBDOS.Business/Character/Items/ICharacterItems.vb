Public Interface ICharacterItems
    ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
    Function HasAny() As Boolean
    ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack)
    ReadOnly Property Stack(itemType As String) As ICharacterItemStack
End Interface
