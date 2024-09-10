﻿Friend MustInherit Class CharacterTypeDescriptor
    ReadOnly Property CharacterType As String
    ReadOnly Property InitialStatistics As IReadOnlyDictionary(Of String, Integer)
    Sub New(
           characterType As String,
           initialStatistics As IReadOnlyDictionary(Of String, Integer))
        Me.CharacterType = characterType
        Me.InitialStatistics = initialStatistics
    End Sub
    MustOverride Sub ApplyEffects(character As ICharacter)
End Class
