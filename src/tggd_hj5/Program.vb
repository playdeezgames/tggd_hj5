Imports System

Module Program
    Sub Main(args As String())
        AnsiConsole.Clear()
        Dim figlet = New FigletText("Hello, Honest Jam 5!") With {.Alignment = Justify.Center, .Color = Color.Aqua}
        AnsiConsole.Write(figlet)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
