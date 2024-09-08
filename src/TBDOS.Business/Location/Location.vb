Imports TBDOS.Data

Public Class Location
    Implements ILocation
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub
    Friend Function HasRoute(direction As Directions) As Boolean
        Return _worldData.Locations(Id).Neighbors.ContainsKey(CInt(direction))
    End Function
    Friend Function Neighbor(direction As Directions) As Location
        If Not HasRoute(direction) Then
            Return Nothing
        End If
        Return New Location(_worldData, _worldData.Locations(Id).Neighbors(direction))
    End Function

    Friend Sub AddItem(itemType As ItemTypes)
        If _worldData.Locations(Id).Items.ContainsKey(itemType) Then
            _worldData.Locations(Id).Items(itemType) += 1
        Else
            _worldData.Locations(Id).Items(itemType) = 1
        End If
    End Sub

    Public Function HasItem(itemType As ItemTypes) As Boolean
        Return _worldData.Locations(Id).Items.ContainsKey(itemType)
    End Function

    Public Sub RemoveItems(itemType As ItemTypes, amount As Integer)
        _worldData.Locations(Id).Items(itemType) -= amount
        If _worldData.Locations(Id).Items(itemType) <= 0 Then
            _worldData.Locations(Id).Items.Remove(itemType)
        End If
    End Sub

    Public Function ItemCount(value As ItemTypes) As Integer
        If _worldData.Locations(Id).Items.ContainsKey(value) Then
            Return _worldData.Locations(Id).Items(value)
        End If
        Return 0
    End Function

    Public Sub AddItems(value As ItemTypes, amount As Integer)
        If _worldData.Locations(Id).Items.ContainsKey(value) Then
            _worldData.Locations(Id).Items(value) += amount
        Else
            _worldData.Locations(Id).Items(value) = amount
        End If
    End Sub

    Friend Sub AddVisit(character As ICharacter)
        _worldData.Locations(Id).VisitedBy.Add(character.Id)
    End Sub

    ReadOnly Property HasItems As Boolean
        Get
            Return _worldData.Locations(Id).Items.Any
        End Get
    End Property
    ReadOnly Property Items As Dictionary(Of ItemTypes, Integer)
        Get
            Return _worldData.Locations(Id).Items.ToDictionary(Function(x) CType(x.Key, ItemTypes), Function(x) x.Value)
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of Route)
        Get
            Return _worldData.Locations(Id).Neighbors.Select(Function(x) New Route(_worldData, Id, CType(x.Key, Directions)))
        End Get
    End Property
End Class
