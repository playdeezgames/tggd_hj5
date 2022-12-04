Module ExecuteOrdersProcessor
    Friend Sub Run(world As World)
        AnsiConsole.Clear()
        For Each explorer In world.Explorers
            ExecuteOrderProcessor.Run(explorer)
        Next
        For Each message In world.NextTurn()
            AnsiConsole.MarkupLine(message)
        Next
        Pause(OkText)
    End Sub
End Module
