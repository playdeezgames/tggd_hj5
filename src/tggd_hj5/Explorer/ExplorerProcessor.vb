Module ExplorerProcessor
    Friend Sub Run(explorer As Explorer)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Turn: {explorer.World.Turn}")
            AnsiConsole.MarkupLine($"Explorer Name: {explorer.Name}")
            AnsiConsole.MarkupLine($"Current Order: {explorer.OrderName}")
            AnsiConsole.MarkupLine($"Energy: {explorer.Energy}/{explorer.MaximumEnergy}")
            AnsiConsole.MarkupLine($"Ennui: {explorer.Ennui}/{explorer.MaximumEnnui}")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Orders?[/]"}
            prompt.AddChoices(NoChangesText, ReassignText)
            Select Case AnsiConsole.Prompt(prompt)
                Case NoChangesText
                    Exit Do
                Case ReassignText
                    ReassignProcessor.Run(explorer)
            End Select
        Loop
    End Sub
End Module
