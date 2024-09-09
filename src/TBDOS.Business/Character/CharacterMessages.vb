Friend Class CharacterMessages
    Inherits CharacterDataClient
    Implements ICharacterMessages

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property NextMessage As IEnumerable(Of String) Implements ICharacterMessages.NextMessage
        Get
            If Not HasMessages Then
                Return Array.Empty(Of String)
            End If
            Return WorldData.Characters(CharacterId).Messages.First
        End Get
    End Property

    Public ReadOnly Property HasMessages As Boolean Implements ICharacterMessages.HasMessages
        Get
            Return WorldData.Characters(CharacterId).Messages.Any
        End Get
    End Property

    Public Sub AddMessage(ParamArray lines() As String) Implements ICharacterMessages.AddMessage
        If CharacterId <> WorldData.PlayerCharacterId Then
            Return
        End If
        WorldData.Characters(CharacterId).Messages.Add(lines)
    End Sub

    Public Sub DismissMessage() Implements ICharacterMessages.DismissMessage
        If HasMessages Then
            WorldData.Characters(CharacterId).Messages.RemoveAt(0)
        End If
    End Sub
End Class
