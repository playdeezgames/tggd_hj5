Public Interface ILocationRoutes
    Function Has(direction As String) As Boolean
    ReadOnly Property All As IEnumerable(Of IRoute)
End Interface
