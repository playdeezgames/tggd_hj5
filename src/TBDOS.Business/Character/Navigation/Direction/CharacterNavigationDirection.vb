Friend Class CharacterNavigationDirection
    Inherits CharacterDataClient
    Implements ICharacterNavigationDirection

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Property Current As String Implements ICharacterNavigationDirection.Current
        Get
            Return CharacterData.Direction
        End Get
        Set(value As String)
            CharacterData.Direction = value
        End Set
    End Property

    Public ReadOnly Property Ahead As String Implements ICharacterNavigationDirection.Ahead
        Get
            Return Directions.Descriptors(Current).AheadDirection
        End Get
    End Property

    Public ReadOnly Property Left As String Implements ICharacterNavigationDirection.Left
        Get
            Return Directions.Descriptors(Current).LeftDirection
        End Get
    End Property

    Public ReadOnly Property Right As String Implements ICharacterNavigationDirection.Right
        Get
            Return Directions.Descriptors(Current).RightDirection
        End Get
    End Property

    Public ReadOnly Property Opposite As String Implements ICharacterNavigationDirection.Opposite
        Get
            Return Directions.Descriptors(Current).OppositeDirection
        End Get
    End Property
End Class
