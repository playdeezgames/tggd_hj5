Public Module OrderConstants
    Public Const ExploreOrder = "explore"
    Public Const IdleOrder = "idle"
    Public ReadOnly AvailableOrders As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            ExploreOrder,
            IdleOrder
        }
End Module
