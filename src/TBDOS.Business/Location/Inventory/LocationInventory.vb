Imports TBDOS.Data

Friend Class LocationInventory
    Inherits LocationDataClient
    Implements ILocationInventory

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer) Implements ILocationInventory.Items
        Get
            Return LocationData.Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public ReadOnly Property HasItems As Boolean Implements ILocationInventory.HasItems
        Get
            Return LocationData.Items.Any
        End Get
    End Property

    Public ReadOnly Property Stacks As IEnumerable(Of ILocationItemStack) Implements ILocationInventory.Stacks
        Get
            Return LocationData.Items.Select(Function(x) New LocationItemStack(WorldData, locationId, x.Key))
        End Get
    End Property

    Public ReadOnly Property Stack(itemType As String) As ILocationItemStack Implements ILocationInventory.Stack
        Get
            Return New LocationItemStack(WorldData, locationId, itemType)
        End Get
    End Property

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ILocationInventory.RemoveItems
        LocationData.Items(itemType) -= amount
        If LocationData.Items(itemType) <= 0 Then
            LocationData.Items.Remove(itemType)
        End If
    End Sub

    Public Sub AddItems(value As String, amount As Integer) Implements ILocationInventory.AddItems
        If LocationData.Items.ContainsKey(value) Then
            LocationData.Items(value) += amount
        Else
            LocationData.Items(value) = amount
        End If
    End Sub

    Public Function ItemCount(value As String) As Integer Implements ILocationInventory.ItemCount
        If LocationData.Items.ContainsKey(value) Then
            Return LocationData.Items(value)
        End If
        Return 0
    End Function

    Public Function HasItem(itemType As String) As Boolean Implements ILocationInventory.HasItem
        Return LocationData.Items.ContainsKey(itemType)
    End Function
End Class
