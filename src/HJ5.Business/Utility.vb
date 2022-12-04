Module Utility
    Friend Function Clamp(value As Integer, minimum As Integer, maximum As Integer) As Integer
        Return Math.Max(minimum, Math.Min(value, maximum))
    End Function
End Module
