Public Interface ICharacterItems
    ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
    Function HasAny() As Boolean
    ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack)
    ReadOnly Property Stack(itemType As String) As ICharacterItemStack

    Sub Use(itemType As String)
    Sub Remove(itemType As String, amount As Integer)
    Function Count(itemType As String) As Integer
    Sub Add(itemType As String, amount As Integer)
    Function Has(itemType As String) As Boolean
End Interface
