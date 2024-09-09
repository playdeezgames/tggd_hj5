Imports System.Runtime.CompilerServices

Public Module CharacterTypes
    Public ReadOnly N00b As String = NameOf(N00b)
End Module
Module CharacterTypesExtensions
    <Extension>
    Function InitialStatistics(characterType As String) As IReadOnlyDictionary(Of String, Integer)
        Select Case characterType
            Case CharacterTypes.N00b
                Return New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.Wounds, 0},
                        {StatisticTypes.MaximumHealth, 100},
                        {StatisticTypes.Hunger, 0},
                        {StatisticTypes.MaximumSatiety, 100}
                    }
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
