Imports SPLORR.Game

Public Class DirectionDescriptor
    ReadOnly Property Direction As String
    ReadOnly Property DirectionName As String
    ReadOnly Property AheadDirection As String
    ReadOnly Property OppositeDirection As String
    ReadOnly Property RightDirection As String
    ReadOnly Property LeftDirection As String
    ReadOnly Property DeltaX As Integer
    ReadOnly Property DeltaY As Integer
    Friend Sub New(
                  direction As String,
                  directionName As String,
                  aheadDirection As String,
                  oppositeDirection As String,
                  rightDirection As String,
                  leftDirection As String,
                  deltaX As Integer,
                  deltaY As Integer)
        Me.Direction = direction
        Me.DirectionName = directionName
        Me.AheadDirection = aheadDirection
        Me.OppositeDirection = oppositeDirection
        Me.RightDirection = rightDirection
        Me.LeftDirection = leftDirection
        Me.DeltaX = deltaX
        Me.DeltaY = deltaY
    End Sub
    Public Function AsMazeDirection() As MazeDirection(Of String)
        Return New MazeDirection(Of String)(OppositeDirection, DeltaX, DeltaY)
    End Function
End Class
