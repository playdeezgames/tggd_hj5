Public Interface ILocationInventory
    ReadOnly Property Stacks As IEnumerable(Of ILocationItemStack)
    ReadOnly Property Stack(itemType As String) As ILocationItemStack

    ReadOnly Property HasItems As Boolean
End Interface
