Imports TBDOS.Data

Friend Class Location
    Inherits WorldDataClient
    Implements ILocation
    Public ReadOnly Property Id As Integer Implements ILocation.Id
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData)
        Me.Id = id
    End Sub
    Public Function HasRoute(direction As String) As Boolean Implements ILocation.HasRoute
        Return WorldData.Locations(Id).Neighbors.ContainsKey(direction)
    End Function
    Public Function Neighbor(direction As String) As ILocation Implements ILocation.Neighbor
        If Not HasRoute(direction) Then
            Return Nothing
        End If
        Return New Location(WorldData, WorldData.Locations(Id).Neighbors(direction))
    End Function

    Friend Sub AddItem(itemType As String)
        If WorldData.Locations(Id).Items.ContainsKey(itemType) Then
            WorldData.Locations(Id).Items(itemType) += 1
        Else
            WorldData.Locations(Id).Items(itemType) = 1
        End If
    End Sub

    Public Function HasItem(itemType As String) As Boolean Implements ILocation.HasItem
        Return WorldData.Locations(Id).Items.ContainsKey(itemType)
    End Function

    Public Sub RemoveItems(itemType As String, amount As Integer) Implements ILocation.RemoveItems
        WorldData.Locations(Id).Items(itemType) -= amount
        If WorldData.Locations(Id).Items(itemType) <= 0 Then
            WorldData.Locations(Id).Items.Remove(itemType)
        End If
    End Sub

    Public Function ItemCount(value As String) As Integer Implements ILocation.ItemCount
        If WorldData.Locations(Id).Items.ContainsKey(value) Then
            Return WorldData.Locations(Id).Items(value)
        End If
        Return 0
    End Function

    Public Sub AddItems(value As String, amount As Integer) Implements ILocation.AddItems
        If WorldData.Locations(Id).Items.ContainsKey(value) Then
            WorldData.Locations(Id).Items(value) += amount
        Else
            WorldData.Locations(Id).Items(value) = amount
        End If
    End Sub

    Public Sub AddVisit(character As ICharacter) Implements ILocation.AddVisit
        WorldData.Locations(Id).VisitedBy.Add(character.Id)
    End Sub

    ReadOnly Property HasItems As Boolean Implements ILocation.HasItems
        Get
            Return WorldData.Locations(Id).Items.Any
        End Get
    End Property
    ReadOnly Property Items As IReadOnlyDictionary(Of String, Integer) Implements ILocation.Items
        Get
            Return WorldData.Locations(Id).Items.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return WorldData.Locations(Id).Neighbors.Select(Function(x) New Route(WorldData, Id, x.Key))
        End Get
    End Property
End Class
