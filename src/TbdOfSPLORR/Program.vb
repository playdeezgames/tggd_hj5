Module Program
    Sub Main(args As String())
        Dim screenBuffer As New List(Of Byte)
        While screenBuffer.Count < 512
            screenBuffer.Add(64)
        End While
        Using root As New Root(screenBuffer)
            root.Run()
        End Using
    End Sub
End Module
