Public Interface ICharacterItems
    Function HasAny() As Boolean
    ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack)
    ReadOnly Property Stack(itemType As String) As ICharacterItemStack
End Interface
