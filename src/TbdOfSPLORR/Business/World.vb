Public Class World
    Private _worldData As WorldData
    Sub New()

    End Sub
    Public ReadOnly Property IsGameOver As Boolean
        Get
            Return _worldData Is Nothing
        End Get
    End Property

    Friend Sub Start()
        _worldData = New WorldData With
            {
                .Characters = New List(Of CharacterData),
                .Locations = New List(Of LocationData),
                .PlayerCharacterId = 0
            }
        Dim table = New Dictionary(Of Directions, MazeDirection(Of Directions)) From
                                           {
                                            {Directions.North, New MazeDirection(Of Directions)(Directions.South, 0, -1)},
                                            {Directions.East, New MazeDirection(Of Directions)(Directions.West, 1, 0)},
                                            {Directions.South, New MazeDirection(Of Directions)(Directions.North, 0, 1)},
                                            {Directions.West, New MazeDirection(Of Directions)(Directions.East, -1, 0)}
                                           }
        Const MazeColumns = 8
        Const MazeRows = 8
        Dim maze = New Maze(Of Directions)(MazeColumns, MazeRows, table)
        maze.Generate()
        For row = 0 To maze.Rows - 1
            For column = 0 To maze.Columns - 1
                Dim locationData As New LocationData With {.Neighbors = New Dictionary(Of Integer, Integer)}
                For Each direction In maze.GetCell(column, row).Directions
                    If maze.GetCell(column, row).GetDoor(direction).Open Then
                        Dim nextColumn = CInt(column + table(direction).DeltaX)
                        Dim nextRow = CInt(row + table(direction).DeltaY)
                        locationData.Neighbors.Add(CInt(direction), nextColumn + nextRow * MazeColumns)
                    End If
                Next
                _worldData.Locations.Add(locationData)
            Next
        Next
        _worldData.PlayerCharacterId = _worldData.Characters.Count
        _worldData.Characters.Add(New CharacterData With {.LocationId = 0})
    End Sub

    Friend Sub AbandonGame()
        _worldData = Nothing
    End Sub
    ReadOnly Property PlayerCharacter As Character
        Get
            Return New Character(_worldData, _worldData.PlayerCharacterId)
        End Get
    End Property
End Class
