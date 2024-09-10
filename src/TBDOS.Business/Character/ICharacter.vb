Public Interface ICharacter
    ReadOnly Property Messages As ICharacterMessages
    ReadOnly Property Items As ICharacterItems
    ReadOnly Property Navigation As ICharacterNavigation

    Property Health As Integer
    ReadOnly Property MaximumHealth As Integer

    Property Satiety As Integer
    ReadOnly Property MaximumSatiety As Integer

    ReadOnly Property ExplorationPercentage As Double

    ReadOnly Property Location As ILocation
    ReadOnly Property Id As Integer

    ReadOnly Property IsStarving As Boolean
    ReadOnly Property IsDead As Boolean

End Interface
