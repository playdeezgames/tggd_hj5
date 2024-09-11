Friend Class CharacterItemStack
    Inherits CharacterDataClient
    Implements ICharacterItemStack
    Public Sub New(worldData As Data.WorldData, characterId As Integer, itemType As String)
        MyBase.New(worldData, characterId)
        Me.itemType = itemType
    End Sub

    Public Sub Use() Implements ICharacterItemStack.Use
        Dim character = New Character(WorldData, CharacterId)
        If ItemTypes.Descriptors(itemType).CanUse Then
            Remove(1)
            ItemTypes.Descriptors(itemType).OnUse(character)
        End If
    End Sub

    Public Sub Remove(amount As Integer) Implements ICharacterItemStack.Remove
        CharacterData.Items(itemType) -= amount
        If CharacterData.Items(itemType) <= 0 Then
            CharacterData.Items.Remove(itemType)
        End If
    End Sub

    Public ReadOnly Property Quantity As Integer Implements ICharacterItemStack.Quantity
        Get
            If CharacterData.Items.ContainsKey(itemType) Then
                Return CharacterData.Items(itemType)
            End If
            Return 0
        End Get
    End Property

    Public Sub Add(amount As Integer) Implements ICharacterItemStack.Add
        If CharacterData.Items.ContainsKey(itemType) Then
            CharacterData.Items(itemType) += amount
        Else
            CharacterData.Items(itemType) = amount
        End If
    End Sub

    Public ReadOnly Property Has As Boolean Implements ICharacterItemStack.Has
        Get
            Return CharacterData.Items.ContainsKey(itemType)
        End Get
    End Property

    Public ReadOnly Property InventoryName As String Implements IItemStack.InventoryName
        Get
            Return ItemTypes.Descriptors(itemType).InventoryName
        End Get
    End Property

    Private ReadOnly itemType As String
End Class
