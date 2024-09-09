Imports TBDOS.Data

Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub
    ReadOnly Property LegacyItems As IReadOnlyDictionary(Of String, Integer) Implements ICharacter.LegacyItems
        Get
            Return WorldData.Characters(Id).Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public Sub TurnAround() Implements ICharacter.TurnAround
        WorldData.Characters(Id).Direction = (OppositeDirection)
    End Sub

    Public Sub TurnLeft() Implements ICharacter.TurnLeft
        WorldData.Characters(Id).Direction = (LeftDirection)
    End Sub

    Public Sub TurnRight() Implements ICharacter.TurnRight
        WorldData.Characters(Id).Direction = (RightDirection)
    End Sub

    Public Sub MoveAhead() Implements ICharacter.MoveAhead
        Move(Directions.Descriptors(Direction).AheadDirection, "ahead")
    End Sub

    Private Sub Move(direction As String, text As String)
        If Not Location.HasRoute(direction) Then
            Messages.AddMessage("You cannot go that way!")
            Return
        End If
        Messages.AddMessage($"You move {text}.")
        WorldData.Characters(Id).LocationId = Location.Neighbor(direction).Id
        ApplyEffects()
    End Sub

    Private Sub ApplyEffects()
        AddHunger(1)
        Location.AddVisit(Me)
    End Sub
    Public ReadOnly Property ExplorationPercentage As Double Implements ICharacter.ExplorationPercentage
        Get
            Return 100.0 * WorldData.Locations.Where(Function(x) x.VisitedBy.Contains(Id)).Count / WorldData.Locations.Count
        End Get
    End Property

    Private Sub AddHunger(amount As Integer)
        If Not IsStarving Then
            Hunger += amount
        Else
            Wounds += amount
        End If
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
        If Messages.HasMessages Then
            WorldData.Characters(Id).Messages.RemoveAt(0)
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
        Return WorldData.Characters(Id).Statistics(statisticType)
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
        WorldData.Characters(Id).Statistics(statisticType) = value
    End Sub

    Public Sub AddItems(value As String, amount As Integer) Implements ICharacter.AddItems
        If WorldData.Characters(Id).Items.ContainsKey(value) Then
            WorldData.Characters(Id).Items(value) += amount
        Else
            WorldData.Characters(Id).Items(value) = amount
        End If
    End Sub

    Public Function HasItems() As Boolean Implements ICharacter.HasItems
        Return WorldData.Characters(Id).Items.Any
    End Function

    Public Function HasItem(itemType As String) As Boolean Implements ICharacter.HasItem
        Return WorldData.Characters(Id).Items.ContainsKey(itemType)
    End Function

    Public Function ItemCount(itemType As String) As Integer Implements ICharacter.ItemCount
        If WorldData.Characters(Id).Items.ContainsKey(itemType) Then
            Return WorldData.Characters(Id).Items(itemType)
        End If
        Return 0
    End Function

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ICharacter.RemoveItems
        WorldData.Characters(Id).Items(itemType) -= amount
        If WorldData.Characters(Id).Items(itemType) <= 0 Then
            WorldData.Characters(Id).Items.Remove(itemType)
        End If
    End Sub

    Public Sub UseItem(itemType As String) Implements ICharacter.UseItem
        If ItemTypes.Descriptors(itemType).CanUse Then
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
        Messages.AddMessage("You use the medicine.", $"Yer health is now {Health}/{MaximumHealth}")
    End Sub

    Private Sub UseFood()
        Satiety += 10
        Messages.AddMessage("You eat the food.", $"Yer satiety is now {Satiety}/{MaximumSatiety}")
    End Sub

    ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, WorldData.Characters(Id).LocationId)
        End Get
    End Property
    ReadOnly Property Direction As String Implements ICharacter.Direction
        Get
            Return WorldData.Characters(Id).Direction
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

    Public ReadOnly Property Messages As ICharacterMessages Implements ICharacter.Messages
        Get
            Return New CharacterMessages(WorldData, Id)
        End Get
    End Property
End Class
