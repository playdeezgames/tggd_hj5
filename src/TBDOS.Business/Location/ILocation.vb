Public Interface ILocation
    ReadOnly Property Id As Integer
    Function Neighbor(direction As String) As ILocation
    Sub AddVisit(character As ICharacter)

    Function HasRoute(direction As String) As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)


    Sub RemoveItems(itemType As String, amount As Integer)
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(value As String) As Integer
    ReadOnly Property HasItems As Boolean
    Function HasItem(itemType As String) As Boolean
    Sub AddItems(value As String, amount As Integer)
    ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
End Interface
