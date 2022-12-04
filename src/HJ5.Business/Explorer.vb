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
                    Return "Explore!"
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
            Case Else
                Throw New NotImplementedException
        End Select
        Return result
    End Function

    Private Function ExecuteExploreOrder() As IEnumerable(Of String)
        Dim result As New List(Of String)
        result.Add($"{Name} explores!")
        result.Add($"{Name} finds nothing!")
        Return result
    End Function
End Class
