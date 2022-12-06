Module Program
    Sub Main(args As String())
        Dim world As New UIController
        Using root As New Root(world)
            root.Run()
        End Using
    End Sub
End Module
