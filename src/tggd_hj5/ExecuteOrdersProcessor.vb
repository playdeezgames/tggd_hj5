Module ExecuteOrdersProcessor
    Friend Sub Run(world As World)
        AnsiConsole.Clear()
        For Each explorer In world.Explorers
            ExecuteOrderProcessor.Run(explorer)
        Next
        world.NextTurn()
        Pause(OkText)
    End Sub
End Module
