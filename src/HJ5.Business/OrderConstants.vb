Public Module OrderConstants
    Public Const ExploreOrder = "explore"
    Public Const IdleOrder = "idle"
    Public ReadOnly AvailableOrders As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            ExploreOrder,
            IdleOrder
        }
    Public Function OrderName(order As String) As String
        Select Case order
            Case ExploreOrder
                Return "explore"
            Case IdleOrder
                Return "idle"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
