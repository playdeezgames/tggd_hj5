﻿Public Interface ICharacter
    Sub UseItem(itemType As String)
    ReadOnly Property NextMessage As IEnumerable(Of String)
    Sub TurnAround()
    Sub TurnLeft()
    Sub TurnRight()
    Sub MoveLeft()
    Sub MoveRight()
    Sub MoveAhead()
    Sub MoveBack()
    Property Health As Integer
    ReadOnly Property MaximumHealth As Integer
    Property Satiety As Integer
    ReadOnly Property MaximumSatiety As Integer
    ReadOnly Property Location As ILocation
    Sub RemoveItems(itemType As String, amount As Integer)
    Sub AddMessage(ParamArray lines As String())
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(itemType As String) As Integer
    ReadOnly Property IsStarving As Boolean
    ReadOnly Property IsDead As Boolean
    ReadOnly Property Id As Integer
    ReadOnly Property HasMessages As Boolean
    Function HasItems() As Boolean
    Function HasItem(itemType As String) As Boolean
    ReadOnly Property ExplorationPercentage As Double
    Sub DismissMessage()
    ReadOnly Property Direction As String
    Sub AddItems(value As String, amount As Integer)
    ReadOnly Property AheadDirection As String
    ReadOnly Property LeftDirection As String
    ReadOnly Property RightDirection As String
    ReadOnly Property OppositeDirection As String
End Interface
