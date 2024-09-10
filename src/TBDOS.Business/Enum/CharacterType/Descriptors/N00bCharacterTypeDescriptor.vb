﻿Friend Class N00bCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor
    Public Sub New()
        MyBase.New(
            CharacterTypes.N00b,
            New Dictionary(Of String, Integer) From
                    {
                        {StatisticTypes.Wounds, 0},
                        {StatisticTypes.MaximumHealth, 100},
                        {StatisticTypes.Hunger, 0},
                        {StatisticTypes.MaximumSatiety, 100}
                    })
    End Sub

    Public Overrides Sub ApplyEffects(character As ICharacter)
        character.Statistics.Satiety -= 1
        character.Location.AddVisit(character)
    End Sub
End Class
