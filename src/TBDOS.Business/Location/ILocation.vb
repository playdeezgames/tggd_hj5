Public Interface ILocation
    ReadOnly Property Id As Integer
    ReadOnly Property Inventory As ILocationInventory

    Function Neighbor(direction As String) As ILocation
    Sub AddVisit(character As ICharacter)

    Function HasRoute(direction As String) As Boolean
    ReadOnly Property Routes As IEnumerable(Of IRoute)

    ReadOnly Property LegacyInventory As IEnumerable(Of (InventoryName As String, Quantity As Integer))
End Interface
