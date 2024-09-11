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

    Public Function Count() As Integer Implements ICharacterItemStack.Count
        If CharacterData.Items.ContainsKey(itemType) Then
            Return CharacterData.Items(itemType)
        End If
        Return 0
    End Function

    Public Sub Add(amount As Integer) Implements ICharacterItemStack.Add
        If CharacterData.Items.ContainsKey(itemType) Then
            CharacterData.Items(itemType) += amount
        Else
            CharacterData.Items(itemType) = amount
        End If
    End Sub

    Public Function Has() As Boolean Implements ICharacterItemStack.Has
        Return CharacterData.Items.ContainsKey(itemType)
    End Function

    Private ReadOnly itemType As String
End Class
