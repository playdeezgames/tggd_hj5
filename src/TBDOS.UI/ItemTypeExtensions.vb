﻿Imports System.Runtime.CompilerServices
Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Module ItemTypeExtensions
    <Extension>
    Friend Function ShortcutKey(itemType As String) As Keys
        Select Case itemType
            Case "Food"
                Return Keys.F
            Case "Medicine"
                Return Keys.M
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
