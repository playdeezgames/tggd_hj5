Module ItemConstants
    Friend Const NoItem = "no-item"
    Friend Const HopeItem = "hope"
    Friend Const DespairItem = "despair"
    Friend ReadOnly ItemGenerator As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {NoItem, 100},
            {HopeItem, 25},
            {DespairItem, 50}
        }
    Friend Function ItemName(item As String) As String
        Select Case item
            Case NoItem
                Return "nothing"
            Case HopeItem
                Return "hope"
            Case DespairItem
                Return "despair"
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    Friend Function GenerateEnnui(item As String) As Integer
        Select Case item
            Case NoItem
                Return 1
            Case DespairItem
                Return RNG.PickFromList(1, 2, 3, 4, 5, 6)
            Case HopeItem
                Return RNG.PickFromList(-1, -2, -3, -4, -5, -6)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
