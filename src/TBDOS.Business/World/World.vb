Imports SPLORR.Game
Imports TBDOS.Data

Public Class World
    Implements IWorld
    Private _worldData As WorldData
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
                .PlayerCharacterId = Nothing
            }
    End Sub
    Public Sub Start() Implements IWorld.Start
        InitializeWorldData()
        CreatePlayerCharacter()
    End Sub

    Private Sub CreatePlayerCharacter()
        _worldData.PlayerCharacterId = CreateCharacter(CharacterTypes.N00b).Id
    End Sub
    Private Function CreateCharacter(characterType As String) As ICharacter
        Dim id As Integer = _worldData.Characters.Count
        _worldData.Characters.Add(New CharacterData With {
                                    .CharacterType = characterType,
                                  .Messages = New List(Of String())})
        Dim character As ICharacter = New Character(_worldData, id)
        Return character
    End Function

    Public Sub Abandon() Implements IWorld.Abandon
        _worldData = Nothing
    End Sub
    ReadOnly Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            If _worldData Is Nothing OrElse Not _worldData.PlayerCharacterId.HasValue Then
                Return Nothing
            End If
            Return New Character(_worldData, _worldData.PlayerCharacterId.Value)
        End Get
    End Property
End Class
