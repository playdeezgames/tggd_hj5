﻿Public Class Character
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
        Move(Direction.AheadDirection)
    End Sub

    Private Sub Move(direction As Directions)
        If Not Location.HasRoute(direction) Then
            AddMessage("You cannot go that way!")
            Return
        End If
        AddMessage("You move.")
        _worldData.Characters(Id).LocationId = Location.Neighbor(direction).Id
    End Sub

    Private Sub AddMessage(ParamArray lines As String())
        If Id <> _worldData.PlayerCharacterId Then
            Return
        End If
        _worldData.Characters(Id).Messages.Add(lines)
    End Sub

    Friend Sub MoveBack()
        Move(Direction.OppositeDirection)
    End Sub

    Friend Sub MoveLeft()
        Move(Direction.LeftDirection)
    End Sub

    Friend Sub MoveRight()
        Move(Direction.RightDirection)
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