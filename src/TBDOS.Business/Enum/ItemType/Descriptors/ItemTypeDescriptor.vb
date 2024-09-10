Public MustInherit Class ItemTypeDescriptor
    Public ReadOnly Property ItemType As String
    Public ReadOnly Property SpawnCount As Integer
    Public ReadOnly InventoryName As String
    Public ReadOnly CanUse As Boolean
    Public ReadOnly ItemTypeName As String
    Sub New(itemType As String, spawnCount As Integer, inventoryName As String, canUse As Boolean, itemTypeName As String)
        Me.ItemType = itemType
        Me.SpawnCount = spawnCount
        Me.InventoryName = inventoryName
        Me.CanUse = canUse
        Me.ItemTypeName = itemTypeName
    End Sub
    Public MustOverride Sub OnUse(character As ICharacter)
End Class
