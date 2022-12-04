Module ReassignProcessor
    Friend Sub Run(explorer As Explorer)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]New Order?[/]"}
        prompt.AddChoice(NoChangesText)
        prompt.AddChoices(explorer.AvailableOrders)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NoChangesText
                Return
            Case Else
                explorer.Assign(answer)
        End Select
    End Sub
End Module
