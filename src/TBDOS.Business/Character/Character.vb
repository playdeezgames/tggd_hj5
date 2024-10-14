Imports TBDOS.Data

Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter
    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
    Sub New(worldData As WorldData, id As Integer)
        MyBase.New(worldData, id)
    End Sub
    Public ReadOnly Property Messages As ICharacterMessages Implements ICharacter.Messages
        Get
            Return New CharacterMessages(WorldData, Id)
        End Get
    End Property
End Class
