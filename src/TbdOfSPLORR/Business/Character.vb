Public Class Character
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub

    Friend Sub TurnAround()
        _worldData.Characters(Id).Direction = CInt(Direction.BehindDirection)
    End Sub

    Friend Sub TurnLeft()
        _worldData.Characters(Id).Direction = CInt(Direction.LeftDirection)
    End Sub

    Friend Sub TurnRight()
        _worldData.Characters(Id).Direction = CInt(Direction.RightDirection)
    End Sub

    ReadOnly Property Location As Location
        Get
            Return New Location(_worldData, _worldData.Characters(Id).LocationId)
        End Get
    End Property
    ReadOnly Property Direction As Directions
        Get
            Return CType(_worldData.Characters(Id).Direction, Directions)
        End Get
    End Property
End Class
