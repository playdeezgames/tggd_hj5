Friend Module ItemTypes
    Friend ReadOnly Food As String = NameOf(Food)
    Friend ReadOnly Medicine As String = NameOf(Medicine)
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New List(Of ItemTypeDescriptor) From
        {
            New FoodItemTypeDescriptor(),
            New MedicineItemTypeDescriptor()
        }.ToDictionary(Function(x) x.ItemType, Function(x) x)
    Friend ReadOnly Property AllItemTypes As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
End Module
