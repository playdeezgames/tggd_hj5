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
                                        {MaximumEnergyStatistic, 100}
                                    }
                                 })
    End Sub

    Public Sub NextTurn()
        _worldData.Turn += 1
    End Sub

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
End Class
