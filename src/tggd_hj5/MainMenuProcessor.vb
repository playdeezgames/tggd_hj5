﻿Module MainMenuProcessor
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoices(QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If Confirm("[red]Are you sure you want to quit?[/]") Then
                        Exit Do
                    End If
            End Select
        Loop

    End Sub
End Module
