Imports System.Runtime.CompilerServices

Public Module ItemTypes
    Public ReadOnly Food As String = NameOf(Food)
    Public ReadOnly Medicine As String = NameOf(Medicine)
End Module
Public Module ItemTypesExtensions
    <Extension>
    Function SpawnCount(itemType As String) As Integer
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
    Function InventoryName(itemType As String) As String
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
    Function CanUse(itemType As String) As Boolean
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
    Function ItemTypeName(itemType As String) As String
        Select Case itemType
            Case ItemTypes.Food
                Return "Food"
            Case ItemTypes.Medicine
                Return "Medicine"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    Public ReadOnly Property AllItemTypes As String()
        Get
            Return New String() {ItemTypes.Food, ItemTypes.Medicine}
        End Get
    End Property
End Module
