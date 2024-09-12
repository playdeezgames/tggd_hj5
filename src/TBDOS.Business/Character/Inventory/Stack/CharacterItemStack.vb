Friend Class CharacterItemStack
    Inherits CharacterDataClient
    Implements ICharacterItemStack
    Public Sub New(worldData As Data.WorldData, characterId As Integer, itemType As String)
        MyBase.New(worldData, characterId)
        Me._itemType = itemType
    End Sub

    Public Sub Use() Implements ICharacterItemStack.Use
        Dim character = New Character(WorldData, CharacterId)
        If ItemTypes.Descriptors(_itemType).CanUse Then
            Remove(1)
            ItemTypes.Descriptors(_itemType).OnUse(character)
        End If
    End Sub

    Public Sub Remove(amount As Integer) Implements ICharacterItemStack.Remove
        CharacterData.Items(_itemType) -= amount
        If CharacterData.Items(_itemType) <= 0 Then
            CharacterData.Items.Remove(_itemType)
        End If
    End Sub

    Public ReadOnly Property Quantity As Integer Implements ICharacterItemStack.Quantity
        Get
            If CharacterData.Items.ContainsKey(_itemType) Then
                Return CharacterData.Items(_itemType)
            End If
            Return 0
        End Get
    End Property

    Public Sub Add(amount As Integer) Implements ICharacterItemStack.Add
        If CharacterData.Items.ContainsKey(_itemType) Then
            CharacterData.Items(_itemType) += amount
        Else
            CharacterData.Items(_itemType) = amount
        End If
    End Sub

    Public ReadOnly Property Has As Boolean Implements ICharacterItemStack.Has
        Get
            Return CharacterData.Items.ContainsKey(_itemType)
        End Get
    End Property

    Public ReadOnly Property InventoryName As String Implements IItemStack.InventoryName
        Get
            Return ItemTypes.Descriptors(_itemType).InventoryName
        End Get
    End Property

    Public ReadOnly Property ItemTypeName As String Implements IItemStack.ItemTypeName
        Get
            Return ItemTypes.Descriptors(_itemType).ItemTypeName
        End Get
    End Property

    Private ReadOnly Property ItemType As String Implements IItemStack.ItemType
        Get
            Return ItemTypes.Descriptors(_itemType).ItemType
        End Get
    End Property

    Public ReadOnly Property CanUse As Boolean Implements ICharacterItemStack.CanUse
        Get
            Return ItemTypes.Descriptors(_itemType).CanUse
        End Get
    End Property

    Private ReadOnly _itemType As String
End Class
