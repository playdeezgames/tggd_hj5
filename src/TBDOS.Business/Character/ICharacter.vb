Public Interface ICharacter
    ReadOnly Property Id As Integer
    ReadOnly Property Location As ILocation
    ReadOnly Property Messages As ICharacterMessages
    ReadOnly Property Navigation As ICharacterNavigation
End Interface
