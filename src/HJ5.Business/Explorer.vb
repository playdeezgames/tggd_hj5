Public Class Explorer
    Private _worldData As WorldData
    Public ReadOnly Id As Guid
    Sub New(worldData As WorldData, id As Guid)
        _worldData = worldData
        Me.Id = id
    End Sub
    ReadOnly Property Name As String
        Get
            Return _worldData.Explorers(Id).Name
        End Get
    End Property
    ReadOnly Property OrderName As String
        Get
            Return OrderConstants.OrderName(_worldData.Explorers(Id).Order)
        End Get
    End Property
    ReadOnly Property World As World
        Get
            Return New World(_worldData)
        End Get
    End Property
    Function ExecuteOrder() As IEnumerable(Of String)
        Dim result As New List(Of String)
        result.AddRange(ValidateOrder())
        Fatigue += OrderEnergyCost(_worldData.Explorers(Id).Order)
        Select Case _worldData.Explorers(Id).Order
            Case ExploreOrder
                result.AddRange(ExecuteExploreOrder())
            Case IdleOrder
                result.AddRange(ExecuteIdleOrder())
            Case Else
                Throw New NotImplementedException
        End Select
        Return result
    End Function

    Private Function ValidateOrder() As IEnumerable(Of String)
        Dim result As New List(Of String)
        If Energy < OrderEnergyCost(_worldData.Explorers(Id).Order) Then
            result.Add($"{Name} does not have enough energy to {OrderName}, assigning to idle instead!")
            Assign(IdleOrder)
        End If
        Return result
    End Function

    Public ReadOnly Property Energy As Integer
        Get
            Return Clamp(MaximumEnergy - Fatigue, 0, MaximumEnergy)
        End Get
    End Property
    Public ReadOnly Property MaximumEnergy As Integer
        Get
            Return GetStatistic(MaximumEnergyStatistic)
        End Get
    End Property

    Private Function GetStatistic(statistic As String) As Integer
        Return _worldData.Explorers(Id).Statistics(statistic)
    End Function

    Private Property Fatigue As Integer
        Get
            Return GetStatistic(FatigueStatistic)
        End Get
        Set(value As Integer)
            SetStatistic(FatigueStatistic, Clamp(value, 0, MaximumEnergy))
        End Set
    End Property

    Private Sub SetStatistic(statistic As String, value As Integer)
        _worldData.Explorers(Id).Statistics(statistic) = value
    End Sub

    Private Function ExecuteIdleOrder() As IEnumerable(Of String)
        Return New List(Of String) From {
            $"{Name} does nothing."
            }
    End Function

    Private Function ExecuteExploreOrder() As IEnumerable(Of String)
        Dim result As New List(Of String)
        result.Add($"{Name} explores!")
        result.Add($"{Name} finds nothing!")
        Return result
    End Function

    Public Sub Assign(order As String)
        _worldData.Explorers(Id).Order = order
    End Sub

    Public ReadOnly Property AvailableOrders As IEnumerable(Of String)
        Get
            Return OrderConstants.AvailableOrders
        End Get
    End Property

End Class
