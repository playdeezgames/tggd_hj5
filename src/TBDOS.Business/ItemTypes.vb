﻿Imports System.Runtime.CompilerServices

Public Enum ItemTypes
    Food
    Medicine
End Enum
Public Module ItemTypesExtensions
    <Extension>
    Function SpawnCount(itemType As ItemTypes) As Integer
        Select Case itemType
            Case ItemTypes.Food
                Return 100
            Case ItemTypes.Medicine
                Return 50
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function InventoryName(itemType As ItemTypes) As String
        Select Case itemType
            Case ItemTypes.Food
                Return "[F]ood"
            Case ItemTypes.Medicine
                Return "[M]edicine"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function CanUse(itemType As ItemTypes) As Boolean
        Select Case itemType
            Case ItemTypes.Food
                Return True
            Case ItemTypes.Medicine
                Return True
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function Name(itemType As ItemTypes) As String
        Select Case itemType
            Case ItemTypes.Food
                Return "Food"
            Case ItemTypes.Medicine
                Return "Medicine"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    Public ReadOnly Property AllItemTypes As ItemTypes()
        Get
            Return New ItemTypes() {ItemTypes.Food, ItemTypes.Medicine}
        End Get
    End Property
End Module