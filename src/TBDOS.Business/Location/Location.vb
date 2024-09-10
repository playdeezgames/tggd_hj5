Imports TBDOS.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return locationId
        End Get
    End Property
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub
    Public Function HasRoute(direction As String) As Boolean Implements ILocation.HasRoute
        Return LocationData.Neighbors.ContainsKey(direction)
    End Function
    Public Function Neighbor(direction As String) As ILocation Implements ILocation.Neighbor
        If Not HasRoute(direction) Then
            Return Nothing
        End If
        Return New Location(WorldData, LocationData.Neighbors(direction))
    End Function

    Friend Sub AddItem(itemType As String)
        If LocationData.Items.ContainsKey(itemType) Then
            LocationData.Items(itemType) += 1
        Else
            LocationData.Items(itemType) = 1
        End If
    End Sub

    Public Function HasItem(itemType As String) As Boolean Implements ILocation.HasItem
        Return LocationData.Items.ContainsKey(itemType)
    End Function

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ILocation.RemoveItems
        LocationData.Items(itemType) -= amount
        If LocationData.Items(itemType) <= 0 Then
            LocationData.Items.Remove(itemType)
        End If
    End Sub

    Public Function ItemCount(value As String) As Integer Implements ILocation.ItemCount
        If LocationData.Items.ContainsKey(value) Then
            Return LocationData.Items(value)
        End If
        Return 0
    End Function

    Public Sub AddItems(value As String, amount As Integer) Implements ILocation.AddItems
        If LocationData.Items.ContainsKey(value) Then
            LocationData.Items(value) += amount
        Else
            LocationData.Items(value) = amount
        End If
    End Sub

    Public Sub AddVisit(character As ICharacter) Implements ILocation.AddVisit
        LocationData.VisitedBy.Add(character.Id)
    End Sub

    ReadOnly Property HasItems As Boolean Implements ILocation.HasItems
        Get
            Return LocationData.Items.Any
        End Get
    End Property
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer) Implements ILocation.Items
        Get
            Return LocationData.Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return LocationData.Neighbors.Select(Function(x) New Route(WorldData, Id, x.Key))
        End Get
    End Property

    Public ReadOnly Property Inventory As IEnumerable(Of (InventoryName As String, Quantity As Integer)) Implements ILocation.Inventory
        Get
            Return LocationData.Items.Select(Function(x) (ItemTypes.Descriptors(x.Key).InventoryName, x.Value))
        End Get
    End Property
End Class
