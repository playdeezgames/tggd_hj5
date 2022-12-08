Module Utility
    Function Clamp(value As Integer, minimum As Integer, maximum As Integer) As Integer
        Return Math.Min(maximum, Math.Max(value, minimum))
    End Function
End Module
