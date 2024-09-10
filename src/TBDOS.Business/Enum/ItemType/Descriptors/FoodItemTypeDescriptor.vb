Friend Class FoodItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Public Sub New()
        MyBase.New(ItemTypes.Food, 100, "[F]ood", True, "Food")
    End Sub

    Public Overrides Sub OnUse(character As ICharacter)
        character.Statistics.Satiety += 10
        character.Messages.Add("You eat the food.", $"Yer satiety is now {character.Statistics.Satiety}/{character.Statistics.MaximumSatiety}")
    End Sub
End Class
