Public Interface ICharacterItemStack
    Inherits IItemStack
    Sub Use()
    ReadOnly Property CanUse As Boolean
    Sub Drop(amount As Integer)
End Interface
