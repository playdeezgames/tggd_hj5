Public Class World
    Private _screenBuffer As New List(Of Byte)
    Friend ReadOnly Property ScreenBuffer As Byte()
        Get
            Return _screenBuffer.ToArray
        End Get
    End Property
    Sub New()
        While _screenBuffer.Count < 512
            _screenBuffer.Add(64)
        End While
    End Sub

    Friend Sub HandleKeyDown(key As Keys)
    End Sub

    Friend Sub HandleKeyUp(key As Keys)
    End Sub

    Friend Sub Update(ticks As Long)

    End Sub
End Class
