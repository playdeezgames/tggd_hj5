Friend Class MedicineItemTypeDescriptor
    Inherits ItemTypeDescriptor

    Public Sub New()
        MyBase.New(ItemTypes.Medicine, 50, "[M]edicine", True, "Medicine")
    End Sub
End Class
