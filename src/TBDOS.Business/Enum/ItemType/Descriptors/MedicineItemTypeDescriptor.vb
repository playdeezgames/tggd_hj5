Friend Class MedicineItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Public Sub New()
        MyBase.New(ItemTypes.Medicine, 50, "[M]edicine", True, "Medicine")
    End Sub

    Public Overrides Sub OnUse(character As ICharacter)
        character.Statistics.Health += 10
        character.Messages.Add("You use the medicine.", $"Yer health is now {character.Statistics.Health}/{character.Statistics.MaximumHealth}")
    End Sub
End Class
