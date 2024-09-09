Public Interface ICharacterMessages
    ReadOnly Property NextMessage As IEnumerable(Of String)
    Sub AddMessage(ParamArray lines As String())
    ReadOnly Property HasMessages As Boolean
    Sub DismissMessage()
End Interface
