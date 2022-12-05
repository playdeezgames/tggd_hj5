Public Class World
    Private _screenBuffer As New List(Of Byte)
    Private _screen As CoCoScreen
    Friend ReadOnly Property ScreenBuffer As Byte()
        Get
            Return _screenBuffer.ToArray
        End Get
    End Property
    Sub New()
        While _screenBuffer.Count < 512
            _screenBuffer.Add(96)
        End While
        _screen = New CoCoScreen(_screenBuffer, 32, 96)
        _screen.WriteString("Hello, 
world!")
        _screen.Invert(0, 0, 6, 1)
    End Sub
    Private ReadOnly table As IReadOnlyDictionary(Of Keys, Char) =
        New Dictionary(Of Keys, Char) From
        {
            {Keys.D0, "0"c},
            {Keys.D1, "1"c},
            {Keys.D2, "2"c},
            {Keys.D3, "3"c},
            {Keys.D4, "4"c},
            {Keys.D5, "5"c},
            {Keys.D6, "6"c},
            {Keys.D7, "7"c},
            {Keys.D8, "8"c},
            {Keys.D9, "9"c}
        }

    Friend Sub HandleKeyDown(key As Keys)
        If table.ContainsKey(key) Then
            _screen.WriteCharacter(table(key))
        End If
    End Sub

    Friend Sub HandleKeyUp(key As Keys)
    End Sub

    Friend Sub Update(ticks As Long)
    End Sub
End Class
