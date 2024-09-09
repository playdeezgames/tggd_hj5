Public Interface ICharacterItems
    Sub UseItem(itemType As String)
    Sub RemoveItems(itemType As String, amount As Integer)
    ReadOnly Property LegacyItems As IReadOnlyDictionary(Of String, Integer)
    Function ItemCount(itemType As String) As Integer
    Sub AddItems(itemType As String, amount As Integer)
    Function HasItems() As Boolean
    Function HasItem(itemType As String) As Boolean
End Interface
