Friend Class CharacterNavigationTurn
    Inherits CharacterDataClient
    Implements ICharacterNavigationTurn

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public Sub TurnAround() Implements ICharacterNavigationTurn.TurnAround
        Throw New NotImplementedException()
    End Sub

    Public Sub TurnLeft() Implements ICharacterNavigationTurn.TurnLeft
        Throw New NotImplementedException()
    End Sub

    Public Sub TurnRight() Implements ICharacterNavigationTurn.TurnRight
        Throw New NotImplementedException()
    End Sub
End Class
