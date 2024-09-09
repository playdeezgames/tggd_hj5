Friend Class CharacterMessages
    Inherits CharacterDataClient
    Implements ICharacterMessages

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property Current As IEnumerable(Of String) Implements ICharacterMessages.Current
        Get
            If Not HasAny Then
                Return Array.Empty(Of String)
            End If
            Return WorldData.Characters(CharacterId).Messages.First
        End Get
    End Property

    Public ReadOnly Property HasAny As Boolean Implements ICharacterMessages.HasAny
        Get
            Return WorldData.Characters(CharacterId).Messages.Any
        End Get
    End Property

    Public Sub Add(ParamArray lines() As String) Implements ICharacterMessages.Add
        If CharacterId <> WorldData.PlayerCharacterId Then
            Return
        End If
        WorldData.Characters(CharacterId).Messages.Add(lines)
    End Sub

    Public Sub Dismiss() Implements ICharacterMessages.Dismiss
        If HasAny Then
            WorldData.Characters(CharacterId).Messages.RemoveAt(0)
        End If
    End Sub
End Class
