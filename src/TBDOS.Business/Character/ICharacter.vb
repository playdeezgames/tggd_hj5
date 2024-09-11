Public Interface ICharacter
    ReadOnly Property Id As Integer
    ReadOnly Property Location As ILocation
    ReadOnly Property Messages As ICharacterMessages
    ReadOnly Property Inventory As ICharacterInventory
    ReadOnly Property Navigation As ICharacterNavigation
    ReadOnly Property Statistics As ICharacterStatistics
    ReadOnly Property Status As ICharacterStatus
End Interface
