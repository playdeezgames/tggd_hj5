Public Class World
    Private _worldData As WorldData
    Sub New()
        _worldData = New WorldData With
            {
                .Turn = 1,
                .Explorers = New Dictionary(Of Guid, ExplorerData)
            }
        CreateExplorer()
    End Sub
    Sub New(worldData As WorldData)
        _worldData = worldData
    End Sub
    Private Sub CreateExplorer()
        _worldData.Explorers.Add(Guid.NewGuid, New ExplorerData With {
                                 .Name = RNG.GenerateExplorerName(),
                                 .Order = ExploreOrder,
                                 .Statistics = New Dictionary(Of String, Integer) From
                                    {
                                        {FatigueStatistic, 0},
                                        {MaximumEnergyStatistic, 100},
                                        {EnnuiStatistic, 0},
                                        {MaximumEnnuiStatistic, 100}
                                    }
                                 })
    End Sub

    Public Function NextTurn() As IEnumerable(Of String)
        Dim result As New List(Of String)
        Dim dead As New List(Of Explorer)
        For Each explorer In Explorers
            If explorer.IsDead Then
                result.Add($"{explorer.Name} dies of ennui.")
                dead.Add(explorer)
            End If
        Next
        For Each explorer In dead
            explorer.Destroy()
        Next
        _worldData.Turn += 1
        Return result
    End Function

    ReadOnly Property Explorers As IEnumerable(Of Explorer)
        Get
            Return _worldData.Explorers.Select(Function(x) New Explorer(_worldData, x.Key))
        End Get
    End Property
    ReadOnly Property Turn As Integer
        Get
            Return _worldData.Turn
        End Get
    End Property

    Public ReadOnly Property HasExplorers As Boolean
        Get
            Return _worldData.Explorers.Any
        End Get
    End Property
End Class
