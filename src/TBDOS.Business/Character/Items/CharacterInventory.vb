Friend Class CharacterInventory
    Inherits CharacterDataClient
    Implements ICharacterInventory

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property Stacks As IEnumerable(Of ICharacterItemStack) Implements ICharacterInventory.Stacks
        Get
            Return CharacterData.Items.Select(Function(x) New CharacterItemStack(WorldData, CharacterId, x.Key))
        End Get
    End Property

    Public ReadOnly Property Stack(itemType As String) As ICharacterItemStack Implements ICharacterInventory.Stack
        Get
            Return New CharacterItemStack(WorldData, CharacterId, itemType)
        End Get
    End Property

    Public Function HasAny() As Boolean Implements ICharacterInventory.HasAny
        Return CharacterData.Items.Any
    End Function

End Class
