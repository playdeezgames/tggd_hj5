Public Interface ICharacterItems
    ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
    Function HasAny() As Boolean

    Sub Use(itemType As String)
    Sub Remove(itemType As String, amount As Integer)
    Function Count(itemType As String) As Integer
    Sub Add(itemType As String, amount As Integer)
    Function Has(itemType As String) As Boolean
End Interface
