Module TurnSummaryProcessor
    Friend Sub Run(world As World)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Order Summary:")
        For Each explorer In world.Explorers
            AnsiConsole.MarkupLine($" - {explorer.Name} will {explorer.OrderName}.")
        Next
        Pause(OkText)
    End Sub
End Module
