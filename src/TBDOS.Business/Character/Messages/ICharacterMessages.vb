Public Interface ICharacterMessages
    ReadOnly Property Current As IEnumerable(Of String)
    Sub Add(ParamArray lines As String())
    ReadOnly Property HasAny As Boolean
    Sub Dismiss()
End Interface
