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

    Public ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack) Implements ICharacterItems.Stacks
        Get
            Return CharacterData.Items.Select(Function(x) New CharacterItemStack(WorldData, CharacterId, x.Key))
        End Get
    End Property

    Public ReadOnly Property Stack(itemType As String) As ICharacterItemStack Implements ICharacterItems.Stack
        Get
            Return New CharacterItemStack(WorldData, CharacterId, itemType)
        End Get
    End Property

    Public Function HasAny() As Boolean Implements ICharacterItems.HasAny
        Return CharacterData.Items.Any
    End Function

End Class
