Module ExecuteOrderProcessor
    Friend Sub Run(explorer As Explorer)
        Dim messages = explorer.ExecuteOrder()
        For Each message In messages
            AnsiConsole.MarkupLine(message)
        Next
    End Sub
End Module
