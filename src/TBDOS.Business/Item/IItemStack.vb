Public Interface IItemStack
    Sub Remove(amount As Integer)
    ReadOnly Property Quantity As Integer
    Sub Add(amount As Integer)
    ReadOnly Property Has As Boolean
    ReadOnly Property InventoryName As String
    ReadOnly Property ItemTypeName As String
    ReadOnly Property ItemType As String
End Interface
