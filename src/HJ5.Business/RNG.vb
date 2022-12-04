Module RNG
    Private _random As Random = New Random

    Friend Function GenerateExplorerName() As String
        Dim nameLength As Integer = PickFromList(1, 2, 3) + PickFromList(1, 2, 3) + PickFromList(1, 2, 3)
        Dim vowel = PickFromList(True, False)
        Dim result = ""
        While result.Length < nameLength
            If vowel Then
                result += PickFromList("a", "e", "i", "o", "u")
            Else
                result += PickFromList("h", "k", "l", "m", "p")
            End If
            vowel = Not vowel
        End While
        Return result
    End Function

    Friend Function PickFromList(Of TItem)(ParamArray items As TItem()) As TItem
        Return items(_random.Next(items.Length))
    End Function
    Friend Function Generate(Of TItem)(generator As IReadOnlyDictionary(Of TItem, Integer)) As TItem
        Dim total = generator.Sum(Function(x) x.Value)
        Dim generated = _random.Next(total)
        For Each entry In generator
            If generated < entry.Value Then
                Return entry.Key
            Else
                generated -= entry.Value
            End If
        Next
        Throw New NotImplementedException
    End Function
End Module
