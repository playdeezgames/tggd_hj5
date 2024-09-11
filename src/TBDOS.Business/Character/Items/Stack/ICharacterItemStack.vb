Public Interface ICharacterItemStack
    Sub Use()
    Sub Remove(amount As Integer)
    Function Count() As Integer
    Sub Add(amount As Integer)
    Function Has() As Boolean
End Interface
