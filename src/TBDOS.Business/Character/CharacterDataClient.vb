Imports TBDOS.Data

Friend Class CharacterDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property CharacterId As Integer
    Public Sub New(worldData As WorldData, characterId As Integer)
        MyBase.New(worldData)
        Me.CharacterId = characterId
    End Sub
    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(CharacterId)
        End Get
    End Property
End Class
