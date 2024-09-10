Friend Class CharacterItems
    Inherits CharacterDataClient
    Implements ICharacterItems

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property LegacyItems As IReadOnlyDictionary(Of String, Integer) Implements ICharacterItems.LegacyItems
        Get
            Return CharacterData.Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public Sub UseItem(itemType As String) Implements ICharacterItems.UseItem
        If ItemTypes.Descriptors(itemType).CanUse Then
            RemoveItems(itemType, 1)
            Select Case itemType
                Case ItemTypes.Food
                    UseFood()
                Case ItemTypes.Medicine
                    UseMedicine()
            End Select
        End If
    End Sub
    Private Sub UseMedicine()
        Dim character = New Character(WorldData, CharacterId)
        character.Statistics.Health += 10
        character.Messages.Add("You use the medicine.", $"Yer health is now {character.Statistics.Health}/{character.Statistics.MaximumHealth}")
    End Sub

    Private Sub UseFood()
        Dim character = New Character(WorldData, CharacterId)
        character.Statistics.Satiety += 10
        character.Messages.Add("You eat the food.", $"Yer satiety is now {character.Statistics.Satiety}/{character.Statistics.MaximumSatiety}")
    End Sub

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ICharacterItems.RemoveItems
        CharacterData.Items(itemType) -= amount
        If CharacterData.Items(itemType) <= 0 Then
            CharacterData.Items.Remove(itemType)
        End If
    End Sub

    Public Sub AddItems(itemType As String, amount As Integer) Implements ICharacterItems.AddItems
        If CharacterData.Items.ContainsKey(itemType) Then
            CharacterData.Items(itemType) += amount
        Else
            CharacterData.Items(itemType) = amount
        End If
    End Sub

    Public Function ItemCount(itemType As String) As Integer Implements ICharacterItems.ItemCount
        If CharacterData.Items.ContainsKey(itemType) Then
            Return CharacterData.Items(itemType)
        End If
        Return 0
    End Function

    Public Function HasItems() As Boolean Implements ICharacterItems.HasItems
        Return CharacterData.Items.Any
    End Function

    Public Function HasItem(itemType As String) As Boolean Implements ICharacterItems.HasItem
        Return CharacterData.Items.ContainsKey(itemType)
    End Function
End Class
