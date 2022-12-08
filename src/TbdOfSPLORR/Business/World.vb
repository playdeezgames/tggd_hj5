Public Class World
    Private _worldData As WorldData
    Sub New()

    End Sub
    Public ReadOnly Property IsGameOver As Boolean
        Get
            Return _worldData Is Nothing
        End Get
    End Property
    Const MazeColumns = 8
    Const MazeRows = 8
    Private Sub InitializeWorldData()
        _worldData = New WorldData With
            {
                .Characters = New List(Of CharacterData),
                .Locations = New List(Of LocationData),
                .PlayerCharacterId = 0
            }
    End Sub
    Private Sub CreateMaze(columns As Integer, rows As Integer)
        Dim table = AllDirections.ToDictionary(Function(x) x, Function(x) x.AsMazeDirection)
        Dim maze = New Maze(Of Directions)(columns, rows, table)
        Dim locationIndex = _worldData.Locations.Count
        maze.Generate()
        For row = 0 To maze.Rows - 1
            For column = 0 To maze.Columns - 1
                Dim locationData As New LocationData With {.Neighbors = New Dictionary(Of Integer, Integer)}
                For Each direction In maze.GetCell(column, row).Directions
                    If maze.GetCell(column, row).GetDoor(direction).Open Then
                        Dim nextColumn = CInt(column + table(direction).DeltaX)
                        Dim nextRow = CInt(row + table(direction).DeltaY)
                        locationData.Neighbors.Add(CInt(direction), nextColumn + nextRow * MazeColumns + locationIndex)
                    End If
                Next
                _worldData.Locations.Add(locationData)
            Next
        Next
    End Sub
    Friend Sub Start()
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
    End Sub

    Private Sub CreatePlayerCharacter()
        _worldData.PlayerCharacterId = CreateCharacter(CharacterTypes.N00b).Id
    End Sub
    Private Function CreateCharacter(characterType As CharacterTypes) As Character
        Dim id As Integer = _worldData.Characters.Count
        _worldData.Characters.Add(New CharacterData With {
                                  .LocationId = RNG.FromRange(0, _worldData.Locations.Count),
                                  .Direction = RNG.FromRange(0, 4),
                                  .Messages = New List(Of String()),
                                  .Statistics = characterType.InitialStatistics.ToDictionary(Function(x) CInt(x.Key), Function(x) x.Value)})
        Return New Character(_worldData, id)
    End Function

    Friend Sub AbandonGame()
        _worldData = Nothing
    End Sub
    ReadOnly Property PlayerCharacter As Character
        Get
            Return New Character(_worldData, _worldData.PlayerCharacterId)
        End Get
    End Property
End Class
