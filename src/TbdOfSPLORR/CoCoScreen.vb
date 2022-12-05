Imports System.Reflection.PortableExecutable

Public Class CoCoScreen
    Private _fill As Byte
    Private _columns As Integer
    Private _screenBuffer As List(Of Byte)
    Private _cursor As Integer
    Sub New(screenBuffer As List(Of Byte), columns As Integer, fill As Byte)
        _fill = fill
        _columns = columns
        _screenBuffer = screenBuffer
        _cursor = 0
    End Sub
    Sub Clear(character As Byte)
        For index = 0 To _screenBuffer.Count - 1
            _screenBuffer(index) = character
        Next
    End Sub
    Sub WriteByte(value As Byte)
        While _cursor >= _screenBuffer.Count
            ScrollScreen()
        End While
        _screenBuffer(_cursor) = value
        _cursor += 1
    End Sub
    Private Sub ScrollScreen()
        For index = 0 To _screenBuffer.Count - _columns - 1
            _screenBuffer(index) = _screenBuffer(index + _columns)
        Next
        For index = _screenBuffer.Count - _columns To _screenBuffer.Count - 1
            _screenBuffer(index) = _fill
        Next
        _cursor -= _columns
    End Sub
    Private ReadOnly table As IReadOnlyDictionary(Of Char, Byte) =
        New Dictionary(Of Char, Byte) From
        {
            {"@"c, 64},
            {"A"c, 65},
            {"B"c, 66},
            {"C"c, 67},
            {"D"c, 68},
            {"E"c, 69},
            {"F"c, 70},
            {"G"c, 71},
            {"H"c, 72},
            {"I"c, 73},
            {"J"c, 74},
            {"K"c, 75},
            {"L"c, 76},
            {"M"c, 77},
            {"N"c, 78},
            {"O"c, 79},
            {"P"c, 80},
            {"Q"c, 81},
            {"R"c, 82},
            {"S"c, 83},
            {"T"c, 84},
            {"U"c, 85},
            {"V"c, 86},
            {"W"c, 87},
            {"X"c, 88},
            {"Y"c, 89},
            {"Z"c, 90},
            {"["c, 91},
            {"\"c, 92},
            {"]"c, 93},
            {"^"c, 94},
            {" "c, 96},
            {"!"c, 97},
            {""""c, 98},
            {"#"c, 99},
            {"$"c, 100},
            {"%"c, 101},
            {"&"c, 102},
            {"'"c, 103},
            {"("c, 104},
            {")"c, 105},
            {"*"c, 106},
            {"+"c, 107},
            {","c, 108},
            {"-"c, 109},
            {"."c, 110},
            {"/"c, 111},
            {"0"c, 112},
            {"1"c, 113},
            {"2"c, 114},
            {"3"c, 115},
            {"4"c, 116},
            {"5"c, 117},
            {"6"c, 118},
            {"7"c, 119},
            {"8"c, 120},
            {"9"c, 121},
            {":"c, 122},
            {";"c, 123},
            {"<"c, 124},
            {"="c, 125},
            {">"c, 126},
            {"?"c, 127},
            {"a"c, 65},
            {"b"c, 66},
            {"c"c, 67},
            {"d"c, 68},
            {"e"c, 69},
            {"f"c, 70},
            {"g"c, 71},
            {"h"c, 72},
            {"i"c, 73},
            {"j"c, 74},
            {"k"c, 75},
            {"l"c, 76},
            {"m"c, 77},
            {"n"c, 78},
            {"o"c, 79},
            {"p"c, 80},
            {"q"c, 81},
            {"r"c, 82},
            {"s"c, 83},
            {"t"c, 84},
            {"u"c, 85},
            {"v"c, 86},
            {"w"c, 87},
            {"x"c, 88},
            {"y"c, 89},
            {"z"c, 90}
        }
    Sub WriteCharacter(value As Char)
        If table.ContainsKey(value) Then
            WriteByte(table(value))
        ElseIf value = vbCr Then
            While _cursor Mod _columns <> 0
                WriteByte(_fill)
            End While
        ElseIf value = vbLf Then
            'do nothing
        Else
            'also do nothing!
        End If
    End Sub
    Sub Write(value As String)
        For Each character In value
            WriteCharacter(character)
        Next
    End Sub
    Sub WriteLine(value As String)
        Write(value & vbCr)
    End Sub
    Sub Invert(column As Integer, row As Integer, columns As Integer, rows As Integer)
        For y = 0 To row + rows - 1
            For x = 0 To column + columns - 1
                _screenBuffer(y * _columns + x) = _screenBuffer(y * _columns + x) Xor CByte(64)
            Next
        Next
    End Sub

    Friend Sub GoToXY(x As Integer, y As Integer)
        _cursor = x + y * _columns
    End Sub
End Class
