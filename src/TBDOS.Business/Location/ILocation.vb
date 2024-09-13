Public Interface ILocation
    ReadOnly Property Id As Integer
    ReadOnly Property Inventory As ILocationInventory
    ReadOnly Property Routes As ILocationRoutes

    Function Neighbor(direction As String) As ILocation
    Sub AddVisit(character As ICharacter)
End Interface
