Module ExplorerProcessor
    Friend Sub Run(explorer As Explorer)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Turn: {explorer.World.Turn}")
            AnsiConsole.MarkupLine($"Explorer Name: {explorer.Name}")
            AnsiConsole.MarkupLine($"Current Order: {explorer.Order}")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Orders?[/]"}
            prompt.AddChoice(NoChangesText)
            Select Case AnsiConsole.Prompt(prompt)
                Case NoChangesText
                    Exit Do
            End Select
        Loop
    End Sub
End Module
