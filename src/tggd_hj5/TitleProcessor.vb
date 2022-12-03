Module TitleProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim figlet = New FigletText(GameTitle) With {.Alignment = Justify.Center, .Color = Color.Aqua}
        AnsiConsole.Write(figlet)
        Pause(OkText)
        MainMenuProcessor.Run()
    End Sub
End Module
