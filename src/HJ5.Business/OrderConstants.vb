Public Module OrderConstants
    Public Const ExploreOrder = "explore"
    Public Const IdleOrder = "idle"
    Public Const RestOrder = "rest"
    Public ReadOnly AvailableOrders As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            ExploreOrder,
            IdleOrder,
            RestOrder
        }
    Public Function OrderName(order As String) As String
        Select Case order
            Case ExploreOrder
                Return "explore"
            Case IdleOrder
                Return "idle"
            Case RestOrder
                Return "rest"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    Public Function OrderEnergyCost(order As String) As Integer
        Select Case order
            Case ExploreOrder
                Return 1
            Case IdleOrder
                Return 0
            Case RestOrder
                Return -10
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    Public Function OrderEnnuiCost(order As String) As Integer
        Select Case order
            Case ExploreOrder
                Return 0
            Case IdleOrder
                Return 1
            Case RestOrder
                Return 2
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
