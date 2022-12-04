Module TitleProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim figlet = New FigletText(GameTitle) With {.Alignment = Justify.Center, .Color = Color.Aqua}
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A game in VB.NET about exploration.")
        AnsiConsole.WriteLine("A production of TheGrumpyGameDev")
        AnsiConsole.WriteLine("For The Honest Jam V")
        Pause(OkText)
        MainMenuProcessor.Run()
    End Sub
End Module
