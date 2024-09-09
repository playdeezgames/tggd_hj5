Public Interface ICharacter
    Sub UseItem(itemType As String)
    Sub RemoveItems(itemType As String, amount As Integer)
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(itemType As String) As Integer
    Sub AddItems(itemType As String, amount As Integer)
    Function HasItems() As Boolean
    Function HasItem(itemType As String) As Boolean

    ReadOnly Property NextMessage As IEnumerable(Of String)
    Sub AddMessage(ParamArray lines As String())
    ReadOnly Property HasMessages As Boolean
    Sub DismissMessage()

    Sub TurnAround()
    Sub TurnLeft()
    Sub TurnRight()

    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveAhead()
    Sub MoveBack()

    ReadOnly Property Direction As String
    ReadOnly Property AheadDirection As String
    ReadOnly Property LeftDirection As String
    ReadOnly Property RightDirection As String
    ReadOnly Property OppositeDirection As String

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
