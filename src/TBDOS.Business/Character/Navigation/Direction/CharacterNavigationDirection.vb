Friend Class CharacterNavigationDirection
    Inherits CharacterDataClient
    Implements ICharacterNavigationDirection

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Property CurrentDirection As String Implements ICharacterNavigationDirection.CurrentDirection
        Get
            Return CharacterData.Direction
        End Get
        Set(value As String)
            CharacterData.Direction = value
        End Set
    End Property

    Public ReadOnly Property AheadDirection As String Implements ICharacterNavigationDirection.AheadDirection
        Get
            Return Directions.Descriptors(CurrentDirection).AheadDirection
        End Get
    End Property

    Public ReadOnly Property LeftDirection As String Implements ICharacterNavigationDirection.LeftDirection
        Get
            Return Directions.Descriptors(CurrentDirection).LeftDirection
        End Get
    End Property

    Public ReadOnly Property RightDirection As String Implements ICharacterNavigationDirection.RightDirection
        Get
            Return Directions.Descriptors(CurrentDirection).RightDirection
        End Get
    End Property

    Public ReadOnly Property OppositeDirection As String Implements ICharacterNavigationDirection.OppositeDirection
        Get
            Return Directions.Descriptors(CurrentDirection).OppositeDirection
        End Get
    End Property
End Class
