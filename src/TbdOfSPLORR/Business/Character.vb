Public Class Character
    Private ReadOnly _worldData As WorldData
    Public ReadOnly Property Id As Integer
    Sub New(worldData As WorldData, id As Integer)
        Me.Id = id
        _worldData = worldData
    End Sub

    Friend Sub TurnAround()
        _worldData.Characters(Id).Direction = CInt(Direction.OppositeDirection)
    End Sub

    Friend Sub TurnLeft()
        _worldData.Characters(Id).Direction = CInt(Direction.LeftDirection)
    End Sub

    Friend Sub TurnRight()
        _worldData.Characters(Id).Direction = CInt(Direction.RightDirection)
    End Sub

    Friend Sub MoveAhead()
        Move(Direction.AheadDirection, "ahead")
    End Sub

    Private Sub Move(direction As Directions, text As String)
        If Not Location.HasRoute(direction) Then
            AddMessage("You cannot go that way!")
            Return
        End If
        AddMessage($"You move {text}.")
        _worldData.Characters(Id).LocationId = Location.Neighbor(direction).Id
    End Sub

    Private Sub AddMessage(ParamArray lines As String())
        If Id <> _worldData.PlayerCharacterId Then
            Return
        End If
        _worldData.Characters(Id).Messages.Add(lines)
    End Sub

    Friend Sub MoveBack()
        Move(Direction.OppositeDirection, "back")
    End Sub

    Friend Sub MoveLeft()
        Move(Direction.LeftDirection, "to the left")
    End Sub

    Friend Sub MoveRight()
        Move(Direction.RightDirection, "to the right")
    End Sub

    Friend Sub DismissMessage()
        If HasMessages Then
            _worldData.Characters(Id).Messages.RemoveAt(0)
        End If
    End Sub

    Friend ReadOnly Property NextMessage As IEnumerable(Of String)
        Get
            If Not HasMessages Then
                Return Array.Empty(Of String)
            End If
            Return _worldData.Characters(Id).Messages.First
        End Get
    End Property

    Friend ReadOnly Property HasMessages As Boolean
        Get
            Return _worldData.Characters(Id).Messages.Any
        End Get
    End Property

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
