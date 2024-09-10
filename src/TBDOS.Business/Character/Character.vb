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

    Private Function GetStatistic(statisticType As String) As Integer
        Return CharacterData.Statistics(statisticType)
    End Function

    Private Sub SetStatistic(statisticType As String, value As Integer)
        CharacterData.Statistics(statisticType) = value
    End Sub

    ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
    End Property
    Public ReadOnly Property Messages As ICharacterMessages Implements ICharacter.Messages
        Get
            Return New CharacterMessages(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property Items As ICharacterItems Implements ICharacter.Items
        Get
            Return New CharacterItems(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property Navigation As ICharacterNavigation Implements ICharacter.Navigation
        Get
            Return New CharacterNavigation(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property Statistics As ICharacterStatistics Implements ICharacter.Statistics
        Get
            Return New CharacterStatistics(WorldData, Id)
        End Get
    End Property

    Public ReadOnly Property Status As ICharacterStatus Implements ICharacter.Status
        Get
            Return New CharacterStatus(WorldData, Id)
        End Get
    End Property
End Class
