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

    Public Sub Take(itemStack As ILocationItemStack, amount As Integer) Implements ICharacterInventory.Take
        itemStack.Remove(amount)
        Stack(itemStack.ItemType).Add(amount)
        Dim messages = New CharacterMessages(WorldData, CharacterId)
        messages.Add($"You take {amount} {itemStack.ItemTypeName}.")
    End Sub

    Public Sub Drop(itemStack As ICharacterItemStack, amount As Integer) Implements ICharacterInventory.Drop
        Dim character As ICharacter = New Character(WorldData, CharacterId)
        character.Location.Inventory.Stack(itemStack.ItemType).Add(amount)
        itemStack.Remove(amount)
        character.Messages.Add($"You drop {amount} {itemStack.ItemTypeName}.")
    End Sub

    Public Function HasAny() As Boolean Implements ICharacterInventory.HasAny
        Return CharacterData.Items.Any
    End Function

End Class
