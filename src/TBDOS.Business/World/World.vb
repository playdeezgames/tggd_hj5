Imports SPLORR.Game
Imports TBDOS.Data

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Private _worldData As WorldData
    Sub New()

    End Sub
    Public ReadOnly Property IsGameOver As Boolean Implements IWorld.IsGameOver
        Get
            Return _worldData Is Nothing
        End Get
    End Property
    Const MazeColumns = 10
    Const MazeRows = 10
    Private Sub InitializeWorldData()
        _worldData = New WorldData With
            {
                .Characters = New List(Of CharacterData),
                .Locations = New List(Of LocationData),
                .PlayerCharacterId = 0
            }
    End Sub
    Private Sub CreateMaze(columns As Integer, rows As Integer)
        Dim table = AllDirections.ToDictionary(Function(x) x, Function(x) Directions.Descriptors(x).AsMazeDirection)
        Dim maze = New Maze(Of String)(columns, rows, table)
        Dim locationIndex = _worldData.Locations.Count
        maze.Generate()
        For row = 0 To maze.Rows - 1
            For column = 0 To maze.Columns - 1
                Dim locationData As New LocationData With {.Neighbors = New Dictionary(Of String, Integer), .Items = New Dictionary(Of String, Integer), .VisitedBy = New HashSet(Of Integer)}
                For Each direction In maze.GetCell(column, row).Directions
                    If maze.GetCell(column, row).GetDoor(direction).Open Then
                        Dim nextColumn = CInt(column + table(direction).DeltaX)
                        Dim nextRow = CInt(row + table(direction).DeltaY)
                        locationData.Neighbors.Add(direction, nextColumn + nextRow * MazeColumns + locationIndex)
                    End If
                Next
                _worldData.Locations.Add(locationData)
            Next
        Next
    End Sub
    Public Sub Start() Implements IWorld.Start
        InitializeWorldData()
        CreateMaze(MazeColumns, MazeRows)
        PopulateMaze()
    End Sub

    Private Sub PopulateMaze()
        PopulateItems()
        PopulateCreatures()
    End Sub

    Private Sub PopulateCreatures()
        CreatePlayerCharacter()
    End Sub

    Private Sub PopulateItems()
        For Each itemType In AllItemTypes
            Dim spawnCount = ItemTypes.Descriptors(itemType).SpawnCount
            While spawnCount > 0
                Dim location = New Location(_worldData, RandomLocationId())
                location.AddItem(itemType)
                spawnCount -= 1
            End While
        Next
    End Sub

    Private Sub CreatePlayerCharacter()
        _worldData.PlayerCharacterId = CreateCharacter(CharacterTypes.N00b).Id
    End Sub
    Private Function RandomLocationId() As Integer
        Return RNG.FromRange(0, _worldData.Locations.Count - 1)
    End Function
    Private Function RandomDirection() As String
        Return RNG.FromEnumerable(AllDirections)
    End Function
    Private Function CreateCharacter(characterType As String) As ICharacter
        Dim id As Integer = _worldData.Characters.Count
        _worldData.Characters.Add(New CharacterData With {
                                  .LocationId = RandomLocationId(),
                                  .Direction = RandomDirection(),
                                  .Messages = New List(Of String()),
                                  .Items = New Dictionary(Of String, Integer),
                                  .Statistics = CharacterTypes.Descriptors(characterType).InitialStatistics.ToDictionary(Function(x) x.Key, Function(x) x.Value)})
        Dim character As ICharacter = New Character(_worldData, id)
        character.Location.AddVisit(character)
        Return character
    End Function

    Public Sub AbandonGame() Implements IWorld.AbandonGame
        _worldData = Nothing
    End Sub

    Public Function ItemTypeName(itemType As String) As String Implements IWorld.ItemTypeName
        Return ItemTypes.Descriptors(itemType).ItemTypeName
    End Function

    Public Function InventoryName(itemType As String) As String Implements IWorld.InventoryName
        Return ItemTypes.Descriptors(itemType).InventoryName
    End Function

    Public Function CanUse(itemType As String) As Boolean Implements IWorld.CanUse
        Return ItemTypes.Descriptors(itemType).CanUse
    End Function

    ReadOnly Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            Return New Character(_worldData, _worldData.PlayerCharacterId)
        End Get
    End Property

    Public ReadOnly Property AllItemTypes As IEnumerable(Of String) Implements IWorld.AllItemTypes
        Get
            Return ItemTypes.AllItemTypes
        End Get
    End Property
End Class
