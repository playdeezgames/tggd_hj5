Public Interface ILocationInventory
    ReadOnly Property Stacks As IEnumerable(Of ILocationItemStack)
    ReadOnly Property Stack(itemType As String) As ILocationItemStack

    Sub RemoveItems(itemType As String, amount As Integer)
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(value As String) As Integer
    ReadOnly Property HasItems As Boolean
    Function HasItem(itemType As String) As Boolean
    Sub AddItems(value As String, amount As Integer)
End Interface
