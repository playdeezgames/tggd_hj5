Public Interface ICharacterNavigation
    ReadOnly Property Turn As ICharacterNavigationTurn
    ReadOnly Property Move As ICharacterNavigationMove
    ReadOnly Property LegacyDirection As ICharacterNavigationDirection
    Property Direction As String
End Interface
