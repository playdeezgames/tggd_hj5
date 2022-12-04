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
    ReadOnly Property Order As String
        Get
            Select Case _worldData.Explorers(Id).Order(0)
                Case ExploreOrder
                    Return "explore"
                Case IdleOrder
                    Return "idle"
                Case Else
                    Throw New NotImplementedException
            End Select
        End Get
    End Property
    ReadOnly Property World As World
        Get
            Return New World(_worldData)
        End Get
    End Property
    Function ExecuteOrder() As IEnumerable(Of String)
        Dim result As New List(Of String)
        Select Case _worldData.Explorers(Id).Order(0)
            Case ExploreOrder
                result.AddRange(ExecuteExploreOrder())
            Case IdleOrder
                result.AddRange(ExecuteIdleOrder())
            Case Else
                Throw New NotImplementedException
        End Select
        Return result
    End Function

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
        _worldData.Explorers(Id).Order = New String() {order}
    End Sub

    Public ReadOnly Property AvailableOrders As IEnumerable(Of String)
        Get
            Return OrderConstants.AvailableOrders
        End Get
    End Property

End Class
