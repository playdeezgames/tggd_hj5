Module ExplorersProcessor
    Friend Sub Run(world As World)
        For Each explorer In world.Explorers
            ExplorerProcessor.Run(explorer)
        Next
    End Sub
End Module
