Imports System.Runtime.CompilerServices

Public Enum CharacterTypes
    N00b
End Enum
Module CharacterTypesExtensions
    <Extension>
    Function InitialStatistics(characterType As CharacterTypes) As IReadOnlyDictionary(Of String, Integer)
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
