Public Interface ILocation
    Function Neighbor(direction As Directions) As ILocation
    ReadOnly Property Id As Integer
    Function HasRoute(direction As Directions) As Boolean
    Sub AddVisit(character As ICharacter)
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Sub RemoveItems(itemType As ItemTypes, amount As Integer)
    ReadOnly Property Items As IReadOnlyDictionary(Of ItemTypes, Integer)
    Function ItemCount(value As ItemTypes) As Integer
    ReadOnly Property HasItems As Boolean
    Function HasItem(itemType As ItemTypes) As Boolean
    Sub AddItems(value As ItemTypes, amount As Integer)
End Interface
