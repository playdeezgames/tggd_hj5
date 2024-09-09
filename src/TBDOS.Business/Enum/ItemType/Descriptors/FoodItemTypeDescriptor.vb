Friend Class FoodItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Public Sub New()
        MyBase.New(ItemTypes.Food, 100, "[F]ood", True, "Food")
    End Sub
End Class
