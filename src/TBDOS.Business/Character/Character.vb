Imports TBDOS.Data

Public Class Character
    Implements ICharacter
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer) Implements ICharacter.Items
        Get
            Return _worldData.Characters(Id).Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public Sub TurnAround() Implements ICharacter.TurnAround
        _worldData.Characters(Id).Direction = (OppositeDirection)
    End Sub

    Public Sub TurnLeft() Implements ICharacter.TurnLeft
        _worldData.Characters(Id).Direction = (LeftDirection)
    End Sub

    Public Sub TurnRight() Implements ICharacter.TurnRight
        _worldData.Characters(Id).Direction = (RightDirection)
    End Sub

    Public Sub MoveAhead() Implements ICharacter.MoveAhead
        Move(Directions.Descriptors(Direction).AheadDirection, "ahead")
    End Sub

    Private Sub Move(direction As String, text As String)
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
    Public ReadOnly Property ExplorationPercentage As Double Implements ICharacter.ExplorationPercentage
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

    Public Sub AddMessage(ParamArray lines As String()) Implements ICharacter.AddMessage
        If Id <> _worldData.PlayerCharacterId Then
            Return
        End If
        _worldData.Characters(Id).Messages.Add(lines)
    End Sub

    Public Sub MoveBack() Implements ICharacter.MoveBack
        Move(Directions.Descriptors(Direction).OppositeDirection, "back")
    End Sub

    Public Sub MoveLeft() Implements ICharacter.MoveLeft
        Move(Directions.Descriptors(Direction).LeftDirection, "to the left")
    End Sub

    Public Sub MoveRight() Implements ICharacter.MoveRight
        Move(Directions.Descriptors(Direction).RightDirection, "to the right")
    End Sub

    Public Sub DismissMessage() Implements ICharacter.DismissMessage
        If HasMessages Then
            _worldData.Characters(Id).Messages.RemoveAt(0)
        End If
    End Sub

    Public ReadOnly Property IsStarving As Boolean Implements ICharacter.IsStarving
        Get
            Return Satiety = 0
        End Get
    End Property
    Public ReadOnly Property IsDead As Boolean Implements ICharacter.IsDead
        Get
            Return Health = 0
        End Get
    End Property
    Public Property Satiety As Integer Implements ICharacter.Satiety
        Get
            Return MaximumSatiety - Hunger
        End Get
        Set(value As Integer)
            Hunger = MaximumSatiety - value
        End Set
    End Property
    Public Property Health As Integer Implements ICharacter.Health
        Get
            Return MaximumHealth - Wounds
        End Get
        Set(value As Integer)
            Wounds = MaximumHealth - value
        End Set
    End Property
    Public ReadOnly Property MaximumSatiety As Integer Implements ICharacter.MaximumSatiety
        Get
            Return GetStatistic(StatisticTypes.MaximumSatiety)
        End Get
    End Property
    Public ReadOnly Property MaximumHealth As Integer Implements ICharacter.MaximumHealth
        Get
            Return GetStatistic(StatisticTypes.MaximumHealth)
        End Get
    End Property

    Private Function GetStatistic(statisticType As String) As Integer
        Return _worldData.Characters(Id).Statistics(statisticType)
    End Function

    Private Property Hunger As Integer
        Get
            Return GetStatistic(StatisticTypes.Hunger)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Hunger, Math.Clamp(value, 0, MaximumSatiety))
        End Set
    End Property

    Private Property Wounds As Integer
        Get
            Return GetStatistic(StatisticTypes.Wounds)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Wounds, Math.Clamp(value, 0, MaximumHealth))
        End Set
    End Property

    Private Sub SetStatistic(statisticType As String, value As Integer)
        _worldData.Characters(Id).Statistics(statisticType) = value
    End Sub

    Public Sub AddItems(value As String, amount As Integer) Implements ICharacter.AddItems
        If _worldData.Characters(Id).Items.ContainsKey(value) Then
            _worldData.Characters(Id).Items(value) += amount
        Else
            _worldData.Characters(Id).Items(value) = amount
        End If
    End Sub

    Public Function HasItems() As Boolean Implements ICharacter.HasItems
        Return _worldData.Characters(Id).Items.Any
    End Function

    Public Function HasItem(itemType As String) As Boolean Implements ICharacter.HasItem
        Return _worldData.Characters(Id).Items.ContainsKey(itemType)
    End Function

    Public Function ItemCount(itemType As String) As Integer Implements ICharacter.ItemCount
        If _worldData.Characters(Id).Items.ContainsKey(itemType) Then
            Return _worldData.Characters(Id).Items(itemType)
        End If
        Return 0
    End Function

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ICharacter.RemoveItems
        _worldData.Characters(Id).Items(itemType) -= amount
        If _worldData.Characters(Id).Items(itemType) <= 0 Then
            _worldData.Characters(Id).Items.Remove(itemType)
        End If
    End Sub

    Public Sub UseItem(itemType As String) Implements ICharacter.UseItem
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

    Public ReadOnly Property NextMessage As IEnumerable(Of String) Implements ICharacter.NextMessage
        Get
            If Not HasMessages Then
                Return Array.Empty(Of String)
            End If
            Return _worldData.Characters(Id).Messages.First
        End Get
    End Property

    Public ReadOnly Property HasMessages As Boolean Implements ICharacter.HasMessages
        Get
            Return _worldData.Characters(Id).Messages.Any
        End Get
    End Property

    ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(_worldData, _worldData.Characters(Id).LocationId)
        End Get
    End Property
    ReadOnly Property Direction As String Implements ICharacter.Direction
        Get
            Return _worldData.Characters(Id).Direction
        End Get
    End Property

    Public ReadOnly Property AheadDirection As String Implements ICharacter.AheadDirection
        Get
            Return Directions.Descriptors(Direction).AheadDirection
        End Get
    End Property

    Public ReadOnly Property LeftDirection As String Implements ICharacter.LeftDirection
        Get
            Return Directions.Descriptors(Direction).LeftDirection
        End Get
    End Property

    Public ReadOnly Property RightDirection As String Implements ICharacter.RightDirection
        Get
            Return Directions.Descriptors(Direction).RightDirection
        End Get
    End Property

    Public ReadOnly Property OppositeDirection As String Implements ICharacter.OppositeDirection
        Get
            Return Directions.Descriptors(Direction).OppositeDirection
        End Get
    End Property
End Class
