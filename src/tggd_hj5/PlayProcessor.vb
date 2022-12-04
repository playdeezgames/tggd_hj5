Module PlayProcessor
    Friend Sub Run(world As World)
        Do
            ExplorersProcessor.Run(world)
            TurnSummaryProcessor.Run(world)
            ExecuteOrdersProcessor.Run(world)
        Loop
    End Sub
End Module
