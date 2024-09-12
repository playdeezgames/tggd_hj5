Imports Microsoft.Xna.Framework.Input

Friend Module ShortcutKeys
    Private ReadOnly ShortCutKeyItemTypes As IReadOnlyDictionary(Of Keys, String) =
        New Dictionary(Of Keys, String) From
        {
            {Keys.F, "Food"},
            {Keys.M, "Medicine"}
        }
    Friend Function ShortcutKeyToItemType(key As Keys) As String
        Dim result As String = Nothing
        If ShortCutKeyItemTypes.TryGetValue(key, result) Then
            Return result
        End If
        Return Nothing
    End Function
End Module
