Friend Module Utility
    Friend Sub Pause(text As String)
        Dim prompt = New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoices(text)
        AnsiConsole.Prompt(prompt)
    End Sub
    Friend Function Confirm(text As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = text}
        prompt.AddChoices(NoText, YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
