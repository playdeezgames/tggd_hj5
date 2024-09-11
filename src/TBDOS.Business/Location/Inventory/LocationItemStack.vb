Friend Class LocationItemStack
    Inherits LocationDataClient
    Implements ILocationItemStack

    Private ReadOnly itemType As String

    Public Sub New(worldData As Data.WorldData, locationId As Integer, itemType As String)
        MyBase.New(worldData, locationId)
        Me.itemType = itemType
    End Sub

    Public ReadOnly Property Quantity As Integer Implements IItemStack.Quantity
        Get
            If LocationData.Items.ContainsKey(itemType) Then
                Return LocationData.Items(itemType)
            End If
            Return 0
        End Get
    End Property

    Public ReadOnly Property Has As Boolean Implements IItemStack.Has
        Get
            Return LocationData.Items.ContainsKey(itemType)
        End Get
    End Property

    Public ReadOnly Property InventoryName As String Implements IItemStack.InventoryName
        Get
            Return ItemTypes.Descriptors(itemType).InventoryName
        End Get
    End Property

    Public Sub Remove(amount As Integer) Implements IItemStack.Remove
        LocationData.Items(itemType) -= amount
        If LocationData.Items(itemType) <= 0 Then
            LocationData.Items.Remove(itemType)
        End If
    End Sub

    Public Sub Add(amount As Integer) Implements IItemStack.Add
        If LocationData.Items.ContainsKey(itemType) Then
            LocationData.Items(itemType) += amount
        Else
            LocationData.Items(itemType) = amount
        End If
    End Sub
End Class
