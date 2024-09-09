Public Interface ILocation
    Function Neighbor(direction As String) As ILocation
    ReadOnly Property Id As Integer
    Function HasRoute(direction As String) As Boolean
    Sub AddVisit(character As ICharacter)
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Sub RemoveItems(itemType As String, amount As Integer)
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(value As String) As Integer
    ReadOnly Property HasItems As Boolean
    Function HasItem(itemType As String) As Boolean
    Sub AddItems(value As String, amount As Integer)
End Interface
