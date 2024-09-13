Friend Class CharacterStatistics
    Inherits CharacterDataClient
    Implements ICharacterStatistics

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Property Health As Integer Implements ICharacterStatistics.Health
        Get
            Return MaximumHealth - Wounds
        End Get
        Set(value As Integer)
            Wounds = MaximumHealth - value
        End Set
    End Property

    Public ReadOnly Property MaximumHealth As Integer Implements ICharacterStatistics.MaximumHealth
        Get
            Return GetStatistic(StatisticTypes.MaximumHealth)
        End Get
    End Property

    Public Property Satiety As Integer Implements ICharacterStatistics.Satiety
        Get
            Return MaximumSatiety - Hunger
        End Get
        Set(value As Integer)
            Hunger = MaximumSatiety - value
        End Set
    End Property

    Public ReadOnly Property MaximumSatiety As Integer Implements ICharacterStatistics.MaximumSatiety
        Get
            Return GetStatistic(StatisticTypes.MaximumSatiety)
        End Get
    End Property

    Private Property Wounds As Integer
        Get
            Return GetStatistic(StatisticTypes.Wounds)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Wounds, Math.Clamp(value, 0, MaximumHealth))
        End Set
    End Property

    Private Property Hunger As Integer
        Get
            Return GetStatistic(StatisticTypes.Hunger)
        End Get
        Set(value As Integer)
            SetStatistic(StatisticTypes.Hunger, Math.Clamp(value, 0, MaximumSatiety))
        End Set
    End Property

    Private Function GetStatistic(statisticType As String) As Integer
        Return CharacterData.Statistics(statisticType)
    End Function

    Private Sub SetStatistic(statisticType As String, value As Integer)
        CharacterData.Statistics(statisticType) = value
    End Sub
End Class
