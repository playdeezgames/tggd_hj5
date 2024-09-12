Friend Class LocationItemStack
    Inherits LocationDataClient
    Implements ILocationItemStack

    Private ReadOnly _itemType As String

    Public Sub New(worldData As Data.WorldData, locationId As Integer, itemType As String)
        MyBase.New(worldData, locationId)
        Me._itemType = itemType
    End Sub

    Public ReadOnly Property Quantity As Integer Implements IItemStack.Quantity
        Get
            If LocationData.Items.ContainsKey(_itemType) Then
                Return LocationData.Items(_itemType)
            End If
            Return 0
        End Get
    End Property

    Public ReadOnly Property Has As Boolean Implements IItemStack.Has
        Get
            Return LocationData.Items.ContainsKey(_itemType)
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

    Private ReadOnly Property ItemType As String Implements ILocationItemStack.ItemType
        Get
            Return _itemType
        End Get
    End Property

    Public Sub Remove(amount As Integer) Implements IItemStack.Remove
        LocationData.Items(_itemType) -= amount
        If LocationData.Items(_itemType) <= 0 Then
            LocationData.Items.Remove(_itemType)
        End If
    End Sub

    Public Sub Add(amount As Integer) Implements IItemStack.Add
        If LocationData.Items.ContainsKey(_itemType) Then
            LocationData.Items(_itemType) += amount
        Else
            LocationData.Items(_itemType) = amount
        End If
    End Sub
End Class
