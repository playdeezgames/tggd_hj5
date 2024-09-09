Imports System.Runtime.CompilerServices
Imports SPLORR.Game

Public Module Directions
    Friend ReadOnly North As String = NameOf(North)
    Friend ReadOnly East As String = NameOf(East)
    Friend ReadOnly South As String = NameOf(South)
    Friend ReadOnly West As String = NameOf(West)
    Public ReadOnly Descriptors As IReadOnlyDictionary(Of String, DirectionDescriptor) =
        New List(Of DirectionDescriptor) From
        {
            New DirectionDescriptor(North, "north", North, South, East, West, 0, -1),
            New DirectionDescriptor(East, "east", East, West, South, North, 1, 0),
            New DirectionDescriptor(South, "south", South, North, West, East, 0, 1),
            New DirectionDescriptor(West, "west", West, East, North, South, -1, 0)
        }.ToDictionary(Function(x) x.Direction, Function(x) x)
    ReadOnly Property AllDirections As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
End Module
