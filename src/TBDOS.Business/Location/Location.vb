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
    Public Function Neighbor(direction As String) As ILocation Implements ILocation.Neighbor
        If Not Routes.Has(direction) Then
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

    Public Sub AddVisit(character As ICharacter) Implements ILocation.AddVisit
        LocationData.VisitedBy.Add(character.Id)
    End Sub

    Public ReadOnly Property Inventory As ILocationInventory Implements ILocation.Inventory
        Get
            Return New LocationInventory(WorldData, locationId)
        End Get
    End Property

    Public ReadOnly Property Routes As ILocationRoutes Implements ILocation.Routes
        Get
            Return New LocationRoutes(WorldData, locationId)
        End Get
    End Property
End Class
