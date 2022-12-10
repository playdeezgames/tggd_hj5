Public Class Character
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub
    ReadOnly Property Items As Dictionary(Of ItemTypes, Integer)
        Get
            Return _worldData.Characters(Id).Items.ToDictionary(Function(x) CType(x.Key, ItemTypes), Function(x) x.Value)
        End Get
    End Property

    Friend Sub TurnAround()
        _worldData.Characters(Id).Direction = CInt(Direction.OppositeDirection)
    End Sub

    Friend Sub TurnLeft()
        _worldData.Characters(Id).Direction = CInt(Direction.LeftDirection)
    End Sub

    Friend Sub TurnRight()
        _worldData.Characters(Id).Direction = CInt(Direction.RightDirection)
    End Sub

    Friend Sub MoveAhead()
        Move(Direction.AheadDirection, "ahead")
    End Sub

    Private Sub Move(direction As Directions, text As String)
        If Not Location.HasRoute(direction) Then
            AddMessage("You cannot go that way!")
            Return
        End If
        AddMessage($"You move {text}.")
        _worldData.Characters(Id).LocationId = Location.Neighbor(direction).Id
        ApplyEffects()
    End Sub

    Private Sub ApplyEffects()
        AddHunger(1)
        Location.AddVisit(Me)
    End Sub
    Friend ReadOnly Property ExplorationPercentage As Double
        Get
            Return 100.0 * _worldData.Locations.Where(Function(x) x.VisitedBy.Contains(Id)).Count / _worldData.Locations.Count
        End Get
    End Property

    Private Sub AddHunger(amount As Integer)
        If Not IsStarving Then
            Hunger += amount
        Else
            Wounds += amount
        End If
    End Sub

    Friend Sub AddMessage(ParamArray lines As String())
        If Id <> _worldData.PlayerCharacterId Then
            Return
        End If
        _worldData.Characters(Id).Messages.Add(lines)
    End Sub

    Friend Sub MoveBack()
        Move(Direction.OppositeDirection, "back")
    End Sub

    Friend Sub MoveLeft()
        Move(Direction.LeftDirection, "to the left")
    End Sub

    Friend Sub MoveRight()
        Move(Direction.RightDirection, "to the right")
    End Sub

    Friend Sub DismissMessage()
        If HasMessages Then
            _worldData.Characters(Id).Messages.RemoveAt(0)
        End If
    End Sub

    Friend ReadOnly Property IsStarving As Boolean
        Get
            Return Satiety = 0
        End Get
    End Property
    Friend ReadOnly Property IsDead As Boolean
        Get
            Return Health = 0
        End Get
    End Property
    Friend Property Satiety As Integer
        Get
            Return MaximumSatiety - Hunger
        End Get
        Set(value As Integer)
            Hunger = MaximumSatiety - value
        End Set
    End Property
    Friend Property Health As Integer
        Get
            Return MaximumHealth - Wounds
        End Get
        Set(value As Integer)
            Wounds = MaximumHealth - value
        End Set
    End Property
    Friend ReadOnly Property MaximumSatiety As Integer
        Get
            Return GetStatistic(StatisticTypes.MaximumSatiety)
        End Get
    End Property
    Friend ReadOnly Property MaximumHealth As Integer
        Get
            Return GetStatistic(StatisticTypes.MaximumHealth)
        End Get
    End Property

    Private Function GetStatistic(statisticType As StatisticTypes) As Integer
        Return _worldData.Characters(Id).statistics(statisticType)
    End Function

    Private Property Hunger As Integer
        Get
            Return GetStatistic(StatisticTypes.Hunger)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Hunger, Clamp(value, 0, MaximumSatiety))
        End Set
    End Property

    Private Property Wounds As Integer
        Get
            Return GetStatistic(StatisticTypes.Wounds)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Wounds, Clamp(value, 0, MaximumHealth))
        End Set
    End Property

    Private Sub SetStatistic(statisticType As StatisticTypes, value As Integer)
        _worldData.Characters(Id).Statistics(statisticType) = value
    End Sub

    Friend Sub AddItems(value As ItemTypes, amount As Integer)
        If _worldData.Characters(Id).Items.ContainsKey(value) Then
            _worldData.Characters(Id).Items(value) += amount
        Else
            _worldData.Characters(Id).Items(value) = amount
        End If
    End Sub

    Friend Function HasItems() As Boolean
        Return _worldData.Characters(Id).Items.Any
    End Function

    Friend Function HasItem(itemType As ItemTypes) As Boolean
        Return _worldData.Characters(Id).Items.ContainsKey(itemType)
    End Function

    Friend Function ItemCount(itemType As ItemTypes) As Integer
        If _worldData.Characters(Id).Items.ContainsKey(itemType) Then
            Return _worldData.Characters(Id).Items(itemType)
        End If
        Return 0
    End Function

    Friend Sub RemoveItems(itemType As ItemTypes, amount As Integer)
        _worldData.Characters(Id).Items(itemType) -= amount
        If _worldData.Characters(Id).Items(itemType) <= 0 Then
            _worldData.Characters(Id).Items.Remove(itemType)
        End If
    End Sub

    Friend Sub UseItem(itemType As ItemTypes)
        If itemType.CanUse Then
            RemoveItems(itemType, 1)
            Select Case itemType
                Case ItemTypes.Food
                    UseFood()
                Case ItemTypes.Medicine
                    UseMedicine()
            End Select
        End If
    End Sub

    Private Sub UseMedicine()
        Health += 10
        AddMessage("You use the medicine.", $"Yer health is now {Health}/{MaximumHealth}")
    End Sub

    Private Sub UseFood()
        Satiety += 10
        AddMessage("You eat the food.", $"Yer satiety is now {Satiety}/{MaximumSatiety}")
    End Sub

    Friend ReadOnly Property NextMessage As IEnumerable(Of String)
        Get
            If Not HasMessages Then
                Return Array.Empty(Of String)
            End If
            Return _worldData.Characters(Id).Messages.First
        End Get
    End Property

    Friend ReadOnly Property HasMessages As Boolean
        Get
            Return _worldData.Characters(Id).Messages.Any
        End Get
    End Property

    ReadOnly Property Location As Location
        Get
            Return New Location(_worldData, _worldData.Characters(Id).LocationId)
        End Get
    End Property
    ReadOnly Property Direction As Directions
        Get
            Return CType(_worldData.Characters(Id).Direction, Directions)
        End Get
    End Property
End Class
