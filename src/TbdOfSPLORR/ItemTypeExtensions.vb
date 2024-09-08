Imports System.Runtime.CompilerServices

Module ItemTypeExtensions
    <Extension>
    Function ShortcutKey(itemType As ItemTypes) As Keys
        Select Case itemType
            Case ItemTypes.Food
                Return Keys.F
            Case ItemTypes.Medicine
                Return Keys.M
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

End Module
