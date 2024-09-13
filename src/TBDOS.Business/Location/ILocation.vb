Public Interface ILocation
    ReadOnly Property Id As Integer
    ReadOnly Property Routes As ILocationRoutes

    Function Neighbor(direction As String) As ILocation
End Interface
