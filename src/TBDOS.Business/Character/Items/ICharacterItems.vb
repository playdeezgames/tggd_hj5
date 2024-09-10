Public Interface ICharacterItems
    ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
    Function HasAny() As Boolean

    Sub UseItem(itemType As String)
    Sub RemoveItems(itemType As String, amount As Integer)
    Function ItemCount(itemType As String) As Integer
    Sub AddItems(itemType As String, amount As Integer)
    Function HasItem(itemType As String) As Boolean
End Interface
