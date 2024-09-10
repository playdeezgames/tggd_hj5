Friend Class CharacterItems
    Inherits CharacterDataClient
    Implements ICharacterItems

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer)) Implements ICharacterItems.Inventory
        Get
            Return CharacterData.Items.Select(Function(x) (ItemTypes.Descriptors(x.Key).InventoryName, x.Value))
        End Get
    End Property

    Public Sub Use(itemType As String) Implements ICharacterItems.Use
        Dim character = New Character(WorldData, CharacterId)
        If ItemTypes.Descriptors(itemType).CanUse Then
            Remove(itemType, 1)
            ItemTypes.Descriptors(itemType).OnUse(character)
        End If
    End Sub

    Public Sub Remove(itemType As String, amount As Integer) Implements ICharacterItems.Remove
        CharacterData.Items(itemType) -= amount
        If CharacterData.Items(itemType) <= 0 Then
            CharacterData.Items.Remove(itemType)
        End If
    End Sub

    Public Sub Add(itemType As String, amount As Integer) Implements ICharacterItems.Add
        If CharacterData.Items.ContainsKey(itemType) Then
            CharacterData.Items(itemType) += amount
        Else
            CharacterData.Items(itemType) = amount
        End If
    End Sub

    Public Function Count(itemType As String) As Integer Implements ICharacterItems.Count
        If CharacterData.Items.ContainsKey(itemType) Then
            Return CharacterData.Items(itemType)
        End If
        Return 0
    End Function

    Public Function HasAny() As Boolean Implements ICharacterItems.HasAny
        Return CharacterData.Items.Any
    End Function

    Public Function Has(itemType As String) As Boolean Implements ICharacterItems.Has
        Return CharacterData.Items.ContainsKey(itemType)
    End Function
End Class
