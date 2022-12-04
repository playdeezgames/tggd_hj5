Module PlayProcessor
    Friend Sub Run(world As World)
        Do
            For Each explorer In world.Explorers
                ExplorerProcessor.Run(explorer)
            Next
        Loop
    End Sub
End Module
