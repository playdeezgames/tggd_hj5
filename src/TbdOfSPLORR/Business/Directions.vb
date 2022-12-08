Imports System.Runtime.CompilerServices

Public Enum Directions
    North
    East
    South
    West
End Enum
Public Module DirectionsExtensions
    <Extension>
    Public Function Name(direction As Directions) As String
        Select Case direction
            Case Directions.North
                Return "north"
            Case Directions.East
                Return "east"
            Case Directions.South
                Return "south"
            Case Directions.West
                Return "west"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function AheadDirection(direction As Directions) As Directions
        Select Case direction
            Case Directions.North
                Return Directions.North
            Case Directions.East
                Return Directions.East
            Case Directions.South
                Return Directions.South
            Case Directions.West
                Return Directions.West
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function OppositeDirection(direction As Directions) As Directions
        Select Case direction
            Case Directions.North
                Return Directions.South
            Case Directions.East
                Return Directions.West
            Case Directions.South
                Return Directions.North
            Case Directions.West
                Return Directions.East
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function RightDirection(direction As Directions) As Directions
        Select Case direction
            Case Directions.North
                Return Directions.East
            Case Directions.East
                Return Directions.South
            Case Directions.South
                Return Directions.West
            Case Directions.West
                Return Directions.North
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function LeftDirection(direction As Directions) As Directions
        Select Case direction
            Case Directions.North
                Return Directions.West
            Case Directions.East
                Return Directions.North
            Case Directions.South
                Return Directions.East
            Case Directions.West
                Return Directions.South
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function AsMazeDirection(direction As Directions) As MazeDirection(Of Directions)
        Return New MazeDirection(Of Directions)(direction.OppositeDirection, direction.DeltaX, direction.DeltaY)
    End Function
    <Extension>
    Public Function DeltaX(direction As Directions) As Integer
        Select Case direction
            Case Directions.North
                Return 0
            Case Directions.East
                Return 1
            Case Directions.South
                Return 0
            Case Directions.West
                Return -1
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Public Function DeltaY(direction As Directions) As Integer
        Select Case direction
            Case Directions.North
                Return -1
            Case Directions.East
                Return 0
            Case Directions.South
                Return 1
            Case Directions.West
                Return 0
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    ReadOnly Property AllDirections As IEnumerable(Of Directions)
        Get
            Return New Directions() {Directions.North, Directions.East, Directions.South, Directions.West}
        End Get
    End Property
End Module