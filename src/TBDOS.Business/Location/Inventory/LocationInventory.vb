Imports TBDOS.Data

Friend Class LocationInventory
    Inherits LocationDataClient
    Implements ILocationInventory

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

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
End Class
